using Experimental.Helpers;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Experimental.ViewModels
{
    public class sd_calculateViewModel :BaseClass
    {
        public sd_calculateViewModel()
        {
            CalculateCommand = new RelayCommand(() => calculateAsync());
            BodyMassIndex = 0;
            BMIresult = "Click calculate to generate Report";
        }

        private  async Task calculateAsync()
        {
            await Task.Run(() =>
            {
                GetBMIResultReport(BodyMassIndex);
            });
        }

        private void GetBMIResultReport(double bodyMassIndex)
        {
            string reportResult = "";
            switch (bodyMassIndex)
            {
                case var index when bodyMassIndex >= 20 && bodyMassIndex < 15:
                    reportResult = "Very severely underweight";
                    break;
                case var index when bodyMassIndex >= 15 && bodyMassIndex <= 16:
                    reportResult = "Severely underweight";
                    break;
                case var index when bodyMassIndex > 16 && bodyMassIndex < 18.5:
                    reportResult = "Underweight";
                    break;
                case var index when bodyMassIndex>=18.5 && bodyMassIndex<25:
                    reportResult = "normal";
                    break;
                case var index when bodyMassIndex >= 25 && bodyMassIndex < 30:
                    reportResult = "Overweight";
                    break;
                case var index when bodyMassIndex >= 30 && bodyMassIndex < 35:
                    reportResult = "Obese Class I (Moderately obese)";
                    break;
                case var index when bodyMassIndex >= 35 && bodyMassIndex < 40:
                    reportResult = "Obese Class II (Severely obese)";
                    break;
                default:
                    reportResult = "there was an error";
                    break;
            }

            BMIresult = reportResult;
        }

        /* Commands */
        public RelayCommand CalculateCommand { get; set; }
        /* Properties */
        private double _height;

        public double Height
        {
            get { return _height; }
            set { _height = value;
                OnPropertyChanged();
                OnPropertyChanged("BodyMassIndex");
            }
        }

        private double _weight;

        public double Weight
        {
            get { return _weight; }
            set { _weight = value;
                OnPropertyChanged();
                OnPropertyChanged("BodyMassIndex");
            }
        }

        private double _bodyMassIndex;

        public double BodyMassIndex
        {
            get {
                if (Weight == 0 || Height == 0)
                {
                    return 0;
                }
                else
                {
                    return Math.Round((Weight / Math.Pow(Height, 2)), 2);
                }
                 }
            set { _bodyMassIndex = value;
                OnPropertyChanged();
            }
        }

        private string _bMIresult;

        public string BMIresult
        {
            get { return _bMIresult; }
            set { _bMIresult = value;
                OnPropertyChanged();
            }
        }
    }
}
