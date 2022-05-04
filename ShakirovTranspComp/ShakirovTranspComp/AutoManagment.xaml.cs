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
    /// Логика взаимодействия для AutoManagment.xaml
    /// </summary>
    public partial class AutoManagment : Page
    {
        Transport selected;
        public AutoManagment()
        {
            InitializeComponent();

            BoxKind.ItemsSource = DataBase.GetContext().CarType.ToList();
            AddBoxKind.ItemsSource = DataBase.GetContext().CarType.ToList();

            GridViewColumn c1 = new GridViewColumn { Header = "Гос. номер"};
            c1.DisplayMemberBinding = new Binding("StateNum");
            GridViewColumn c2 = new GridViewColumn { Header = "Модель авто" };
            c2.DisplayMemberBinding = new Binding("automodel");
            GridViewColumn c3 = new GridViewColumn { Header = "Расход топлива" };
            c3.DisplayMemberBinding = new Binding("fuel");
            GridViewColumn c4 = new GridViewColumn { Header = "Грузоподъемность" };
            c4.DisplayMemberBinding = new Binding("capacity");
            GridViewColumn c5 = new GridViewColumn { Header = "Длина кузова" };
            c5.DisplayMemberBinding = new Binding("length");
            GridViewColumn c6 = new GridViewColumn { Header = "Свободна" };
            c6.DisplayMemberBinding = new Binding("busy");
            GridViewColumn c7 = new GridViewColumn { Header = "Вид авто" };
            c7.DisplayMemberBinding = new Binding("kind");

            AutoCollection.Columns.Add(c1);
            AutoCollection.Columns.Add(c2);
            AutoCollection.Columns.Add(c3);
            AutoCollection.Columns.Add(c4);
            AutoCollection.Columns.Add(c5);
            AutoCollection.Columns.Add(c6);
            AutoCollection.Columns.Add(c7);

            RefreshList();

        }

        public async Task<bool> RefreshList()
        {
            AutoList.ItemsSource = await DataBase.GetAutoList();
            return true;
        }

        private void AutoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selected = AutoList.SelectedItem as Transport;

            if (selected != null)
            {
                BoxStateNum.Text = selected.StateNum;
                BoxModel.Text = selected.automodel;
                BoxFuel.Text = selected.fuel.ToString();
                BoxCapacity.Text = selected.capacity.ToString();
                BoxLength.Text = selected.length.ToString();
                BoxIsBusy.Text = selected.busy.ToString();
                BoxKind.SelectedItem = selected.CarType;
            }
            else
            {
                AutoList.SelectedIndex = 0;
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DataBase.DeleteAuto(selected);

            await Task.Delay(200);

            await RefreshList();
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (BoxStateNum.Text != string.Empty && BoxModel.Text != string.Empty && BoxFuel.Text != string.Empty && BoxCapacity.Text != string.Empty && BoxLength.Text != string.Empty && BoxIsBusy.Text != string.Empty)
            {
                CarType aKind = BoxKind.SelectedItem as CarType;
                Transport updated = new Transport
                {
                    StateNum = BoxStateNum.Text,
                    automodel = BoxModel.Text,
                    fuel = Convert.ToInt32(BoxFuel.Text),
                    capacity = Convert.ToInt32(BoxCapacity.Text),
                    length = Convert.ToInt32(BoxLength.Text),
                    busy = Convert.ToByte(BoxIsBusy.Text),
                    kind = aKind.id,
                    CarType = aKind
                };

                DataBase.UpdateAuto(selected, updated);

                await Task.Delay(200);

                await RefreshList();
            }
            else MessageBox.Show("Все данные должны быть введены");
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
          if (AddBoxStateNum.Text != string.Empty && AddBoxModel.Text != string.Empty && AddBoxFuel.Text != string.Empty && AddBoxCapacity.Text != string.Empty && AddBoxLenght.Text != string.Empty)
          {
                CarType aKind = AddBoxKind.SelectedItem as CarType;

            Transport add = new Transport
            {
                StateNum = AddBoxStateNum.Text,
                automodel = AddBoxModel.Text,
                fuel = Convert.ToInt32(AddBoxFuel.Text),
                capacity = Convert.ToInt32(AddBoxCapacity.Text),
                length = Convert.ToInt32(AddBoxLenght.Text),
                busy = 0,
                kind = aKind.id,
                CarType = aKind
            };

            DataBase.AddAuto(add);

            await Task.Delay(200);

            await RefreshList();
          }
          else MessageBox.Show("Все данные должны быть введены");
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            AddBoxStateNum.Text = string.Empty;
            AddBoxModel.Text = string.Empty;
            AddBoxFuel.Text = string.Empty;
            AddBoxCapacity.Text = string.Empty;
            AddBoxLenght.Text = string.Empty;
        }
    }
}
