using MongoDB.Driver;
using System.Configuration;

namespace DataModel
{
    class MongoDBServer<POCOType>
    {
        protected static readonly string database = "Inventory";
        protected static readonly string connectionString = ConfigurationManager.ConnectionStrings["MongoLocalHost"].ConnectionString;

        public static IMongoCollection<POCOType> openMongoDB(string collection)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(database);
            var col = db.GetCollection<POCOType>(collection);

            return col;
        }
    }
}
