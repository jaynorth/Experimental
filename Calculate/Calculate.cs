using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    public static class Calculate
    {

        public static decimal MoneySavedCalc(decimal NumberOfDays, decimal AverageDrinksPerDay, decimal AverageCostPerDrink)
        {
       
            return Math.Round((NumberOfDays * AverageDrinksPerDay * AverageCostPerDrink), 2);
        }

        public static decimal MoneySavedCalc(string NumberOfDays, string AverageDrinksPerDay, string AverageCostPerDrink)
        {
            decimal value = 0m;
            try
            {
                var _numberOfDays = ConvertTodecimal(NumberOfDays);
                var _averageDrinksPerDay = ConvertTodecimal(AverageDrinksPerDay);
                var _averageCostPerDrink = ConvertTodecimal(AverageCostPerDrink);
                value = Math.Round((_numberOfDays * _averageDrinksPerDay * _averageCostPerDrink), 2);
            }
            catch (System.FormatException fe)
            {

                throw new FormatException("Incorrect format :" + fe.Message);
            }

            return value;
            
        }

        public static DateTime ReturnFireDate(string amountInvested, string monthlyContribution, string monthlyProjectedspendings, string impotSource, string withdrawalRatePercent, string averageYearlyReturnPercent)
        {
            decimal AmountInvested = ConvertTodecimal(amountInvested);
            decimal MonthlyContribution = ConvertTodecimal(monthlyContribution);
            decimal MonthlyProjectedspendings = ConvertTodecimal(monthlyProjectedspendings);
            decimal ImpotSource = ConvertTodecimal(impotSource);
            decimal WithdrawalRatePercent = ConvertTodecimal(withdrawalRatePercent);
            decimal AverageYearlyReturnPercent = ConvertTodecimal(averageYearlyReturnPercent);

            decimal FireCapitalRequired = GetFireCapitalRequired(MonthlyProjectedspendings, WithdrawalRatePercent);
            Console.WriteLine("Fire Capital required : {0}", FireCapitalRequired);

            decimal accumulatedCapital = AmountInvested;

            int months = 0;
            int year = 0; 

            while (accumulatedCapital < FireCapitalRequired)
            {
                accumulatedCapital = accumulatedCapital + MonthlyContribution;
                months++;
                if (months%12 ==0)
                {
                    var benefits = accumulatedCapital * (AverageYearlyReturnPercent / 100);
                    /* Impots sur dividendes  */
                    decimal dividendesYield = 2.05m;/* en pourcent*/
                    var dividendes = accumulatedCapital * dividendesYield/100;
                    //var Impots = benefits * (ImpotSource / 100);
                    var Impots = dividendes * (ImpotSource / 100);
                    benefits = benefits - Impots;
                    accumulatedCapital = accumulatedCapital + benefits;
                    year++;
                    Console.WriteLine("Year {0} capital {1} benefits {2}", year, Math.Round(accumulatedCapital, 0), Math.Round(benefits, 2));
                }
            }

            var today = DateTime.Now;

            DateTime FireDate = today.AddMonths(months);

            var ThenbenefitsPerYear = Math.Round(accumulatedCapital * (AverageYearlyReturnPercent / 100), 2);
            var ThenbenefitsPerMonth = Math.Round((accumulatedCapital * (AverageYearlyReturnPercent / 100))/12, 2);

            Console.WriteLine();
            Console.WriteLine("Capital : {0} Benefits Per Year {1} Benefits Per Month {2}", Math.Round(accumulatedCapital, 0), ThenbenefitsPerYear, ThenbenefitsPerMonth);

            return FireDate;
        }

        private static decimal GetFireCapitalRequired(decimal monthlyProjectedspendings, decimal withdrawalRatePercent)
        {
            var capital = monthlyProjectedspendings * 12  * (100 / withdrawalRatePercent);
            return capital;
        }

        public static decimal ConvertTodecimal(decimal input)
        {
            //var value = decimal.Parse(input);
            return input;
        }

        public static decimal ConvertTodecimal(string input)
        {
            var value = decimal.Parse(input);
            return value;
        }


    }
}
