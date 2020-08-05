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
        //General

        //Annual Income
        public static double TotalAnnualIncome { get; set; }
        public static double YearsToRetirement { get; set; }
        public static double InflationRate { get; set; }
        public static double AnnualIncomeForRetirement { get; set; }
        public static double LessPension { get; set; }
        public static double TotalAnnualIncomeForRetirement { get; set; }

        //Cash
        public static double CurrentCashSavings { get; set; }
        public static double AnnualCashSavingsContributions { get; set; }
        public static double CashSavingsInterestRate { get; set; }
        public static double TotalCashSavingsAtRetirement { get; set; }
        public static List<CashSavingsData> CashSavingsList { get; set; }

        //Shares/Business
        public static double CurrentShareBusiness { get; set; }
        public static double ShareBusinessGrowthRate { get; set; }
        public static double TotalShareBusinessAtRetirement { get; set; }
        public static List<ShareBusinessData> ShareBusinessList { get; set; }

        //Property
        public static double CurrentProperty { get; set; }
        public static double CurrentMortgage { get; set; }
        public static double CurrentInvestmentRate { get; set; }
        public static double AnnualAppreciationRate { get; set; }
        public static double YearsToRepayMortgage { get; set; }
        public static double NetHomeVallueAtRetirement { get; set; }

        public static BasicDetails BasicDetails { get; set; }
        public static double KiwiSaverAmount { get; set; }
        public static double KiwiSaverContributions { get; set; }
        public static double KiwiSaverGrowth { get; set; }
        public static double KiwiSaverTotalAtRetirement { get; set; }
        public static double KiwiSaverAverageInvestmentRate { get; set; }
        public static double KiwiSaverEmployeeContribution { get; set; }
        public static double KiwiSaverEmployerContribution { get; set; }
        //91.6 hardcoded for now LifeExpectancyAverage
        public static double LifeExpectancyAverage { get; set; }
        public static double TotalLivingExpensesAverage { get; set; }
        public static double TotalSuperAmount { get; set; }
        public static double EstimatedTotalKiwiSaverAmount { get; set; }
        public static double SurplusShortfallAmount { get; set; }
        public static List<KiwiSaverData> KiwiSaverList { get; set; }

        // Current Assets
        public static List<CurrentAssetsData> CurrentAssetsList { get; set; }

        // Financial Goal
        public static List<FinancialGoalData> FinancialGoalList { get; set; }
    }
}
