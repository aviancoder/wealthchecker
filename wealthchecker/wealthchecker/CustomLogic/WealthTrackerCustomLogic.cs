using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using wealthchecker.Data;

namespace wealthchecker.CustomLogic
{
    public class WealthTrackerCustomLogic
    {
        //private int RetirementAge = 65;
        //private double inflationRate = 0.03;
        private double defaultPensionAmount = 32892;

        public void FillUpGeneralData(int _retirementAge)
        {

            //Years to Retirement
            int clientAge = GetAge(WealthTrackerOutputModel.BasicDetails.ClientDateOfBirth);
            int spouseAge = GetAge(WealthTrackerOutputModel.BasicDetails.SpouseDateOfBirth);

            if (clientAge > spouseAge)
                WealthTrackerOutputModel.YearsToRetirement = _retirementAge - spouseAge;
            else
                WealthTrackerOutputModel.YearsToRetirement = _retirementAge - clientAge;
            // Average Life Expectancy
            WealthTrackerOutputModel.LifeExpectancyAverage = 91.5;
        }

        public void FillUpIncomeData(double _inflationRate)
        {
            double salaryNow = WealthTrackerOutputModel.BasicDetails.ClientGrossIncome + WealthTrackerOutputModel.BasicDetails.SpouseGrossIncome;
            WealthTrackerOutputModel.TotalAnnualIncome = salaryNow;
            WealthTrackerOutputModel.InflationRate = _inflationRate;
            WealthTrackerOutputModel.AnnualIncomeForRetirement = GetFutureValue(WealthTrackerOutputModel.TotalAnnualIncome, WealthTrackerOutputModel.InflationRate, (int)WealthTrackerOutputModel.YearsToRetirement);
            WealthTrackerOutputModel.LessPension = GetFutureValue(defaultPensionAmount, WealthTrackerOutputModel.InflationRate, (int)WealthTrackerOutputModel.YearsToRetirement);
            WealthTrackerOutputModel.TotalAnnualIncomeForRetirement = WealthTrackerOutputModel.AnnualIncomeForRetirement - WealthTrackerOutputModel.LessPension;
        }

        public void FillUpCashSavings(double _annualCashSavingsContribution, double _interestRate)
        {
            WealthTrackerOutputModel.CurrentCashSavings = WealthTrackerOutputModel.BasicDetails.ClientCashSavings + WealthTrackerOutputModel.BasicDetails.SpouseCashSavings;
            WealthTrackerOutputModel.AnnualCashSavingsContributions = _annualCashSavingsContribution;
            WealthTrackerOutputModel.CashSavingsInterestRate = _interestRate;
            WealthTrackerOutputModel.CashSavingsList = GetCashSavingsTable();

            var maxItem = WealthTrackerOutputModel.CashSavingsList.Where(x => x.YearsToRetire == WealthTrackerOutputModel.YearsToRetirement).FirstOrDefault();
            WealthTrackerOutputModel.TotalCashSavingsAtRetirement = maxItem.CumulativeCashSavings;
        }

        public void FillUpSharesBusiness(double _growthRate)
        {
            WealthTrackerOutputModel.CurrentShareBusiness = WealthTrackerOutputModel.BasicDetails.ClientShareInvestments + WealthTrackerOutputModel.BasicDetails.SpouseShareInvestments;
            WealthTrackerOutputModel.ShareBusinessGrowthRate = _growthRate;
            WealthTrackerOutputModel.ShareBusinessList = GetShareBusinessTable();

            var maxItem = WealthTrackerOutputModel.ShareBusinessList.Where(x => x.YearsToRetire == WealthTrackerOutputModel.YearsToRetirement).FirstOrDefault();
            WealthTrackerOutputModel.TotalShareBusinessAtRetirement = maxItem.CumulativeShareBusiness;
        }

        public void FillUpKiwiData()
        {
            // Kiwi Saver Now
            WealthTrackerOutputModel.KiwiSaverAmount = WealthTrackerOutputModel.BasicDetails.ClientKiwiSaver + WealthTrackerOutputModel.BasicDetails.SpouseKiwiSaver;
            // Investment Rate
            WealthTrackerOutputModel.KiwiSaverAverageInvestmentRate = 0.06;
            // Average Total Living Expenses
            WealthTrackerOutputModel.TotalLivingExpensesAverage = 650 * 52 * (WealthTrackerOutputModel.LifeExpectancyAverage - WealthTrackerOutputModel.YearsToRetirement);
            // Super Amount
            WealthTrackerOutputModel.TotalSuperAmount = 375 * 52 * (WealthTrackerOutputModel.LifeExpectancyAverage - WealthTrackerOutputModel.YearsToRetirement);
            // Estimated KiwiSaver at 65
            List<KiwiSaverData> klist = GetKiwiSaverTable(WealthTrackerOutputModel.TotalAnnualIncome);
            WealthTrackerOutputModel.KiwiSaverList = klist;
            var kdata = klist.Where(x => x.YearsToRetire == WealthTrackerOutputModel.YearsToRetirement).FirstOrDefault();
            WealthTrackerOutputModel.EstimatedTotalKiwiSaverAmount = kdata.CumulativeKiwiSaver;
            // Surplus and Shortfall
            WealthTrackerOutputModel.SurplusShortfallAmount = WealthTrackerOutputModel.TotalSuperAmount + WealthTrackerOutputModel.KiwiSaverTotalAtRetirement - WealthTrackerOutputModel.TotalLivingExpensesAverage;
            WealthTrackerOutputModel.KiwiSaverTotalAtRetirement = WealthTrackerOutputModel.EstimatedTotalKiwiSaverAmount;
        }

        public void FillPropertyData(double _interestRate, double _annualAppreciationRate, int _yearsToRepayMortgage)
        {
            WealthTrackerOutputModel.CurrentProperty = WealthTrackerOutputModel.BasicDetails.ClientPropertyValue;
            WealthTrackerOutputModel.CurrentMortgage = WealthTrackerOutputModel.BasicDetails.ClientMortgage;
            WealthTrackerOutputModel.CurrentInteresttRate = _interestRate;
            WealthTrackerOutputModel.AnnualAppreciationRate = _annualAppreciationRate;
            WealthTrackerOutputModel.YearsToRepayMortgage = _yearsToRepayMortgage;
        }

        public void FillCurrentAssetsData()
        {

            List<CurrentAssetsData> dataList = new List<CurrentAssetsData>();
            List<CashSavingsData> csList = WealthTrackerOutputModel.CashSavingsList;
            List<ShareBusinessData> sbList = WealthTrackerOutputModel.ShareBusinessList;
            List<KiwiSaverData> kList = WealthTrackerOutputModel.KiwiSaverList;
            for (int i = 1; i <= WealthTrackerOutputModel.YearsToRetirement; i++)
            {

                var csData = csList.Where(x => x.YearsToRetire == i).FirstOrDefault();
                var sbData = sbList.Where(x => x.YearsToRetire == i).FirstOrDefault();
                var kData = kList.Where(x => x.YearsToRetire == i).FirstOrDefault();

                double currentAssetAmount = csData.CumulativeCashSavings + sbData.CumulativeShareBusiness + kData.CumulativeKiwiSaver;
                CurrentAssetsData data = new CurrentAssetsData();
                data.YearsToRetire = i;
                data.CumulativeCurrentAssets = currentAssetAmount;
                dataList.Add(data);
            }
            WealthTrackerOutputModel.CurrentAssetsList = dataList;
        }

        public void FillFinancialGoalData()
        {

            List<FinancialGoalData> dataList = new List<FinancialGoalData>();
            List<CurrentAssetsData> caList = WealthTrackerOutputModel.CurrentAssetsList;

            for (int i = 1; i <= WealthTrackerOutputModel.YearsToRetirement; i++)
            {

                var caData = caList.Where(x => x.YearsToRetire == i).FirstOrDefault();

                double financialGoal = caData.CumulativeCurrentAssets * 2;
                FinancialGoalData data = new FinancialGoalData();
                data.YearsToRetire = i;
                data.CumulativeFinancialGoal = financialGoal;
                dataList.Add(data);
            }
            WealthTrackerOutputModel.FinancialGoalList = dataList;
        }

        private int GetAge(DateTime birthdate)
        {
            // Save today's date.
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - birthdate.Year;

            // Go back to the year the person was born in case of a leap year
            if (birthdate.Date > today.AddYears(-age)) age--;

            return age;
        }

        public List<KiwiSaverData> GetKiwiSaverTable(double _salaryNow)
        {
            List<KiwiSaverData> retval = new List<KiwiSaverData>();

            double cumulativeCombinedSalary = _salaryNow;
            double cumulativeKiwiSaver = WealthTrackerOutputModel.KiwiSaverAmount + (WealthTrackerOutputModel.KiwiSaverAmount * WealthTrackerOutputModel.KiwiSaverAverageInvestmentRate);

            for (int i = 1; i <= WealthTrackerOutputModel.YearsToRetirement; i++)
            {
                KiwiSaverData data = new KiwiSaverData();

                data.YearsToRetire = i;
                data.CombinedSalary = cumulativeCombinedSalary;
                // update cumulativeCombinedSalary
                cumulativeCombinedSalary += cumulativeCombinedSalary * WealthTrackerOutputModel.InflationRate;
                data.CumulativeKiwiSaver = cumulativeKiwiSaver;
                // update cumulativeKiwiSaver
                cumulativeKiwiSaver += cumulativeKiwiSaver * WealthTrackerOutputModel.KiwiSaverAverageInvestmentRate;
                retval.Add(data);
            }

            return retval;
        }

        public List<CashSavingsData> GetCashSavingsTable()
        {
            List<CashSavingsData> retval = new List<CashSavingsData>();
            double cumulativeCashSavings = (WealthTrackerOutputModel.CurrentCashSavings + WealthTrackerOutputModel.AnnualCashSavingsContributions)
                + ((WealthTrackerOutputModel.CurrentCashSavings + WealthTrackerOutputModel.AnnualCashSavingsContributions) * WealthTrackerOutputModel.CashSavingsInterestRate);
            for (int i = 1; i <= WealthTrackerOutputModel.YearsToRetirement; i++)
            {
                CashSavingsData data = new CashSavingsData();
                data.YearsToRetire = i;
                data.CumulativeCashSavings = cumulativeCashSavings;
                retval.Add(data);
                // update cumulative cash savings
                cumulativeCashSavings = (cumulativeCashSavings + WealthTrackerOutputModel.AnnualCashSavingsContributions)
                + ((cumulativeCashSavings + WealthTrackerOutputModel.AnnualCashSavingsContributions) * WealthTrackerOutputModel.CashSavingsInterestRate);
            }
            return retval;
        }

        public List<ShareBusinessData> GetShareBusinessTable()
        {
            List<ShareBusinessData> retval = new List<ShareBusinessData>();
            double cumulativeShareBusiness = (WealthTrackerOutputModel.CurrentShareBusiness) + (WealthTrackerOutputModel.CurrentShareBusiness * WealthTrackerOutputModel.ShareBusinessGrowthRate);
            for (int i = 1; i <= WealthTrackerOutputModel.YearsToRetirement; i++)
            {
                ShareBusinessData data = new ShareBusinessData();
                data.YearsToRetire = i;
                data.CumulativeShareBusiness = cumulativeShareBusiness;
                retval.Add(data);
                // update cumulative cash savings
                cumulativeShareBusiness = (cumulativeShareBusiness) + (cumulativeShareBusiness * WealthTrackerOutputModel.ShareBusinessGrowthRate);
            }
            return retval;
        }

        public double GetFutureValue(double _presentValue, double _interestRate, int _numberOfYears)
        {
            double retval = _presentValue;
            double finalRate = 1 + _interestRate;
            for (int i = 1; i < _numberOfYears; i++)
            {
                finalRate = finalRate * (1 + _interestRate);
            }
            retval = _presentValue * finalRate;
            return retval;
        }

        public List<MortgageData> GenerateMortgageTable(double _mortgageAmount, double _interestRate, int _numberOfYears)
        {
            List<MortgageData> retval = new List<MortgageData>();

            double endingBalance = _mortgageAmount;

            return retval;
        }

        public double GetMonthlyPayment(double _presentValue, double _interestRate, int _numberOfYears)
        {
            double retval = _presentValue;


            return retval;
        }
    }
}
