using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();

        }

        private async void AuthorizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (PhoneBox.Text != string.Empty && PasswordBox.Text != string.Empty)
            {
                User authorizingUser = await DataBase.AuthorizationAsync(PhoneBox.Text, PasswordBox.Text);

                if (authorizingUser != null)
                {
                    MainWindow main = new MainWindow();
                    if (authorizingUser.Client != null)
                    {
                        Manager.mainFrame.Navigate(new MainPage());
                        Manager.currentUser = authorizingUser;
                        Manager.currentUser.Client = authorizingUser.Client;
                    }
                    else if (authorizingUser.Admins != null)
                    {
                        Manager.mainFrame.Navigate(new AdminsPage());
                    }
                    else if (authorizingUser.Drivers != null)
                    {
                        Manager.currentUser = authorizingUser;
                        Manager.currentUser.Drivers = authorizingUser.Drivers;
                        Manager.mainFrame.Navigate(new DriverPage());
                    }
                    main.Show();

                    Manager.AuthWindow.Close();
                }
                else MessageBox.Show("Неверные номер или пароль");
            }
            else MessageBox.Show("Введите все данные");
        }

        private void Toregistration_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Manager.mainFrame.Navigate(new RegPage());
        }

       
    }
}
