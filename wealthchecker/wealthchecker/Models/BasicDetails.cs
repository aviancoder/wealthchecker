using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wealthchecker.Models
{
    public class BasicDetails
    {
        public string ClientName { get; set; }
        public string SpouseName { get; set; }
        public DateTime ClientDateOfBirth { get; set; }
        public DateTime SpouseDateOfBirth { get; set; }
        public double ClientGrossIncome { get; set; }
        public double SpouseGrossIncome { get; set; }
        public double ClientCashSavings { get; set; }
        public double SpouseCashSavings { get; set; }
        public double ClientKiwiSaver { get; set; }
        public double SpouseKiwiSaver { get; set; }
        public double ClientShareInvestments { get; set; }
        public double SpouseShareInvestments { get; set; }
        public double ClientPropertyValue { get; set; }
        public double ClientMortgage { get; set; }
    }
}
