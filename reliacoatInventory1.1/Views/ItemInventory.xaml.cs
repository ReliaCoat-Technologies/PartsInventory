﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;

namespace Inventory.Views
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

        private void showPrintPreview(object sender, RoutedEventArgs e)
        {
            itemGrid.ShowPrintPreviewDialog(this.Parent as Window, "Item Inventory", "Item Inventory");
        }
    }
}
