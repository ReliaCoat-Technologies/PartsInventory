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
    /// Interaction logic for ItemInventory.xaml
    /// </summary>
    public partial class ItemInventory : UserControl
    {
        public ItemInventory()
        {
            InitializeComponent();
        }

        private void ItemExport(object sender, RoutedEventArgs e)
        {
            itemGrid.ShowPrintPreviewDialog(this.Parent as Window, "Item Inventory", "Item Inventory");
        }
    }
}
