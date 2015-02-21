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
        private string _year;
        private string _month;
        private string _date;
        private string _dayOfWeek;
        private int _time;
        private bool saveStatus;

        public Stat()
        {
            saveStatus = false;
            string rawDate = DateTime.Now.ToString("MM/dd/yyyy");
            Console.WriteLine(rawDate);
            _month = rawDate.Substring(0, 2);
            Console.WriteLine(_month);
            _date = rawDate.Substring(3, 2);
            Console.WriteLine(_date);
            _year = rawDate.Substring(6, 4);
            Console.WriteLine(_year);

            DateTime dateValue = DateTime.Now;
            _dayOfWeek = dateValue.DayOfWeek.ToString();


        }

        public string year
        {
            get { return this._year; }
        }
        public string mongth
        {
            get { return this._month; }
        }
        public string date
        {
            get { return this._date; }
        }

        public string dayOfWeek
        {
            get { return this._dayOfWeek; }
        }

        public int time{
            get { return this._time; }
        }

        public void increase()
        {
            this._time++;
        }

        public bool isSaved()
        {
            return saveStatus;
        }

        public void save()
        {
            if (_time == 0)
            {
                MessageBox.Show("error");
            }
            else
            {
                
            }
        }

       



    }
}
