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
    /// Логика взаимодействия для SelectedDriversOrder.xaml
    /// </summary>
    public partial class SelectedDriversOrder : Page
    {
        Order selectedOrder;
        Frame curFr;
        public SelectedDriversOrder(Order selected, Frame fr)
        {
            InitializeComponent();

            selectedOrder = selected;

            PrintOrderInfo(selected);

            curFr = fr;
        }

        private void PrintOrderInfo(Order onPrint)
        {
            Transportation tranfer = null;
            Moving moving = null;

            OrderIdBox.Text = onPrint.id.ToString();

            if (onPrint.Transportation != null)
            {
                TypeBox.Text = "Перевозка";
                tranfer = onPrint.Transportation;

                ImportBox.Text = tranfer.import;
                ExportBox.Text = tranfer.export;
            }
            else
            {
                TypeBox.Text = "Переезд";
                moving = onPrint.Moving;

                ImportBox.Text = moving.import;
                ExportBox.Text = moving.export;
            }
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataBase.FinishOrder(selectedOrder))
            {
                MessageBox.Show("Исполнение заказа подтверждено");
                curFr.Navigate(new FreeOrders(curFr));
            }
            else
            {
                MessageBox.Show("Ошибка при обращении к базе");
            }

        }
    }
}
