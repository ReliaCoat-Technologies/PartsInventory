using DevExpress.Xpf.Grid;
using ReliacoatInventory.ViewModels;
using System;
using System.Windows.Controls;

namespace ReliacoatInventory.Views
{
    /// <summary>
    /// Interaction logic for Log.xaml
    /// </summary>
    public partial class Log : UserControl
    {
        public Log()
        {
            LogViewModel.GetSortInfo += getSortedInfo;

            InitializeComponent();
        }

        private GridSortInfoCollection getSortedInfo()
        {
            return gridControl.SortInfo;
        }
    }
}
