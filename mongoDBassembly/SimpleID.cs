using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace mongoDBassembly
{
    public class SimpleID
    {
        // unsealed for possible polymorphisms of "User" and "Account"

        public ObjectId Id { get; set; }
        public string value { get; set; }

        public async static Task<List<SimpleID>> getIDListMongoDB(string collection)
        {
            var col = MongoDBServer<SimpleID>.openMongoDB(collection);
            var filter = Builders<SimpleID>.Filter.Exists("Id");
            var simpleIDList = await col.Find(filter).ToListAsync();

            return simpleIDList;   
        }

        public async static Task<SimpleID> getIDMongoDB(string value, string collection)
        {
            var col = MongoDBServer<SimpleID>.openMongoDB(collection);
            var filter = Builders<SimpleID>.Filter.Eq("value", value);
            var simpleID = await col.Find(filter).FirstOrDefaultAsync();

            return simpleID;
        }

        public async void addIDMongoDB(string collection)
        {
            var col = MongoDBServer<SimpleID>.openMongoDB(collection);
            await col.InsertOneAsync(this);
        }

        public async void removeIDmongoDB(string collection)
        {
            var col = MongoDBServer<SimpleID>.openMongoDB(collection);
            var filter = Builders<SimpleID>.Filter.Eq("Id", Id);
            await col.FindOneAndDeleteAsync(filter);
        }
    }
}
