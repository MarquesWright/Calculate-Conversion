using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Conversions
{
    public class Conversions
    {
        //the conversion variables or fields
        private string from;
        private string to;
        private decimal conNum;

        //empty constructor
        public Conversions() { }

        //custom constructor
        public Conversions(string from, string to, decimal conNum)
        {
            this.From = from;
            this.To = to;
            this.ConNum = conNum;
        }

        //The From property
        public string From
        {
            get
            {
                return from;
            }
            set
            {
                from = value;
            }
        }

        //The To property
        public string To
        {
            get
            {
                return to;
            }
            set
            {
                to = value;
            }
        }

        //The Decimal property
        public decimal ConNum
        {
            get
            {
                return conNum;
            }
            set
            {
                conNum = value;
            }
        }

        public string GetDisplayText()
        {
            return from + " to " + to;
        }

    }
}
