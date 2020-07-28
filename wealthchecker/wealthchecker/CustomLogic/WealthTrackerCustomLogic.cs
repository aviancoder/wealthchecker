using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wealthchecker.Data;

namespace wealthchecker.CustomLogic
{
    public class WealthTrackerCustomLogic
    {
        private int RetirementAge = 65;
        private double inflationRate = 0.03;

        public void FillUpKiwiData()
        {
            // Salary Now
            double salaryNow = WealthTrackerOutputModel.BasicDetails.ClientGrossIncome + WealthTrackerOutputModel.BasicDetails.SpouseGrossIncome;
            // Kiwi Saver Now
            WealthTrackerOutputModel.KiwiSaverAmount = WealthTrackerOutputModel.BasicDetails.ClientKiwiSaver + WealthTrackerOutputModel.BasicDetails.SpouseKiwiSaver;
            // Investment Rate
            WealthTrackerOutputModel.KiwiSaverAverageInvestmentRate = 0.06;

            //Years to Retirement
            int clientAge = GetAge(WealthTrackerOutputModel.BasicDetails.ClientDateOfBirth);
            int spouseAge = GetAge(WealthTrackerOutputModel.BasicDetails.SpouseDateOfBirth);

            if (clientAge > spouseAge)
                WealthTrackerOutputModel.YearsToRetirement = RetirementAge - spouseAge;
            else
                WealthTrackerOutputModel.YearsToRetirement = RetirementAge - clientAge;

            // Average Life Expectancy
            WealthTrackerOutputModel.LifeExpectancyAverage = 91.5;
            // Average Total Living Expenses
            WealthTrackerOutputModel.TotalLivingExpensesAverage = 650 * 52 * (WealthTrackerOutputModel.LifeExpectancyAverage - RetirementAge);
            // Super Amount
            WealthTrackerOutputModel.TotalSuperAmount = 375 * 52 * (WealthTrackerOutputModel.LifeExpectancyAverage - RetirementAge);
            // Estimated KiwiSaver at 65
            List<KiwiSaverData> klist = GetKiwiSaverTable(salaryNow);
            WealthTrackerOutputModel.KiwiSaverData = klist;
            var kdata = klist.Where(x => x.YearsToRetire == WealthTrackerOutputModel.YearsToRetirement).FirstOrDefault();
            WealthTrackerOutputModel.EstimatedTotalKiwiSaverAmount = kdata.CumulativeKiwiSaver;
            // Surplus and Shortfall
            WealthTrackerOutputModel.SurplusShortfallAmount = WealthTrackerOutputModel.TotalSuperAmount + WealthTrackerOutputModel.KiwiSaverTotalAtRetirement - WealthTrackerOutputModel.TotalLivingExpensesAverage;
            WealthTrackerOutputModel.KiwiSaverTotalAtRetirement = WealthTrackerOutputModel.EstimatedTotalKiwiSaverAmount;
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

            for (int i = 1; i <= 45; i++)
            {
                KiwiSaverData data = new KiwiSaverData();

                data.YearsToRetire = i;
                data.CombinedSalary = cumulativeCombinedSalary;
                // update cumulativeCombinedSalary
                cumulativeCombinedSalary += cumulativeCombinedSalary * inflationRate;
                data.CumulativeKiwiSaver = cumulativeKiwiSaver;
                // update cumulativeKiwiSaver
                cumulativeKiwiSaver += cumulativeKiwiSaver * WealthTrackerOutputModel.KiwiSaverAverageInvestmentRate;
                retval.Add(data);
            }

            return retval;
        }


    }
}
