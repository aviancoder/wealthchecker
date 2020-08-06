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
        public static double CurrentInteresttRate { get; set; }
        public static double AnnualAppreciationRate { get; set; }
        public static double YearsToRepayMortgage { get; set; }
        public static double NetHomeVallueAtRetirement { get; set; }

        public static BasicDetails BasicDetails { get; set; }
        public static double KiwiSaverAmount { get; set; }
        //public static double KiwiSaverContributions { get; set; }
        //public static double KiwiSaverGrowth { get; set; }
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

        // Net Assets
        public static double NetAssetsRequired { get; set; }
        public static double NetAssetsReturnOnInvestment { get; set; }
        public static double TotalNetAssetsRequired { get; set; }

        // Inheritance Investment
        public static YearAmountData ExpectedInheritance { get; set; }
        public static YearAmountData MaturingInvestment1 { get; set; }
        public static YearAmountData MaturingInvestment2 { get; set; }
        public static YearAmountData MaturingInvestment3 { get; set; }
        public static YearAmountData MaturingInvestment4 { get; set; }

        // Investment Properties 1
        public static double InvestmentProperty1PurchaseYear { get; set; }
        public static double InvestmentProperty1Value { get; set; }
        public static double InvestmentProperty1Debt { get; set; }
        public static double InvestmentProperty1RepaymentsBeginYear { get; set; }
        public static double InvestmentProperty1YearsToRepayDebt { get; set; }
        public static double InvestmentProperty1MonthlyRepayments { get; set; }
        public static double InvestmentProperty1NetHomeValueAtRetirement { get; set; }

        // Investment Properties 2
        public static double InvestmentProperty2PurchaseYear { get; set; }
        public static double InvestmentProperty2Value { get; set; }
        public static double InvestmentProperty2Debt { get; set; }
        public static double InvestmentProperty2RepaymentsBeginYear { get; set; }
        public static double InvestmentProperty2YearsToRepayDebt { get; set; }
        public static double InvestmentProperty2MonthlyRepayments { get; set; }
        public static double InvestmentProperty2NetHomeValueAtRetirement { get; set; }

        // Investment Properties 1
        public static double InvestmentProperty3PurchaseYear { get; set; }
        public static double InvestmentProperty3Value { get; set; }
        public static double InvestmentProperty3Debt { get; set; }
        public static double InvestmentProperty3RepaymentsBeginYear { get; set; }
        public static double InvestmentProperty3YearsToRepayDebt { get; set; }
        public static double InvestmentProperty3MonthlyRepayments { get; set; }
        public static double InvestmentProperty3NetHomeValueAtRetirement { get; set; }

        // Current Assets
        public static List<CurrentAssetsData> CurrentAssetsList { get; set; }

        // Financial Goal
        public static List<FinancialGoalData> FinancialGoalList { get; set; }
    }
}
