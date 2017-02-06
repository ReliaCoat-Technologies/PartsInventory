using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;

namespace DataModel
{
    public static class MongoDBServer<T>
    {
        public static readonly string database = "Inventory";
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["MongoRemoteHost"].ConnectionString;

        public static IMongoCollection<T> openMongoDB(string collection)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(database);
            return db.GetCollection<T>(collection);
        }

        public static bool pingMongoServer()
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(database);
            // Pinging the MongoDB server. Will return false if no connection available.
            return db.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(5000);
        }
    }
}
