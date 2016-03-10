using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace mongoDBassembly
{
    public sealed class Item
    {
        public ObjectId Id { get; set; }
        public string item { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }

        public static string collection = "Items";
        public static string itemField = "item";

        public async static Task<List<Item>> getItemListMongoDB()
        {
            var itemCol = MongoDBServer<Item>.openMongoDB(collection);

            var filter = Builders<Item>.Filter.Exists(itemField);
            var sort = Builders<Item>.Sort.Ascending(itemField);
            var colList = await itemCol.Find(filter)
                .Sort(sort)
                .ToListAsync();

            return colList;
        }

        public async static Task<Item> getItemMongoDB(string itemName)
        {
            var itemCol = MongoDBServer<Item>.openMongoDB(collection);

            var filter = Builders<Item>.Filter.Eq(itemField, itemName);
            var itemSelected = await itemCol.Find(filter).FirstOrDefaultAsync();

            return itemSelected;
        }

        public async void setItemMongoDB()
        {
            var itemCol = MongoDBServer<Item>.openMongoDB(collection);

            var filter = Builders<Item>.Filter.Eq("Id", Id);
            await itemCol.FindOneAndReplaceAsync(filter, this);
        }

        public async void addItemMongoDB()
        {
            var itemCol = MongoDBServer<Item>.openMongoDB(collection);
            await itemCol.InsertOneAsync(this);
        }

        public async void deleteItemMongoDB()
        {
            var itemCol = MongoDBServer<Item>.openMongoDB(collection);

            var filter = Builders<Item>.Filter.Eq("Id", Id);
            await itemCol.FindOneAndDeleteAsync(filter);
        }
    }
}
