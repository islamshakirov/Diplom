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
    /// Логика взаимодействия для OrderTypes.xaml
    /// </summary>
    public partial class OrderTypes : Page
    {
        public OrderTypes()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Manager.mainFrame.Navigate(new ArendOrder());
        }

        private void MovingClick_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Manager.mainFrame.Navigate(new MovingOrder());
        }

        private void DeliveryClick_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Manager.mainFrame.Navigate(new TranportationOrder());
        }
    }
}
