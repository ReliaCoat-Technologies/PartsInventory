using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DataModel;
using System.Collections.ObjectModel;

namespace ReportGenerator
{
    public partial class ItemReport : DevExpress.XtraReports.UI.XtraReport
    {
        // Properties
        public ObservableCollection<Item> itemList { get; set; }

        public ItemReport()
        {
            InitializeComponent();
        }

        public ItemReport(ObservableCollection<Item> input)
        {
            InitializeComponent();
            itemList = input;
            this.Detail.Controls.Add(createTable());
        }

        private XRTable createTable()
        {
            var table = new XRTable
            {
                WidthF = ItemTable.WidthF
            };
            ItemTable.BeginInit();

            var i = 1;

            foreach (var item in itemList)
            {
                var row = new XRTableRow();

                var itemCell = new XRTableCell
                {
                    Text = item.item,
                    WidthF = ItemIDHeader.WidthF,
                    TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
                    Borders = DevExpress.XtraPrinting.BorderSide.Right,
                    BackColor = i % 2 == 0 ? Color.LightGray : Color.Transparent
                };
                row.Cells.Add(itemCell);

                var descriptionCell = new XRTableCell
                {
                    Text = item.description,
                    WidthF = DescriptionHeader.WidthF - 1f,
                    TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
                    BackColor = i % 2 == 0 ? Color.LightGray : Color.Transparent
                };
                row.Cells.Add(descriptionCell);

                var quantityCell = new XRTableCell
                {
                    Text = item.quantity.ToString(),
                    WidthF = QuantityHeader.WidthF + 1f,
                    TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
                    Borders = DevExpress.XtraPrinting.BorderSide.Left,
                    BackColor = i % 2 == 0 ? Color.LightGray : Color.Transparent
                };

                row.Cells.Add(quantityCell);

                table.Rows.Add(row);

                i++;
            }

            table.EndInit();

            return table;
        }
    }
}
