using DevExpress.Xpf.Core;
using DataModel;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Grid;

namespace ReportGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(ObservableCollection<Item> input, string kit = null)
        {
            InitializeComponent();
            var report = new ItemReport(input, kit);
            ItemReportPreview.DocumentSource = report;
            report.CreateDocument();
        }

        public MainWindow(ObservableCollection<InventoryLog> input, GridSortInfoCollection gridSortInfoColletion)
        {
            InitializeComponent();
            var report = new LogReport(input, gridSortInfoColletion);
            ItemReportPreview.DocumentSource = report;
            report.CreateDocument();
        }
    }
}
