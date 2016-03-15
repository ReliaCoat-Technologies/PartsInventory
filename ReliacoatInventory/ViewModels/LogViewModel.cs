using System;
using DevExpress.Mvvm.DataAnnotations;
using System.Collections.Generic;
using DataModel;
using System.Collections.ObjectModel;
using DevExpress.Mvvm.POCO;
using System.Linq;

namespace ReliacoatInventory.ViewModels
{
    [POCOViewModel]
    public class LogViewModel
    {
        // Properties
        public virtual List<InventoryLog> inventoryLogListRaw { get; set; }
        public virtual ObservableCollection<InventoryLog> inventoryLogList { get; set; }
        public virtual ObservableCollection<string> itemList { get; set; }
        public virtual ObservableCollection<string> userList { get; set; }
        public virtual ObservableCollection<string> accountList { get; set; }
        public virtual InventoryLog selectedLog { get; set; }
        public virtual string item { get; set; }
        public virtual string user { get; set; }
        public virtual string account { get; set; }
        public virtual string accountToChangeTo { get; set; }

        public virtual int accountToChangeToIndex { get; set; }
        public virtual DateTime? startDate { get; set; }
        public virtual DateTime? endDate { get; set; }

        // Constructor
        public LogViewModel()
        {
            clearFilters();
            accountToChangeToIndex = -1;
        }

        public static LogViewModel Create()
        {
            return ViewModelSource.Create(() => new LogViewModel());
        }

        // Helper Methods
        public async void refreshUIAsync()
        {
            inventoryLogListRaw = await InventoryLog.getLogEntryListAsync();

            var itemListRaw = from item in inventoryLogListRaw
                              select item.itemID;
            itemList = new ObservableCollection<string>(itemListRaw.ToList());
            itemList.Insert(0, "");

            userList = await SimpleID.getIDListMongoDBAsync("Users");
            userList.Insert(0, "");

            accountList = await SimpleID.getIDListMongoDBAsync("Accounts");
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

            query = query.OrderByDescending(x => x.dateTime)
                .Select(x => x);

            inventoryLogList = new ObservableCollection<InventoryLog>(query.ToList());

            accountToChangeToIndex = -1;
        }

        public void clearFilters()
        {
            item = null;
            user = null;
            account = null;
            startDate = null;
            endDate = DateTime.UtcNow.ToLocalTime();

            refreshUIAsync();
        }

        public async void changeAccountAsync()
        {
            if (accountToChangeToIndex != -1)
            {
                selectedLog.account = accountToChangeTo;
                await selectedLog.appendLogEntryAsync();
                refreshUIAsync();
            }
        }
    }
}