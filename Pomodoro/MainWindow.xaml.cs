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
using System.ComponentModel;
using WpfApplication1;
using System.Media;
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
        bool isWorkingTime;
        private int targetTime;
        private double progPercent;
        private int quater;


        public void Main_unload(object sender, CancelEventArgs e)
        {
            if (!this.currentStat.isSaved())
            {
                MessageBox.Show("did you save stat?");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.load();
        }

        public string monthConv(string y)
        {
            int x = int.Parse(y);
            string xx=null;

            switch (x)
            {
                case 1:
                   xx="Jan";
                   break;
                case 2:
                   xx="Feb";
                   break;
                case 3:
                   xx="Mar";
                   break;
                case 4:
                   xx="Apr";
                   break;
                case 5:
                   xx="May";
                   break;
                case 6:
                   xx="Jun";
                   break;
                case 7:
                   xx="Jul";
                   break;
                case 8:
                   xx = "Aug";
                   break;
                case 9:
                   xx = "Sep";
                   break;
                case 10:
                   xx = "Oct";
                   break;
                case 11:
                   xx = "Nov";
                   break;
                case 12:
                   xx = "Dec";
                   break;
                default:
                   xx="Jan";
                   break;
            }

            return xx;
        }

        private void load()
        {
            currentSetting = new Setting();
            currentStat = new Stat();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick+= Timer_Tick;
            isWorkingTime = false;
            quater = 0;

            setMonitor();
            sessionManger();
            
            setTimer();
            this.btnStart.IsEnabled = true;
            this.btnStop.IsEnabled = false;

            this.txtDate.Text =
                this.currentStat.year + " " +
                this.monthConv(this.currentStat.mongth) + " " +
                this.currentStat.date + " " +
                this.currentStat.dayOfWeek;

        }

        private void setMonitor()
        {
            time = currentStat.time;
            getTime();
            txtTimeMonitor.Text = hour.ToString() + ":" + minute.ToString() + ":" + second.ToString()+", total s = " + time;
        }

        private void setTimer()
        {
            getTime();
            txtTimer.Text = hour.ToString() + ":" + minute.ToString() + ":" + second.ToString();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Timer.Start();
            Console.WriteLine("start: " + isWorkingTime + " quater: " + quater);

            this.btnStart.IsEnabled = false;
            this.btnStop.IsEnabled = true;
            targetTime = time;
           
            if (isWorkingTime)
            {
                this.txtCurrentQuater.Text = (quater + 1).ToString();
            }
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            getTime();
            countDown();
            
        }

        private void countDown()
        {
            time--;
            if (isWorkingTime)
            {
                this.currentStat.increase();
            }
            
            txtTimer.Text = hour.ToString() + ":" + minute.ToString() + ":" + second.ToString();

            progPercent = (targetTime * 1.0 - time * 1.0) / targetTime * 100;
            Console.WriteLine(progPercent);
            this.progTimer.Value = progPercent; 

            if (time == 0)
            {
                stopClock();
                SystemSounds.Hand.Play();
            }

        }

        private void getTime()
        {
            //Console.WriteLine("TIme: " + time);
            remainingTime = time;
            hour = remainingTime / 3600;
            remainingTime = remainingTime % 3600;
            minute = remainingTime / 60;
            remainingTime = remainingTime % 60;
            second = remainingTime;
            //Console.WriteLine("second: " + second);
        }

        private void stopClock()
        {
            Timer.Stop();
            setMonitor();            
            sessionManger();
            
            setTimer();
            Console.WriteLine("end: " + isWorkingTime+ ", quater complete:" + quater);
            this.btnStart.IsEnabled = true;
            this.btnStop.IsEnabled = false;
            progPercent = 0;
            Console.WriteLine(progPercent);
            this.progTimer.Value = progPercent; 
        }

        private void sessionManger()
        {
            if (!isWorkingTime)
            {
                this.lblStatus.Content = "Working Time";
            }
            else
            {
                this.lblStatus.Content = "Break Time";
            }

            Console.WriteLine("isWorkingTime: " + isWorkingTime);
            if (isWorkingTime)
            {
                isWorkingTime = !isWorkingTime;
                quater++;
                //Console.WriteLine("im here");
                
                if (quater == currentSetting.sessionLength)
                {
                    time = currentSetting.sessionBreakTime;
                    quater = 0;
                }
                else
                {
                    time = currentSetting.breakTime;
                    
                }
            }
            else
            {
                isWorkingTime = !isWorkingTime;
                this.time = currentSetting.roundingTime;
                //Console.WriteLine("setting time: " + this.time);
            }

            
            
           
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            this.stopClock();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string dir = AbsAddress.getFolderAddr("sounds") + "chimes.wave";
            //Console.WriteLine(dir);
            //mediaPlay.Source = new Uri(dir);
            //mediaPlay.Play();
            SystemSounds.Hand.Play();


        }

    }
}
