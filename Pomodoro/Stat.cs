using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pomodoro
{
    class Stat
    {
        private ExIO myFile;
        private string year;
        private string month;
        private string date;
        private string day;
        private int time;
        private bool saveStatus;

        public Stat()
        {
            saveStatus = false;
            string rawDate = DateTime.Now.ToString("MM/dd/yyyy");
            Console.WriteLine(rawDate);
            month = rawDate.Substring(0, 2);
            Console.WriteLine(month);
            date = rawDate.Substring(3, 2);
            Console.WriteLine(date);
            year = rawDate.Substring(6, 4);
            Console.WriteLine(year);
        }

        public void increase()
        {
            this.time++;
        }

        public bool isSaved()
        {
            return saveStatus;
        }

        public void save()
        {
            if (time == 0)
            {
                MessageBox.Show("error");
            }
            else
            {
                
            }
        }

       



    }
}
