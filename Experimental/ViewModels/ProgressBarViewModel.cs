using Experimental.Helpers;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Experimental.ViewModels
{
    public class ProgressBarViewModel :BaseClass
    {
        public ProgressBarViewModel()
        {
            DoWorkCommand = new RelayCommand(() => { var task = DoWorkcommand(); });
            Value = 0d;
            Text = "ProgressBarLab";
        }

        public RelayCommand DoWorkCommand { get; set; }
        private double _value;

        public double Value
        {
            get { return _value; }
            set
            {
                if (_value!=value)
                {
                    _value = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _text;

        public string Text
        {
            get { return _text; }
            set
            {
                if (_text!=value)
                {
                    _text = value;
                    OnPropertyChanged();
                }
            }
        }


        private double _minimumValue;

        public double MinimumValue
        {
            get { return _minimumValue; }
            set
            {
                if (_minimumValue!=value)
                {
                    _minimumValue = value;
                    OnPropertyChanged();
                }
            }
        }

        private async Task DoWorkcommand()
        {
            await Task.Run(() => 
            {
                Value = 0;
                MinimumValue = 0;
                for (double i = 0; i <= 100; i = i + 2)
                {
                    Value = i;
                    Text = i.ToString();
                    Thread.Sleep(300);
                }
            });
           
        }

    }

    
}
