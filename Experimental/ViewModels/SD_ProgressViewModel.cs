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
            Init();
        }

        public DateTime StartDate { get; set; }

        public int NumberOfDays
        {
            get { return (int)(DateTime.Now - StartDate).TotalDays; }
        }

        private decimal _moneySaved;

        public decimal MoneySaved
        {
            get { return _moneySaved; }
            set { _moneySaved = value;
                if (_moneySaved!=value)
                {
                    _moneySaved = value;
                    OnPropertyChanged();
                }
            }
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
        //public decimal AverageCostPerDrink { get; set; }
        private decimal _averageCostPerDrink;

        public decimal AverageCostPerDrink
        {
            get { return _averageCostPerDrink; }
            set
            { 
                if (AverageCostPerDrink!=value)
                {
                    _averageCostPerDrink = value;
                    OnPropertyChanged();
                    MoneySaved = Calculate.Calculate.MoneySavedCalc(NumberOfDays, AverageDrinksPerDay, AverageCostPerDrink); //.MoneySavedCalc(NumberOfDays, AverageDrinksPerDay, AverageCostPerDrink);
                    OnPropertyChanged("MoneySaved");
                }
            }
        }

        public decimal AverageLitersPerDrink { get; set; }
        public decimal AverageEmptyCaloriesPerLiter { get; set; }
        public decimal InitialWeight { get; set; }
        public decimal UnitsPerWeek { get; set; }
        /* ProgressBar Level 1*/
        public decimal Level1Value { get; set; }
        public decimal Level1MinimumValue { get; set; }
        public decimal Level1MaximumValue { get; set; }
        /* ProgressBar Poop*/
        public decimal PoopValue { get; set; }
        public decimal PoopMinimumValue { get; set; }
        public decimal PoopMaximumValue { get; set; }

        private void Init()
        {
            SetDefaultValues();
            UpdateProgressBars();
        }

        private void UpdateProgressBars()
        {
            UpdateProgressBarLevel1();
            UpdateProgressBarPoop();
        }

        private void UpdateProgressBarPoop( )
        {
            PoopMinimumValue = 0;
            PoopMaximumValue = 30;
            if (NumberOfDays >= PoopMaximumValue)
            {
                PoopValue = PoopMaximumValue;
            }
            else
            {
                PoopValue = NumberOfDays;
            }
        }

        private void UpdateProgressBarLevel1()
        {
            Level1MinimumValue = 0;
            Level1MaximumValue = 17;
            if (NumberOfDays >= Level1MaximumValue)
            {
                Level1Value = Level1MaximumValue;
            }
            else
            {
                Level1Value = NumberOfDays;
            }
            Level1MinimumValue = 0;

        }

        private void SetDefaultValues()
        {
            StartDate = new DateTime(2020, 1, 07);
            AverageDrinksPerDay = (decimal)33 / 7;
            AverageCostPerDrink = Calculate.Calculate.ConvertTodecimal(1.4M);
            AverageLitersPerDrink = 0.5M;
            AverageEmptyCaloriesPerLiter = 215 * 2;
            InitialWeight = 67.5M;
            UnitsPerWeek = AverageDrinksPerDay * 7 * 1.8M;
            var RecommendedUnitsPerweek = 14;
 
        }


    }
}
