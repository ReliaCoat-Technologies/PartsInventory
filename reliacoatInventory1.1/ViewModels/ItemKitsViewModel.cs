using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Collections.ObjectModel;
using DataModel;
using MongoDB.Bson;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace Inventory.ViewModels
{
    [POCOViewModel]
    public class ItemKitsViewModel
    {
        // Properties
        public virtual ObservableCollection<string> kitList { get; set; }
        public virtual string kitName { get; set; }
        public virtual int kitIndex { get; set; }
        public virtual ObservableCollection<Item> itemList { get; set; }
        public virtual ObservableCollection<string> itemComboBoxList { get; set; }
        public virtual Item item { get; set; }
        public virtual Kits kit { get; set; }
        public virtual int itemIndex { get; set; }
        public virtual int kitItemQuantity { get; set; }

        // Constructor
        public ItemKitsViewModel()
        {
            itemList = new ObservableCollection<Item>();
            refreshUIAsync();
        }

        public static ItemKitsViewModel Create()
        {
            return ViewModelSource.Create(() => new ItemKitsViewModel());
        }

        // Methods
        public async void refreshUIAsync()
        {
            kitIndex = -1;
            itemIndex = -1;
            kitName = string.Empty;
            kitList = await Kits.getKitListAsync();
            itemComboBoxList = await Item.getKitItemListAsync();
            itemList = new ObservableCollection<Item>();
        }

        public async void addToKitAsync()
        {
            if(itemIndex >= 0)
            {
                const char delimiter = '<';
                var stringList = itemComboBoxList[itemIndex].Split(delimiter);
                var itemName = stringList[0].Trim();

                var itemToAdd = await Item.getItemMongoDBAsync(itemName);
                itemToAdd.quantity = kitItemQuantity;

                itemList.Add(itemToAdd);

                var query = from item in itemList
                            orderby item.item
                            select item;

                itemList = new ObservableCollection<Item>(query.ToList());
            }
        }

        public void removeFromKit()
        {
            itemList.Remove(item);
        }

        public async void addKitToDatabaseAsync()
        {
            var kitIndexHolder = kitIndex;

            var kitToAdd = new Kits
            {
                Id = ObjectId.GenerateNewId(),
                kitName = kitName,
                itemList = itemList
            };

            await kitToAdd.addToKitCollectionAsync();
            refreshUIAsync();

            kitIndex = kitIndexHolder;
        }

        public async void getKitFromDatabaseAsync()
        {
            if (kitIndex >= 0)
            {
                var kits = await Kits.getKitAsync(kitName);
                itemList = kits.itemList;
            }
        }

        public async void removeKitFromDatabaseAsync()
        {
            await Kits.removeFromKitCollectionAsync(kitName);
            refreshUIAsync();
        }

        public void exportToCsv()
        {
            if (!string.IsNullOrWhiteSpace(kitName))
            {
                using (var writer = File.CreateText("kitExport.csv"))
                {
                    var header = new List<string>
                {
                    "Item ID",
                    "Description",
                    "Quantity"
                };

                    writer.WriteLine(string.Join(",", header));

                    foreach (var item in itemList)
                    {
                        var toCSV = new List<string>
                    {
                        item.item.Replace(',', ';'),
                        item.description.Replace(',', ';'),
                        item.quantity.ToString()
                    };

                        writer.WriteLine(string.Join(",", toCSV));
                    }
                }

                Process.Start("kitExport.csv");
            }
            else
            {
                MessageBox.Show("Please select a kit to export");
            }
        }
    }
}