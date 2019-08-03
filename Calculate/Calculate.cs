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
       
            return Math.Round(((decimal)NumberOfDays * (decimal)AverageDrinksPerDay * AverageCostPerDrink), 2);
        }

        public static decimal ConvertTodecimal(string input)
        {
            return 0m;
        }
    }
}
