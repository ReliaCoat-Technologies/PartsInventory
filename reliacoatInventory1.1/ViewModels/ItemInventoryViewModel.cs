using System;
using DevExpress.Mvvm.DataAnnotations;
using DataModel;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using DevExpress.Mvvm.POCO;
using System.Windows;

namespace reliacoatInventory.ViewModels
{
    [POCOViewModel]
    public class ItemInventoryViewModel
    {
        // Properties
        public virtual ObservableCollection<Item> itemList { get; set; }
        public virtual ObservableCollection<string> accountList { get; set; }
        public virtual ObservableCollection<string> userList { get; set; }
        public virtual Item item { get; set; }
        public virtual string user { get; set; }
        public virtual string account { get; set; }
        public virtual int qtyToAdd { get; set; }
        public virtual int qtyToRemove { get; set; }
        public virtual string statusBarText { get; set; }

        // Constructor
        public ItemInventoryViewModel()
        {
            refreshUI();
            item = new Item();
            qtyToAdd = 0;
            qtyToRemove = 0;
        }

        public static ItemInventoryViewModel Create()
        {
            return ViewModelSource.Create(() => new ItemInventoryViewModel());
        }

        // Methods
        public async void refreshUI()
        {
            itemList = await Item.getItemListMongoDB();
            userList = await SimpleID.getIDListMongoDB("Users");
            accountList = await SimpleID.getIDListMongoDB("Accounts");
        }

        public void updateStock()
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(account))
                MessageBox.Show("Please select a user and account");
            else if (qtyToAdd - qtyToRemove == 0)
                MessageBox.Show("No items are being added/removed.");
            else
            {
                item.quantity = item.quantity + qtyToAdd - qtyToRemove;
                item.setItemMongoDB();
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

            logEntry.addLogToEntry();

            var addRemoveString = qtyToAdd - qtyToRemove >= 0 ? "added" : "removed";
            var quantityChanged = Math.Abs(qtyToAdd - qtyToRemove);

            statusBarText = $"{user} has {addRemoveString} {quantityChanged} of {item.item}({item.description})";

            refreshUI();
        }
    }
}