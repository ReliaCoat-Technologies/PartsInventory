using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

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

        public async static Task<InventoryLog> getLogEntryAsync(ObjectId id)
        {
            var logCol = MongoDBServer<InventoryLog>.openMongoDB(collection);
            var filter = Builders<InventoryLog>.Filter.Where(x => x.Id == id);
            return await logCol.Find(filter).FirstOrDefaultAsync();
        }

        public async Task appendLogEntryAsync()
        {
            var logCol = MongoDBServer<InventoryLog>.openMongoDB(collection);
            var filter = Builders<InventoryLog>.Filter.Where(x => x.Id == Id);
            await logCol.FindOneAndReplaceAsync(filter, this);
        }

        public async Task addLogToEntryAsync()
        {
            var logCol = MongoDBServer<InventoryLog>.openMongoDB(collection);
            await logCol.InsertOneAsync(this);
        }

        public async Task removeLogAsync()
        {
            var logCol = MongoDBServer<InventoryLog>.openMongoDB(collection);
            var filter = Builders<InventoryLog>.Filter.Where(x => x.Id == Id);
            await logCol.FindOneAndDeleteAsync(filter);
        }
    }
}
