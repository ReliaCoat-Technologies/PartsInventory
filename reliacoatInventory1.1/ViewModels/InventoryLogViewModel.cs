using System;
using DevExpress.Mvvm.DataAnnotations;
using DataModel;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using DevExpress.Mvvm.POCO;
using System.Collections.Generic;
using System.Linq;

namespace reliacoatInventory.ViewModels
{
    [POCOViewModel]
    public class InventoryLogViewModel
    {
        // Fields
        private static DateTime? _startDate;
        private static DateTime? _endDate;

        // Properties
        public virtual List<InventoryLog> inventoryLogListRaw { get; set; }
        public virtual ObservableCollection<InventoryLog> inventoryLogList { get; set; }
        public virtual ObservableCollection<string> itemList { get; set; }
        public virtual ObservableCollection<string> userList { get; set; }
        public virtual ObservableCollection<string> accountList { get; set; }
        public virtual string item { get; set; }
        public virtual string user { get; set; }
        public virtual string account { get; set; }
        public virtual DateTime? startDate { get; set; }
        public virtual DateTime? endDate { get; set; }

        // Constructor
        public InventoryLogViewModel()
        {
            refreshUI();
            endDate = DateTime.UtcNow.ToLocalTime();
            startDate = null;
        }

        public static InventoryLogViewModel Create()
        {
            return ViewModelSource.Create(() => new InventoryLogViewModel());
        }

        // Helper Methods
        public async void refreshUI()
        {
            inventoryLogListRaw = await InventoryLog.getLogEntryList();

            var itemListRaw = from item in inventoryLogListRaw
                              select item.itemID;
            itemList = new ObservableCollection<string>(itemListRaw.ToList());
            itemList.Insert(0, "");

            userList = await SimpleID.getIDListMongoDB("Users");
            userList.Insert(0, "");

            accountList = await SimpleID.getIDListMongoDB("Accounts");
            accountList.Insert(0, "");

            var query = inventoryLogListRaw.AsQueryable();

            if (!string.IsNullOrWhiteSpace(item))
                query = query.Where(x => x.itemID == item);

            if (!string.IsNullOrWhiteSpace(user))
                query = query.Where(x => x.user == user);

            if (!string.IsNullOrWhiteSpace(account))
                query = query.Where(x => x.account == account);

            if (startDate != null)
                query = query.Where(x => x.dateTime >= startDate);

            if (endDate != null)
            {
                var endDateNotNull = (DateTime)endDate;
                query = query.Where(x => x.dateTime < endDateNotNull.AddDays(1));
            }

            query = query.Select(x => x);

            inventoryLogList = new ObservableCollection<InventoryLog>(query.ToList());
        }
    }
}