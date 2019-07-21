using Experimental.Helpers;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            DoWorkCommand = new RelayCommand(() => { Task t = DoWorkcommandAsync(); });
            Value = 0d;
            Text = "ProgressBarLab Experiments";
            Chrono = "Ready";
            ButtonIsEnabled = true;
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

        private string _textInfo;

        public string TextInfo
        {
            get { return _textInfo; }
            set
            {
                if (_textInfo != value)
                {
                    _textInfo = value;
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

        private string _chrono;

        public string Chrono
        {
            get { return _chrono; }
            set
            {
                if (_chrono!= value)
                {
                    _chrono = value;
                    OnPropertyChanged();
                }
            }
        }
        public Task t1 { get; set; }
        public Task t2 { get; set; }

        private bool _buttonIsenabled;

        public bool ButtonIsEnabled
        {
            get { return _buttonIsenabled; }
            set
            {
                if (_buttonIsenabled!=value)
                {
                    _buttonIsenabled = value;
                    OnPropertyChanged();
                }
                
            }
        }




        private async Task DoWorkcommandAsync()
        {
            Task.Run(() => ButtonIsEnabled = false );
            
            Stopwatch stopWatch = new Stopwatch();
            Chrono = "Start !!!";
            
            stopWatch.Reset();
            stopWatch.Start();

            var t1 =  Task.Run(() =>

             {
                 for (int i = 0; i < 100; i++)
                 {
                     TextInfo = i.ToString() + " " + "YEAHHHHHHH Baby ";
                     Thread.Sleep(100);
                 }

                 TextInfo = TextInfo + " " + "<--- Now I'm done!";

             });

            var t2 = Task.Run(() =>
            {
                Value = 0;
                MinimumValue = 0;
                for (double i = 0; i <= 100; i = i + 1)
                {
                    Value = i;
                    Text = i.ToString();
                    Thread.Sleep(70);
                }
            });

            await Task.WhenAll(t1, t2);

            stopWatch.Stop();
            double time = stopWatch.ElapsedMilliseconds / 1000;
            Chrono = "Done in " + time.ToString() + " seconds";

            await Task.Run(() => ButtonIsEnabled = true);
            
        }

    }

    
}
