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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using MongoDB.Driver;
using MongoDB.Bson;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.ComponentModel;
using System.Diagnostics;
using mongoDBassembly;
using static mongoDBassembly.Item;
using static mongoDBassembly.SimpleID;
using static reliacoatInventory.StaticHelperMethods;
using static iTextSharpAssembly.PrintToPDF;

namespace reliacoatInventory
{

    public partial class MainWindow : Window
    {

        // Initializing variables used across multiple methods

        Process mongod = new Process();

        // End variable initialization

        public MainWindow()
        {
            InitializeComponent();

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "C:/Program Files/MongoDB/Server/3.0/bin/mongod.exe";

            mongod = Process.Start(start);
        }

        private void windowLoaded(object sender, RoutedEventArgs e)
        {
            RefreshUI();
        }

        private async void updateStock(object sender, RoutedEventArgs e)
        {
            string itemName;
            object itemSelectedRaw;

            if (userComboBox.Text == "")
            {
                MessageBox.Show("Please enter your name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                // This yields a generalized "object" type, which must be converted to a string.
                itemSelectedRaw = dataGrid.SelectedItem;
                // Using System.Type to prepare a reflector.
                Type type = itemSelectedRaw.GetType();
                // Using a reflector to obtain the "name" string
                itemName = (string)type.GetProperty("item").GetValue(itemSelectedRaw);
            }

            catch
            {
                MessageBox.Show("Please select an item", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var itemSelected = await getItemMongoDB(itemName);

            int addQuantity;
            int removeQuantity;
            int quantity;
            int newQuantity;   

            try
            {
                addQuantity = int.Parse(addToStockTextBox.Text);
                removeQuantity = int.Parse(removeFromStockTextBox.Text);
                quantity = itemSelected.quantity;
                newQuantity = quantity + addQuantity - removeQuantity;
                if (newQuantity < 0)
                {
                    string errorMsg = String.Format("Not enough of {0} in stock", itemName);
                    MessageBox.Show(errorMsg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                itemSelected.quantity = newQuantity;
            }

            catch
            {
                MessageBox.Show("Please enter numerical values for Add/Remove", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            itemSelected.setItemMongoDB();

            var log = new InventoryLog()
            {
                user = userComboBox.Text,
                account = accountComboBox.Text,
                itemID = itemSelected.item,
                description = itemSelected.description,
                quantityBefore = quantity,
                quantityChanged = addQuantity - removeQuantity,
                quantityAfter = newQuantity,
                dateTime = DateTime.UtcNow.ToLocalTime()
            };

            log.addLogToEntry();

            RefreshUI();

            string addRemove;
            string qChange;

            if (log.quantityChanged >= 0)
            {
                addRemove = "has added";
                qChange = log.quantityChanged.ToString();
            }
            else
            {
                addRemove = "has removed";
                qChange = (-log.quantityChanged).ToString();
            }

            statusBarTextBlock.Text = String.Format("{0} {1} {2} x {3}: {4} ({5} to {6})", log.user, addRemove, qChange, itemSelected.item, itemSelected.description, quantity, newQuantity);
            // statusBarTextBlock.Text = $"{log.user} {addRemove} {qChange} x {itemSelected.item}: {itemSelected.description} ({quantity} to {newQuantity})";
            // Above comment uses shorthanded String.Format for C# 6.0
        }

        private async void printInventory(object sender, RoutedEventArgs e)
        {
            var itemList = await getItemListMongoDB();
            PrintItemsToPDF(itemList);
        }

        private void exportToCsv(object sender, RoutedEventArgs e)
        {
            ExportToCSV("inventory.csv", dataGrid);
        }

        private void reviseItemList(object sender, RoutedEventArgs e)
        {
            reviseItems itemWindow = new reviseItems();
            itemWindow.Closed += reviseItemsClosed;
            itemWindow.Show();
        }

        private void reviseItemsClosed(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void usersAndAccounts(object sender, RoutedEventArgs e)
        {
            UsersAndAccounts UAWindow = new UsersAndAccounts();
            UAWindow.Closed += UAClosed;
            UAWindow.Show();
        }

        private void UAClosed(object sender, EventArgs e)
        {
            RefreshUI();
        }

        // Helper Methods

        private async void RefreshUI()
        {
            var itemList = await getItemListMongoDB();

            var bindingItemList = new BindingList<Item>(itemList);

            // Creating the table excluding the ID column
            dataGrid.DataContext = bindingItemList.Select(o => new{ item = o.item, description = o.description, quantity = o.quantity }).ToList();
            dataGrid.Columns[0].Header = "Item ID";
            dataGrid.Columns[0].Width = 100;
            dataGrid.Columns[1].Header = "Item Description";
            dataGrid.Columns[1].Width = 300;
            dataGrid.Columns[2].Header = "Qty";
            dataGrid.Columns[2].Width = 50;

            var userList = await getIDListMongoDB("Users");
            var bindingUserList = new BindingList<string>(userList.Select(o => o.value).ToList());
            userComboBox.ItemsSource = bindingUserList;

            var accountList = await getIDListMongoDB("Accounts");
            var bindingAccountList = new BindingList<string>(accountList.Select(o => o.value).ToList());
            accountComboBox.ItemsSource = bindingAccountList;
        }

        private void generateLogReportWindow(object sender, RoutedEventArgs e)
        {
            LogReport logWindow = new LogReport();
            logWindow.Show();
        }
    }
}
