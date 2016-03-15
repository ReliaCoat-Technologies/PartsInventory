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
using DevExpress.Xpf.Core;
using DataModel;
using System.Collections.ObjectModel;
using DevExpress.XtraReports.UI;

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

        public MainWindow(ObservableCollection<Item> input)
        {
            InitializeComponent();
            var report = new ItemReport(input);
            ItemReportPreview.DocumentSource = report;
            report.CreateDocument();
        }
    }
}
