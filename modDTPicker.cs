using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogistMate.Components
{
    public class modDTPicker : DateTimePicker
    {
        private const string format_date = "dd MMM, yyyy";
        private const string format_time = "HH:mm";
        private const string format_datetime = "dd MMM, yyyy HH:mm";

        public enum TIMETYPE { DATE, TIME, DATETIME };
        private TIMETYPE _TimeType;
        public TIMETYPE TimeType { get { return this._TimeType; } set { this._TimeType = value; setType(); } }

        public modDTPicker()
        {
            this.TimeType = TIMETYPE.DATETIME;
            setType();
        }

        private void setType()
        {
            this.Format = DateTimePickerFormat.Custom;
            this.Value = DateTime.Now.Date;
            switch (this._TimeType)
            {
                case TIMETYPE.DATE:
                    this.CustomFormat = format_date;
                    this.ShowUpDown = false;
                    break;
                case TIMETYPE.TIME:
                    this.CustomFormat = format_time;
                    this.ShowUpDown = true;
                    break;
                case TIMETYPE.DATETIME:
                    this.CustomFormat = format_datetime;
                    this.ShowUpDown = false;
                    break;
            }
        }

        protected internal void setTimeSpan(TimeSpan? time)
        {
            this.Value = DateTime.Today.Add(time ?? new TimeSpan());
        }

        protected internal TimeSpan getTimeSpan()
        {
            return this.Value.TimeOfDay;
        }
       
    }
}
