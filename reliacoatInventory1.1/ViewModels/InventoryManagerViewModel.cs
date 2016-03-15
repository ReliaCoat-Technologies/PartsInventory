using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Collections.ObjectModel;
using DataModel;
using MongoDB.Bson;

namespace Inventory.ViewModels
{
    [POCOViewModel]
    public class InventoryManagerViewModel
    {
        // Properties
        public virtual ObservableCollection<Item> itemList { get; set; }
        public virtual Item item { get; set; }
        public virtual string itemName { get; set; }
        public virtual string itemDescription { get; set; }

        // Constructor
        public InventoryManagerViewModel()
        {
            refreshUIAsync();
        }

        public static InventoryManagerViewModel Create()
        {
            return ViewModelSource.Create(() => new InventoryManagerViewModel());
        }

        // Methods
        public async void refreshUIAsync()
        {
            itemList = await Item.getItemListMongoDBAsync();
        }

        public void changeSelection()
        {
            itemName = item.item;
            itemDescription = item.description;
        }

        public async void appendItemAsync()
        {
            var itemToAppend = new Item
            {
                Id = item.item == itemName ? item.Id : ObjectId.GenerateNewId(), // Creates a new ID if none exists
                item = itemName,
                description = itemDescription,
                quantity = item.item == itemName ? item.quantity : 0
            };

            await itemToAppend.setItemMongoDBAsync();
            refreshUIAsync();
        }

        public async void removeItemAsync()
        {
            await item.deleteItemMongoDBAsync();
            refreshUIAsync();
        }
    }
}