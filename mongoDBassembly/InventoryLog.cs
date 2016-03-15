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

        public async static Task<List<InventoryLog>> getLogEntryListAsync()
        {
            var logCol = MongoDBServer<InventoryLog>.openMongoDB(collection);
            var filter = Builders<InventoryLog>.Filter.Exists("_id");
            var logList = await logCol.Find(filter).ToListAsync();

            return new List<InventoryLog>(logList);
        }

        public async Task appendLogEntryAsync()
        {
            var logCol = MongoDBServer<InventoryLog>.openMongoDB(collection);
            var filter = Builders<InventoryLog>.Filter.Eq("_id", Id);
            await logCol.FindOneAndReplaceAsync(filter, this);
        }

        public async Task addLogToEntryAsync()
        {
            var logCol = MongoDBServer<InventoryLog>.openMongoDB(collection);
            await logCol.InsertOneAsync(this);
        }
    }
}
