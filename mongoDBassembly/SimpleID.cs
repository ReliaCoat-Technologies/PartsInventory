using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.ObjectModel;

namespace DataModel
{
    public class SimpleID
    {
        // unsealed for possible polymorphisms of "User" and "Account"

        public ObjectId Id { get; set; }
        public string value { get; set; }

        public async static Task<ObservableCollection<string>> getIDListMongoDB(string collection)
        {
            var col = MongoDBServer<SimpleID>.openMongoDB(collection);
            var filter = Builders<SimpleID>.Filter.Exists("Id");
            var simpleIDListRaw = await col.Find(filter).ToListAsync();

            var simpleIDList = from item in simpleIDListRaw
                               orderby item.value
                               select item.value;

            return new ObservableCollection<string>(simpleIDList.ToList());
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
