using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MongoDB.Driver;
using MongoDB.Bson;
using System.ComponentModel;
using System.IO;
using iTextSharp.text.pdf;
using System.Diagnostics;
using iTextSharp.text;
using mongoDBassembly;
using iTextSharpAssembly;
using static mongoDBassembly.InventoryLog;
using static mongoDBassembly.SimpleID;
using static mongoDBassembly.Item;
using static iTextSharpAssembly.PrintToPDF;
using static reliacoatInventory.StaticHelperMethods;

namespace reliacoatInventory
{
    /// <summary>
    /// Interaction logic for LogReport.xaml
    /// </summary>
    public partial class LogReport : Window
    {

        public LogReport()
        {
            InitializeComponent();
            refreshLG();
        }

        private async void createLogReportDataGrid(object sender, RoutedEventArgs e)
        {
            var logList = await createLogReportList();

            dataGrid.DataContext = logList.Select(o => new
            {
                dateTime = o.dateTime,
                user = o.user,
                account = o.account,
                item = o.itemID,
                description = o.description,
                quantityBefore = o.quantityBefore,
                quantityChanged = o.quantityChanged,
                quantityAfter = o.quantityAfter
            });

            dataGrid.Columns[0].Header = "Date and Time";
            dataGrid.Columns[0].Width = 150;
            dataGrid.Columns[1].Header = "User";
            dataGrid.Columns[1].Width = 80;
            dataGrid.Columns[2].Header = "Account";
            dataGrid.Columns[2].Width = 70;
            dataGrid.Columns[3].Header = "Item ID";
            dataGrid.Columns[3].Width = 100;
            dataGrid.Columns[4].Header = "Item Description";
            dataGrid.Columns[4].Width = 250;
            dataGrid.Columns[5].Header = "Qty. Before";
            dataGrid.Columns[5].Width = 70;
            dataGrid.Columns[6].Header = "+/-";
            dataGrid.Columns[6].Width = 40;
            dataGrid.Columns[7].Header = "Qty. After";
            dataGrid.Columns[7].Width = 70;
        }

        private void exportToCsv(object sender, RoutedEventArgs e)
        {
            ExportToCSV("log.csv", dataGrid);
        }

        private async void printLogToPDF(object sender, RoutedEventArgs e)
        {
            var logList = await createLogReportList();
            PrintLogToPDF(logList);
        }

        // Helper Methods

        private async void refreshLG()
        {
            var itemList = await getItemListMongoDB();
            addToComboBox(itemComboBox, itemList);
            itemComboBox.SelectedItem = "(all)";

            var userList = await getIDListMongoDB("Users");
            addToComboBox(userComboBox, userList);
            userComboBox.SelectedItem = "(all)";

            var accountList = await getIDListMongoDB("Accounts");
            addToComboBox(accountComboBox, accountList);
            accountComboBox.SelectedItem = "(all)";
        }

        private void addToComboBox(ComboBox comboBox, List<SimpleID> inputList)
        {
            BindingList<string> itemList = new BindingList<string>(inputList.Select(o => o.value).ToList());
            itemList.Insert(0, "(all)");
            comboBox.ItemsSource = itemList;
        }

        private void addToComboBox(ComboBox comboBox, List<Item> inputList)
        {
            BindingList<string> itemList = new BindingList<string>(inputList.Select(o => o.item).ToList());
            itemList.Insert(0, "(all)");
            comboBox.ItemsSource = itemList;
        }

        private FilterDefinition<InventoryLog> instantiateFilterDate(DatePicker startDateSelected, DatePicker endDateSelected)
        {
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.UtcNow.ToLocalTime();

            try
            {
                startDate = startDateSelected.SelectedDate.Value;
            }
            catch { } // reverts to "beginning of time" (1/1/0001)

            var finalFilter = Builders<InventoryLog>.Filter.Gte("dateTime", startDate);

            try
            {
                endDate = endDateSelected.SelectedDate.Value.AddDays(1);
            }
            catch { } // reverts to current date

            var endDateFilter = Builders<InventoryLog>.Filter.Lt("dateTime", endDate);
            finalFilter = finalFilter & endDateFilter;

            return finalFilter;
        }

        private FilterDefinition<InventoryLog> addToFilter(string criteria, string value, FilterDefinition<InventoryLog> finalFilter)
        {
            var filter = Builders<InventoryLog>.Filter.Eq(criteria, value);

            if (value != "(all)")
            {
                finalFilter = finalFilter & filter;
            }

            return finalFilter;
        }

        private async Task<List<InventoryLog>> createLogReportList()
        {
            var finalFilter = instantiateFilterDate(startDate, endDate);

            // Separating the "item selected" string to ensure only the "item" value without the description
            string selectedItemRaw = itemComboBox.Text;
            string[] splitItem = selectedItemRaw.Split(':');
            string itemSelected = splitItem[0];
            finalFilter = addToFilter("itemID", itemSelected, finalFilter);
            finalFilter = addToFilter("user", userComboBox.Text, finalFilter);
            finalFilter = addToFilter("account", accountComboBox.Text, finalFilter);

            var logList = await getLogEntryList(finalFilter);

            foreach (var doc in logList)
            {
                doc.dateTime = doc.dateTime.ToLocalTime();
            }

            return logList;
        }
    }
}
