using MongoDB.Driver;

namespace mongoDBassembly
{
    class MongoDBServer<POCOType>
    {
        protected static string database = "Inventory";

        public static IMongoCollection<POCOType> openMongoDB(string collection)
        {
            var client = new MongoClient();
            var db = client.GetDatabase(database);
            var col = db.GetCollection<POCOType>(collection);

            return col;
        }
    }
}
