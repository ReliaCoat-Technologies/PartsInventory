using System;
using DevExpress.Mvvm.DataAnnotations;
using System.Collections.Generic;
using DataModel;
using System.Collections.ObjectModel;
using DevExpress.Mvvm.POCO;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Xpf.Grid;

namespace ReliacoatInventory.ViewModels
{
    [POCOViewModel]
    public class LogViewModel
    {
        // Delegates
        public static Action<string, int> QuantityAdjusted;
        public static event Func<GridSortInfoCollection> GetSortInfo;

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
        public async void updateLogEntry()
        {
            var oldLog = await InventoryLog.getLogEntryAsync(selectedLog.Id);

            if (selectedLog?.quantityChanged != oldLog?.quantityChanged)
            {
                selectedLog.quantityAfter = selectedLog.quantityBefore + selectedLog.quantityChanged;
                var quantityAdjusted = selectedLog.quantityChanged - oldLog.quantityChanged;
                QuantityAdjusted?.Invoke(selectedLog.itemID, quantityAdjusted);
                await adjustLaterLogEntries(selectedLog, quantityAdjusted);
            }

            await selectedLog.appendLogEntryAsync();
            refreshUIAsync();
        }

        public async void removeLogEntry()
        {
            var oldLog = await InventoryLog.getLogEntryAsync(selectedLog.Id);
            var quantityAdjusted = -oldLog.quantityChanged;
            QuantityAdjusted?.Invoke(oldLog.itemID, quantityAdjusted);
            await adjustLaterLogEntries(oldLog, quantityAdjusted);

            await oldLog.removeLogAsync();
            refreshUIAsync();
        }

        private async Task adjustLaterLogEntries(InventoryLog log, int quantityAdjusted)
        {
            var query = from item in inventoryLogListRaw
                        where item.dateTime > log.dateTime
                        where item.itemID == log.itemID
                        select item;

            foreach (var item in query)
            {
                item.quantityBefore += quantityAdjusted;
                item.quantityAfter += quantityAdjusted;
                await item.appendLogEntryAsync();
            }
        }

        public async void refreshUIAsync()
        {
            inventoryLogListRaw = await InventoryLog.getLogEntryListAsync();

            await refreshComboBoxesAsync();

            var query = inventoryLogListRaw.AsQueryable();

            if (!string.IsNullOrWhiteSpace(item))
            {
                var stringList = item.Split('<');
                var itemName = stringList[0].Trim();
                query = query.Where(x => x.itemID == itemName);
            }

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

        private async Task refreshComboBoxesAsync()
        {
            itemList = await Item.getKitItemListAsync();
            itemList.Insert(0, ""); // Inserting a blank filter to remove the filter

            userList = await SimpleID.getIDListMongoDBAsync("Users");
            userList.Insert(0, "");

            accountList = await SimpleID.getIDListMongoDBAsync("Accounts");
            accountList.Insert(0, "");
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

        public void createReport()
        {
            var gridSortInfoCollection = GetSortInfo?.Invoke();
            var report = new ReportGenerator.MainWindow(inventoryLogList, gridSortInfoCollection);
            report.Show();
        }
    }
}