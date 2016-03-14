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
    public sealed class InventoryLog
    {
        public ObjectId Id { get; set; }
        public string user { get; set; }
        public string account { get; set; }
        public string itemID { get; set; }
        public string description { get; set; }
        public int quantityBefore { get; set; }
        public int quantityChanged { get; set; }
        public int quantityAfter { get; set; }
        public DateTime dateTime { get; set; }

        public static string collection = "Log";

        public async static Task<List<InventoryLog>> getLogEntryList()
        {
            var logCol = MongoDBServer<InventoryLog>.openMongoDB(collection);
            var filter = Builders<InventoryLog>.Filter.Exists("_id");
            var logList = await logCol.Find(filter).ToListAsync();

            return new List<InventoryLog>(logList);
        }

        public async static Task<List<InventoryLog>> getLogEntryList(FilterDefinition<InventoryLog> finalFilter)
        {
            var logCol = MongoDBServer<InventoryLog>.openMongoDB(collection);
            var sort = Builders<InventoryLog>.Sort.Descending("dateTime");
            var logList = await logCol.Find(finalFilter)
                .Sort(sort)
                .ToListAsync();

            return logList;
        }

        public async void addLogToEntry()
        {
            var logCol = MongoDBServer<InventoryLog>.openMongoDB(collection);
            await logCol.InsertOneAsync(this);
        }
    }
}
