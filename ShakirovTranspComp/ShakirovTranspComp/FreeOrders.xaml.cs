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
    /// Логика взаимодействия для FreeOrders.xaml
    /// </summary>
    public partial class FreeOrders : Page
    {
        List<Order> freeOrders;
        Frame curFr;
        public FreeOrders(Frame fr)
        {
            InitializeComponent();

            freeOrders = DataBase.GetFreeOrders();
            curFr = fr;

            RowDefinition r = new RowDefinition
            {
                Height = new GridLength(100, GridUnitType.Pixel)
            };

            foreach (Order o in freeOrders)
            {
                if (o.Transportation != null)
                {
                    TransportationOrders.RowDefinitions.Add(r);
                    TransportationOrders.Children.Add(ShowFreeTransportation(o.Transportation));
                }
                else if (o.Moving != null)
                {
                    MovingOrders.RowDefinitions.Add(r);
                    MovingOrders.Children.Add(ShowFreeMoving(o.Moving));
                }
            }
        }

        public Grid ShowFreeTransportation(Transportation order)
        {
            Grid mainGrid = new Grid();
            mainGrid.Height = 100;

            mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.6, GridUnitType.Star) });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.6, GridUnitType.Star) });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.6, GridUnitType.Star) });

            TextBlock export = new TextBlock
            {
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = order.export
            };

            TextBlock import = new TextBlock
            {
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = order.import
            };

            string lod = string.Empty;
            if (order.loader == null || order.loader == 0)
                lod = "-";
            else lod = order.loader.ToString();

            TextBlock loaders = new TextBlock
            {
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = lod
            };

            TextBlock transport = new TextBlock
            {
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = order.Order.Transport.StateNum
            };

            Button btn = new Button
            {
                Content = "Принять",
                FontSize = 20,
                Height = 50,
                Width = 150,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            btn.Click += (s, e) =>
            {
                MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите принять заказ?", "Принятие заказа", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    DataBase.AcceptOrder(order.Order);
                    MessageBox.Show("Заказ взят на исполнение");
                    curFr.Navigate(new SelectedDriversOrder(order.Order, curFr));
                }
            };

            mainGrid.Children.Add(export);
            mainGrid.Children.Add(import);
            mainGrid.Children.Add(loaders);
            mainGrid.Children.Add(transport);
            mainGrid.Children.Add(btn);

            Grid.SetColumn(export, 0);
            Grid.SetColumn(import, 1);
            Grid.SetColumn(loaders, 2);
            Grid.SetColumn(transport, 3);
            Grid.SetColumn(btn, 4);

            return mainGrid;
        }

        public Grid ShowFreeMoving(Moving order)
        {
            Grid mainGrid = new Grid();
            mainGrid.Height = 100;

            mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.4, GridUnitType.Star) });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.6, GridUnitType.Star) });

            TextBlock export = new TextBlock
            {
                FontSize = 15,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = order.export
            };

            TextBlock import = new TextBlock
            {
                FontSize = 15,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = order.import
            };

            string lod = string.Empty;
            if (order.loader == null)
                lod = "-";
            else lod = order.loader.ToString();

            TextBlock loaders = new TextBlock
            {
                FontSize = 15,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = lod
            };

            string fur = string.Empty;
            if (order.furniture == 0)
                fur = "-";
            else fur = "+";

            TextBlock furn = new TextBlock
            {
                FontSize = 15,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = fur
            };

            string pac = string.Empty;
            if (order.pack == 0)
                pac = "-";
            else pac = "+";

            TextBlock pack = new TextBlock
            {
                FontSize = 15,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = pac
            };

            TextBlock transport = new TextBlock
            {
                FontSize = 15,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = order.Order.Transport.StateNum
            };

            Button btn = new Button
            {
                Content = "Принять",
                FontSize = 20,
                Height = 50,
                Width = 150,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            btn.Click += (s, e) =>
            {
                MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите принять заказ?", "Принятие заказа", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    DataBase.AcceptOrder(order.Order);
                    MessageBox.Show("Заказ взят на исполнение");
                    curFr.Navigate(new SelectedDriversOrder(order.Order, curFr));
                }
            };

            mainGrid.Children.Add(export);
            mainGrid.Children.Add(import);
            mainGrid.Children.Add(loaders);
            mainGrid.Children.Add(furn);
            mainGrid.Children.Add(pack);
            mainGrid.Children.Add(transport);
            mainGrid.Children.Add(btn);

            Grid.SetColumn(export, 0);
            Grid.SetColumn(import, 1);
            Grid.SetColumn(loaders, 2);
            Grid.SetColumn(furn, 3);
            Grid.SetColumn(pack, 4);
            Grid.SetColumn(transport, 5);
            Grid.SetColumn(btn, 6);

            return mainGrid;
        }
    }
}
