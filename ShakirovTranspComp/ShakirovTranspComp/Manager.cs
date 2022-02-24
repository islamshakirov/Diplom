
using System.Windows;
using System.Windows.Controls;

namespace ShakirovTranspComp
{
    class Manager
    {
        public static Window AuthWindow { get; set; }
        public static Window MainWindow { get; set; }
        public static Frame mainFrame { get; set; }
        public static Client currentClient { get; set; }
    }
}
