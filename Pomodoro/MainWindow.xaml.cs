using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pomodoro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int time;
        private int remainingTime;
        private DispatcherTimer Timer;
        private int hour;
        private int minute;
        private int second;
        private Setting currentSetting;
        private Stat currentStat;
        public MainWindow()
        {
            InitializeComponent();
            this.load();
        }
        private void load()
        {
            currentSetting = new Setting();
            currentStat = new Stat();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick+= Timer_Tick;

            time = this.currentSetting.roundingTime;
            getTime();
            txtTimer.Text = hour.ToString() + ":" + minute.ToString() + ":" + second.ToString();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            getTime();
            time--;
            this.currentStat.increase();
            txtTimer.Text = hour.ToString() + ":" + minute.ToString() + ":" + second.ToString();

        }

        private void getTime()
        {
            remainingTime = time;
            hour = remainingTime / 3600;
            remainingTime = remainingTime % 3600;
            minute = remainingTime / 60;
            remainingTime = remainingTime % 60;
            second = remainingTime;  
        }

    }
}
