using System.Drawing;
using DevExpress.XtraReports.UI;
using System.Collections.ObjectModel;
using DataModel;
using DevExpress.Xpf.Grid;
using System.Linq;
using System.Linq.Dynamic;
using System.Collections.Generic;

namespace ReportGenerator
{
    public partial class LogReport : DevExpress.XtraReports.UI.XtraReport
    {
        public IEnumerable<InventoryLog> logList { get; set; }

        public LogReport()
        {
            InitializeComponent();
        }

        public LogReport(ObservableCollection<InventoryLog> input, GridSortInfoCollection gridSortInfoCollection)
        {
            InitializeComponent();

            if (gridSortInfoCollection.Count > 0)
            {
                List<InventoryLog> inputFiltered = new List<InventoryLog>();

                foreach (var item in gridSortInfoCollection)
                {
                    string isDescendingString = string.Empty;
                    if (item.SortOrder == System.ComponentModel.ListSortDirection.Descending)
                        isDescendingString = " descending";

                    inputFiltered = input.OrderBy($"{item.FieldName}{isDescendingString}").ToList();
                }

                logList = inputFiltered;
            }
            else
                logList = input;


            this.Detail.Controls.Add(createTable());
        }

        private XRTable createTable()
        {
            var table = new XRTable
            {
                WidthF = LogTable.WidthF
            };
            LogTable.BeginInit();

            var i = 1;

            foreach (var item in logList)
            {
                if (i > 280)
                    break;

                var row = new XRTableRow();

                var dateTimeCell = new XRTableCell
                {
                    Text = item.dateTime.ToString(),
                    WidthF = DateTimeHeader.WidthF,
                    TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
                    Borders = DevExpress.XtraPrinting.BorderSide.Right,
                    BackColor = i % 2 == 0 ? Color.LightGray : Color.Transparent
                };
                row.Cells.Add(dateTimeCell);

                var userCell = new XRTableCell
                {
                    Text = item.user,
                    WidthF = UserHeader.WidthF,
                    TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
                    Borders = DevExpress.XtraPrinting.BorderSide.Right,
                    BackColor = i % 2 == 0 ? Color.LightGray : Color.Transparent
                };
                row.Cells.Add(userCell);

                var accountCell = new XRTableCell
                {
                    Text = item.account,
                    WidthF = AccountHeader.WidthF,
                    TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
                    Borders = DevExpress.XtraPrinting.BorderSide.Right,
                    BackColor = i % 2 == 0 ? Color.LightGray : Color.Transparent
                };
                row.Cells.Add(accountCell);

                var itemIDCell = new XRTableCell
                {
                    Text = item.itemID,
                    WidthF = ItemIDHeader.WidthF,
                    TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
                    Borders = DevExpress.XtraPrinting.BorderSide.Right,
                    BackColor = i % 2 == 0 ? Color.LightGray : Color.Transparent
                };
                row.Cells.Add(itemIDCell);

                var descriptionCell = new XRTableCell
                {
                    Text = item.description,
                    WidthF = DescriptionHeader.WidthF,
                    TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
                    Borders = DevExpress.XtraPrinting.BorderSide.Right,
                    BackColor = i % 2 == 0 ? Color.LightGray : Color.Transparent
                };
                row.Cells.Add(descriptionCell);

                var qtyBeforeCell = new XRTableCell
                {
                    Text = item.quantityBefore.ToString(),
                    WidthF = qtyBeforeHeader.WidthF,
                    TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
                    Borders = DevExpress.XtraPrinting.BorderSide.Right,
                    BackColor = i % 2 == 0 ? Color.LightGray : Color.Transparent
                };
                row.Cells.Add(qtyBeforeCell);

                var qtyCell = new XRTableCell
                {
                    Text = item.quantityChanged.ToString(),
                    WidthF = qtyHeader.WidthF,
                    TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
                    BackColor = i % 2 == 0 ? Color.LightGray : Color.Transparent
                };
                row.Cells.Add(qtyCell);

                var qtyAfterCell = new XRTableCell
                {
                    Text = item.quantityAfter.ToString(),
                    WidthF = qtyAfterHeader.WidthF,
                    TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
                    Borders = DevExpress.XtraPrinting.BorderSide.Left,
                    BackColor = i % 2 == 0 ? Color.LightGray : Color.Transparent
                };
                row.Cells.Add(qtyAfterCell);

                table.Rows.Add(row);

                i++;
            }

            table.EndInit();

            return table;
        }
    }
}
