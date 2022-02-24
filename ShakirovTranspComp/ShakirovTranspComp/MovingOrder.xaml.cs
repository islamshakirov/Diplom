using ShakirovTranspComp.OrderClasses;
using System.Windows;
using System.Windows.Controls;

namespace ShakirovTranspComp
{
    /// <summary>
    /// Логика взаимодействия для MovingOrder.xaml
    /// </summary>
    public partial class MovingOrder : Page
    {
        public MovingOrder()
        {
            InitializeComponent();

            LoadersBox.IsEnabled = false;
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
                short? loaders = null;
                byte? furniture;
                byte? pack;

                if (NeedFurniture.IsChecked == true) furniture = 1;
                else furniture = 0;

                if (NeedPack.IsChecked == true) pack = 1;
                else pack = 0;

                if (NeedLoaders.IsChecked == true && short.TryParse(LoadersBox.Text, out short loaderTest) == true)
                {
                    loaders = short.Parse(LoadersBox.Text);

                    if (await RequestMaker.MakeMovingRequestAsync(ImportBox.Text, ExportBox.Text, loaders, furniture, pack)) MessageBox.Show("Заказ совершен");
                    else MessageBox.Show("Что-то пошло не так");
                }
                else
                {
                    if (await RequestMaker.MakeMovingRequestAsync(ImportBox.Text, ExportBox.Text, loaders, furniture, pack)) MessageBox.Show("Заказ совершен");
                    else MessageBox.Show("Что-то пошло не так");
                }
            }
            else MessageBox.Show("Введите число в поле количества грузчиков");
        }
    }
}
