using ShakirovTranspComp.OrderClasses;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ShakirovTranspComp
{
    /// <summary>
    /// Логика взаимодействия для TranportationOrder.xaml
    /// </summary>
    public partial class TranportationOrder : Page
    {
        public TranportationOrder()
        {
            InitializeComponent();

            LoadersBox.IsEnabled = false;
            CargoTypeSelector.ItemsSource = DataBase.GetContext().cargoType.ToArray();
        }

        private void NeedLoaders_Checked(object sender, RoutedEventArgs e)
        {
            LoadersBox.IsEnabled = true;
        }

        private void NeedLoaders_Unchecked(object sender, RoutedEventArgs e)
        {
            LoadersBox.IsEnabled = false;
        }

        private async void RequestButton_Click(object sender, RoutedEventArgs e)
        {
            if (ImportBox.Text != string.Empty && ExportBox.Text != string.Empty)
            {
                if (int.TryParse(AmountBox.Text, out int amount))
                {
                    short? loaders;
                    if (NeedLoaders.IsChecked == true && short.TryParse(LoadersBox.Text, out short loaderTest) == true)
                    {
                        loaders = short.Parse(LoadersBox.Text);
                        await RequestMaker.MakeTransportationRequestAsync(ImportBox.Text, ExportBox.Text, amount, (cargoType)CargoTypeSelector.SelectedItem, loaders);
                        MessageBox.Show("Заказ совершен");
                    }
                    else if (NeedLoaders.IsChecked == false)
                    {
                        if (await RequestMaker.MakeTransportationRequestAsync(ImportBox.Text, ExportBox.Text, amount, (cargoType)CargoTypeSelector.SelectedItem)) MessageBox.Show("Заказ совершен");
                        else MessageBox.Show("Что-то пошло не так");
                    }
                    else MessageBox.Show("Введите число в поле количества грузчиков");
                }
                else MessageBox.Show("Введите число в поле массы");
            }
            else MessageBox.Show("Введите точку отбытия и прибытия груза");
        }
    }
}
