using Experimental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Experimental.Views
{
    /// <summary>
    /// Interaction logic for sd_calculate.xaml
    /// </summary>
    public partial class sd_calculate : UserControl
    {
        public sd_calculate()
        {
            InitializeComponent();
            this.DataContext = new sd_calculateViewModel();
        }
    }
}
