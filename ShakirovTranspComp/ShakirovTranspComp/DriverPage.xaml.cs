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

namespace ShakirovTranspComp
{
    /// <summary>
    /// Логика взаимодействия для DriverPage.xaml
    /// </summary>
    public partial class DriverPage : Page
    {
        Order currentDriversOrder = new Order();
        public DriverPage()
        {
            InitializeComponent();

            currentDriversOrder = DataBase.FindCurrentDriversOrder();

            if (currentDriversOrder.Transportation == null && currentDriversOrder.Moving == null)
                DriversFrame.Navigate(new FreeOrders(DriversFrame));
            else DriversFrame.Navigate(new SelectedDriversOrder(currentDriversOrder, DriversFrame));

        }
    }
}
