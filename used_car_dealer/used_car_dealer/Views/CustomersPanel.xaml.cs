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
using used_car_dealer.ViewModels;

namespace used_car_dealer.Views
{
    /// <summary>
    /// Interaction logic for CustomersPanel.xaml
    /// </summary>
    public partial class CustomersPanel: UserControl
    {
        public CustomersPanel(CustomersPanelViewModel customersPanelViewModel)
        {
            InitializeComponent();
            DataContext = customersPanelViewModel;
        }
    }
}
