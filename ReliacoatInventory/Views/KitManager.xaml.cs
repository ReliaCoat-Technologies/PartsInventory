using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReliacoatInventory.Views
{
    /// <summary>
    /// Interaction logic for KitManager.xaml
    /// </summary>
    public partial class KitManager : UserControl
    {
        public KitManager()
        {
            InitializeComponent();
        }

        private void ExportKit(object sender, RoutedEventArgs e)
        {
            kitGrid.ShowPrintPreviewDialog(this.Parent as Window, "Kit", "Kit");
        }
    }
}
