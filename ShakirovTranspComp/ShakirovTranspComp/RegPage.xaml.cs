
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ShakirovTranspComp
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private async void RegistarationButton_Click(object sender, RoutedEventArgs e)
        {
            if (FioBox.Text != string.Empty && PhoneBox.Text != string.Empty && PasswordBox.Text != string.Empty && RepeatPasswordBox.Text != string.Empty)
            {
                if (PasswordBox.Text == RepeatPasswordBox.Text)
                {
                    if (await DataBase.RegistrationAsync(FioBox.Text, PhoneBox.Text, PasswordBox.Text))
                    {
                        MessageBox.Show("Регистрация прошла успешно!");
                        Manager.mainFrame.Navigate(new AuthPage());
                    }
                    else MessageBox.Show("Что-то пошло не так");
                }
                else MessageBox.Show("Пароли не совпадают");
            }
            else MessageBox.Show("Введите все данные");
        }

        private void toAuthorixation_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Manager.mainFrame.Navigate(new AuthPage());
        }
    }
}
