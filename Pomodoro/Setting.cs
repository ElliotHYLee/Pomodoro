using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro
{
    class Setting
    {
        private int _roundingTime;
        private int _breakTime;
        private int _sessionBreakTime;
        private int _sessionLength;

        public Setting()
        {
            this._sessionLength = 3;
            this._roundingTime = 25*60;
            _breakTime = 5*60;
            _sessionBreakTime = 15*60 ;
        }
        public int sessionLength
        {
            get { return this._sessionLength; }
        }

        public int roundingTime
        {
            set { this._roundingTime = value; }
            get { return this._roundingTime; }
        }

        public int breakTime
        {
            set { this._breakTime = value; }
            get { return this._breakTime; }
        }

        public int sessionBreakTime
        {
            set { this._sessionBreakTime = value; }
            get { return this._sessionBreakTime; }
        }
    }
}
