using System;
using System.Windows;

namespace ShakirovTranspComp
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();

            Manager.AuthWindow = this;
            AuthFrame.Navigate(new AuthPage());
            Manager.mainFrame = AuthFrame;
        }

    }
}
