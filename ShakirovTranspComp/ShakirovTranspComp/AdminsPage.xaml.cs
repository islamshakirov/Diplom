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
    /// Логика взаимодействия для AdminsPage.xaml
    /// </summary>
    public partial class AdminsPage : Page
    {
        public AdminsPage()
        {
            InitializeComponent();
        }

        private void AutoParkButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new AutoManagment());
        }

        private void DriversButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new DriversManagment());
        }
    }
}
