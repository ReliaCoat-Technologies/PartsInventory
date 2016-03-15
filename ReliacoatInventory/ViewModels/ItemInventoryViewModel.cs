using System;
using DevExpress.Mvvm.DataAnnotations;
using System.Collections.ObjectModel;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using DataModel;
using DevExpress.Mvvm.POCO;
using System.Windows;

namespace ReliacoatInventory.ViewModels
{
    [POCOViewModel]
    public class ItemInventoryViewModel
    {
        // Properties
        public virtual ObservableCollection<Item> itemList { get; set; }
        public virtual ObservableCollection<string> accountList { get; set; }
        public virtual ObservableCollection<string> userList { get; set; }
        public virtual ObservableCollection<string> kitList { get; set; }
        public virtual Item item { get; set; }
        public virtual string user { get; set; }
        public virtual string account { get; set; }
        public virtual string kit { get; set; }
        public virtual int qtyToAdd { get; set; }
        public virtual int qtyToRemove { get; set; }
        public virtual string statusBarText { get; set; }

        // Constructor
        public ItemInventoryViewModel()
        {
            refreshUIAsync();
            item = new Item();
            qtyToAdd = 0;
            qtyToRemove = 0;
        }

        public static ItemInventoryViewModel Create()
        {
            return ViewModelSource.Create(() => new ItemInventoryViewModel());
        }

        // Methods
        public async void refreshUIAsync()
        {
            itemList = await Item.getItemListMongoDBAsync();
            userList = await SimpleID.getIDListMongoDBAsync("Users");
            kitList = await Kits.getKitListAsync();
            accountList = await SimpleID.getIDListMongoDBAsync("Accounts");
        }

        public async void updateStockAsync()
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(account))
                MessageBox.Show("Please select a user and account");
            else if (qtyToAdd - qtyToRemove == 0)
                MessageBox.Show("No items are being added/removed.");
            else
            {
                item.quantity = item.quantity + qtyToAdd - qtyToRemove;
                await item.setItemMongoDBAsync();
            }

            var logEntry = new InventoryLog
            {
                user = user,
                account = account,
                itemID = item.item,
                description = item.description,
                quantityBefore = item.quantity - qtyToAdd + qtyToRemove,
                quantityChanged = qtyToAdd - qtyToRemove,
                quantityAfter = item.quantity,
                dateTime = DateTime.UtcNow.ToLocalTime()
            };

            await logEntry.addLogToEntryAsync();

            var addRemoveString = qtyToAdd - qtyToRemove >= 0 ? "added" : "removed";
            var quantityChanged = Math.Abs(qtyToAdd - qtyToRemove);

            statusBarText = $"{user} has {addRemoveString} {quantityChanged} of {item.item}({item.description})";

            refreshUIAsync();
        }

        public async void removeKitAsync()
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(account))
            {
                MessageBox.Show("Please select a user and account");
                return;
            }

            if (!string.IsNullOrWhiteSpace(kit))
            {
                var kitToRemove = await Kits.getKitAsync(kit);
                var itemsToRemove = kitToRemove.itemList;

                foreach (var itemInKit in itemsToRemove)
                {
                    var itemInDB = await Item.getItemMongoDBAsync(itemInKit.item);
                    itemInDB.quantity -= itemInKit.quantity;

                    await itemInDB.setItemMongoDBAsync();

                    var logEntry = new InventoryLog
                    {
                        user = user,
                        account = account,
                        itemID = itemInDB.item,
                        description = $"{itemInDB.description} ({ kit })",
                        quantityBefore = itemInDB.quantity + itemInKit.quantity,
                        quantityChanged = -itemInKit.quantity,
                        quantityAfter = itemInDB.quantity,
                        dateTime = DateTime.UtcNow.ToLocalTime()
                    };

                    await logEntry.addLogToEntryAsync();
                }

                refreshUIAsync();
            }
        }

        public void createReport()
        {
            var report = new ReportGenerator.MainWindow(itemList);
            report.Show();
        }
    }
}