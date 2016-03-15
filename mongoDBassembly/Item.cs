using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.ObjectModel;

namespace DataModel
{
    public sealed class Item
    {
        public ObjectId Id { get; set; }
        public string item { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }

        public static string collection = "Items";
        public static string itemField = "item";

        public async static Task<ObservableCollection<Item>> getItemListMongoDBAsync()
        {
            var itemCol = MongoDBServer<Item>.openMongoDB(collection);

            var filter = Builders<Item>.Filter.Exists(itemField);
            var sort = Builders<Item>.Sort.Ascending(itemField);
            var colList = await itemCol.Find(filter)
                .Sort(sort)
                .ToListAsync();

            return new ObservableCollection<Item>(colList);
        }

        public async static Task<ObservableCollection<string>> getKitItemListAsync()
        {
            var itemListRaw = await getItemListMongoDBAsync();

            var list = new ObservableCollection<string>();

            foreach (var item in itemListRaw)
                list.Add($"{item.item} <{item.description}>");

            return list;
        }

        public async static Task<Item> getItemMongoDBAsync(string itemName)
        {
            var itemCol = MongoDBServer<Item>.openMongoDB(collection);

            var filter = Builders<Item>.Filter.Eq(itemField, itemName);
            var itemSelected = await itemCol.Find(filter).FirstOrDefaultAsync();

            return itemSelected;
        }

        public async Task setItemMongoDBAsync()
        {
            var itemCol = MongoDBServer<Item>.openMongoDB(collection);

            var query = from itemQuery in itemCol.AsQueryable()
                        where itemQuery.Id == Id
                        select itemQuery.Id;

            var queryList = query.ToList();

            if (queryList.Count > 0)
            {
                var filter = Builders<Item>.Filter.Eq(nameof(item), item);
                await itemCol.FindOneAndDeleteAsync(filter);
            }

            await itemCol.InsertOneAsync(this);
        }

        public async Task deleteItemMongoDBAsync()
        {
            var itemCol = MongoDBServer<Item>.openMongoDB(collection);

            var filter = Builders<Item>.Filter.Eq(nameof(Id), Id);
            await itemCol.FindOneAndDeleteAsync(filter);
        }
    }
}
