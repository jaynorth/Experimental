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
