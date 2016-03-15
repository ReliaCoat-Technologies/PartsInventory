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

        public async static Task<ObservableCollection<string>> getIDListMongoDBAsync(string collection)
        {
            var col = MongoDBServer<SimpleID>.openMongoDB(collection);
            var filter = Builders<SimpleID>.Filter.Exists(nameof(Id));
            var simpleIDListRaw = await col.Find(filter).ToListAsync();

            var simpleIDList = from item in simpleIDListRaw
                               orderby item.value
                               select item.value;

            return new ObservableCollection<string>(simpleIDList.ToList());
        }

        public async static Task<SimpleID> getIDMongoDBAsync(string value, string collection)
        {
            var col = MongoDBServer<SimpleID>.openMongoDB(collection);
            var filter = Builders<SimpleID>.Filter.Eq(nameof(value), value);
            var simpleID = await col.Find(filter).FirstOrDefaultAsync();

            return simpleID;
        }

        public async Task addIDMongoDBAsync(string collection)
        {
            var col = MongoDBServer<SimpleID>.openMongoDB(collection);
            await col.InsertOneAsync(this);
        }

        public static async Task removeIDmongoDBAsync(string collection, string value)
        {
            var col = MongoDBServer<SimpleID>.openMongoDB(collection);
            var filter = Builders<SimpleID>.Filter.Eq(nameof(value), value);
            await col.FindOneAndDeleteAsync(filter);
        }
    }
}
