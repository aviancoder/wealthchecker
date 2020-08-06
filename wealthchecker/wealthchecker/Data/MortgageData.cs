using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wealthchecker.Data
{
    public class MortgageData
    {
        public int RepaymentsYear { get; set; }
        public double EndingBalance { get; set; }
        public double Payment { get; set; }
        public double Principal { get; set; }
        public double Interest { get; set; }
    }
}
