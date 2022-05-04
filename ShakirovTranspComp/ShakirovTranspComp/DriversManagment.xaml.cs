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
    /// Логика взаимодействия для DriversManagment.xaml
    /// </summary>
    public partial class DriversManagment : Page
    {
        Drivers selected;
        public DriversManagment()
        {
            InitializeComponent();

            GridViewColumn c1 = new GridViewColumn { Header = "ФИО" };
            c1.DisplayMemberBinding = new Binding("User.fio");
            GridViewColumn c2 = new GridViewColumn { Header = "Телефон" };
            c2.DisplayMemberBinding = new Binding("User.phone");
            GridViewColumn c3 = new GridViewColumn { Header = "Пароль" };
            c3.DisplayMemberBinding = new Binding("User.password");

            DriversCollection.Columns.Add(c1);
            DriversCollection.Columns.Add(c2);
            DriversCollection.Columns.Add(c3);

            RefreshList();
        }

        public async Task<bool> RefreshList()
        {
            DriversList.ItemsSource = await DataBase.GetDriverList();
            return true;
        }

        private void DriversList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selected = DriversList.SelectedItem as Drivers;

            if (selected != null)
            {
                BoxFIO.Text = selected.User.fio;
                BoxPhone.Text = selected.User.phone;
                BoxPassword.Text = selected.User.password;
            }
            else
            {
                DriversList.SelectedIndex = 0;
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DataBase.DeleteDriver(selected);

            await Task.Delay(200);

            await RefreshList();
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (BoxFIO.Text != string.Empty && BoxPhone.Text != string.Empty && BoxPassword.Text != string.Empty)
            {
                Drivers updated = new Drivers();
                updated.User = new User();
                updated.User.phone = BoxPhone.Text;
                updated.User.fio = BoxFIO.Text;
                updated.User.password = BoxPassword.Text;

                DataBase.UpdateDriver(selected, updated);

                await Task.Delay(200);

                await RefreshList();
            }
            else MessageBox.Show("Все данные должны быть введены");
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            AddBoxFIO.Text = string.Empty;
            AddBoxPhone.Text = string.Empty;
            AddBoxPassword.Text = string.Empty;
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddBoxFIO.Text != string.Empty && AddBoxPhone.Text != string.Empty && AddBoxPassword.Text != string.Empty)
            {
                Drivers add = new Drivers();

                add.User = new User();
                add.User.phone = AddBoxPhone.Text;
                add.User.fio = AddBoxFIO.Text;
                add.User.password = AddBoxPassword.Text;

                DataBase.AddDriver(add);

                await Task.Delay(200);

                await RefreshList();
            }
            else MessageBox.Show("Все данные должны быть введены");

        }
    }
}
