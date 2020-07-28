using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wealthchecker.Models;

namespace wealthchecker.Data
{
    public static class WealthTrackerOutputModel
    {
        public static BasicDetails BasicDetails { get; set; }
        public static double KiwiSaverAmount { get; set; }
        public static double KiwiSaverContributions { get; set; }
        public static double KiwiSaverGrowth { get; set; }
        public static double KiwiSaverTotalAtRetirement { get; set; }
        public static double InflationRate { get; set; }
        public static double KiwiSaverAverageInvestmentRate { get; set; }
        public static double KiwiSaverEmployeeContribution { get; set; }
        public static double KiwiSaverEmployerContribution { get; set; }
        public static double YearsToRetirement { get; set; }
        //91.6
        public static double LifeExpectancyAverage { get; set; }
        public static double TotalLivingExpensesAverage { get; set; }
        public static double TotalSuperAmount { get; set; }
        public static double EstimatedTotalKiwiSaverAmount { get; set; }
        public static double SurplusShortfallAmount { get; set; }
        public static List<KiwiSaverData> KiwiSaverData { get; set; }
    }
}
