using Experimental.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimental.ViewModels
{
    public class SD_ProgressViewModel: BaseClass
    {
        public SD_ProgressViewModel()
        {
            SetDefaultValues();
            
        }

        private void SetDefaultValues()
        {
            StartDate = new DateTime(2019, 7, 21);
            AverageDrinksPerDay = (decimal)33 / 7;
            AverageCostPerDrink = 1.5M;
            AverageLitersPerDrink = 0.5M;
            AverageEmptyCaloriesPerLiter = 215 * 2;
            InitialWeight = 67.5M;
        }

        public DateTime StartDate { get; set; }

        public int NumberOfDays
        {
            get { return (int)(DateTime.Now - StartDate).TotalDays; }
        }

        private decimal _moneySaved;

        public decimal MoneySaved
        {
            get { return Math.Round(((decimal)NumberOfDays * (decimal)AverageDrinksPerDay * AverageCostPerDrink),2); }
            set { _moneySaved = value; }
        }
        private decimal _numberOfDrinksSpared;

        public decimal NumberOfDrinksSpared
        {
            get { return Math.Round((NumberOfDays * AverageDrinksPerDay), 2); }
            set { _numberOfDrinksSpared = value; }
        }

        private decimal _numberOfLitresSpared;

        public decimal NumberOfLitresSpared
        {
            get { return Math.Round((AverageDrinksPerDay * AverageLitersPerDrink * NumberOfDays), 2); }
            set { _numberOfLitresSpared = value; }
        }

        private decimal _numberOfCaloriesSpared;

        public decimal NumberOfCaloriesSpared
        {
            get { return Math.Round((NumberOfDays * AverageLitersPerDrink * AverageDrinksPerDay * AverageEmptyCaloriesPerLiter), 2); }
            set { _numberOfCaloriesSpared = value; }
        }

        public decimal AverageDrinksPerDay { get; set; }
        public decimal AverageCostPerDrink { get; set; }
        public decimal AverageLitersPerDrink { get; set; }
        public decimal AverageEmptyCaloriesPerLiter { get; set; }
        public decimal InitialWeight { get; set; }

    }
}
