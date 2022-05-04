using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ShakirovTranspComp.OrderClasses;

namespace ShakirovTranspComp
{
    /// <summary>
    /// Логика взаимодействия для ArendOrder.xaml
    /// </summary>
    public partial class ArendOrder : Page
    {
        int hours = 0;
        public ArendOrder()
        {
            InitializeComponent();

            CarTypeSelector.ItemsSource = DataBase.GetContext().CarType.ToArray();
        }

        private async void RequestButton_Click(object sender, RoutedEventArgs e)
        {
            if ( StartDate.SelectedDate.Value.DayOfYear >= DateTime.Now.DayOfYear)
            {
                if (hours != 0)
                {
                    DateTime endDate = StartDate.SelectedDate.Value.AddHours(hours);

                    if (int.TryParse(AmountBox.Text, out int amount) == true)
                    {
                        if(await RequestMaker.MakeArendRequestAsync(amount, (CarType)CarTypeSelector.SelectedItem, StartDate.SelectedDate.Value, endDate)) MessageBox.Show("Заказ совершен");
                        else MessageBox.Show("Что-то пошло не так");
                    }
                    else MessageBox.Show("Введите число в поле тоннажа");
                }
                else MessageBox.Show("Укажите время аренды");
            }
            else MessageBox.Show("Укажите дату");
        }

        private async void SuitableCars_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (int.TryParse(AmountBox.Text, out int amount) == true)
            {
                Transport suitCar = await DataBase.FindSuitCar(amount, (CarType)CarTypeSelector.SelectedItem);
                if (suitCar != null) SuitableCars.Text = "Есть машина с тоннажем " + suitCar.capacity;
                else SuitableCars.Text = "Подходящих машин нет";
            }
            else MessageBox.Show("Введите число в поле тоннажа");
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            hours++;
            ArendHours.Text = hours.ToString();
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (hours > 0)
            {
                hours--;
                ArendHours.Text = hours.ToString();
            }
        }
    }
}
