using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Conversions
{
    public class Options
    {

        public Options()
        {
        }

        public Options(string from, string to, decimal conNum)
        {
            this.From = from;
            this.To = to;
            this.ConNum = conNum;
        }

        public string From { get; set; }

        public string To { get; set; }

        public decimal ConNum { get; set; }

        public string GetDisplayText() =>
            From + "|" + To + "|" + ConNum;

        public string GetComboText() =>
            From + " to " + To;
    }
}
