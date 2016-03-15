using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace DataModel
{
    public class Kits
    {
        // Statics
        public static readonly string collection = "Kits";

        // Properties
        public ObjectId Id { get; set; }
        public string kitName { get; set; }
        public ObservableCollection<Item> itemList { get; set; }

        // Methods
        public static async Task<ObservableCollection<string>> getKitListAsync()
        {
            var kitCol = MongoDBServer<Kits>.openMongoDB(collection);
            var filter = Builders<Kits>.Filter.Exists("_id");
            var kitListRaw = await kitCol.Find(filter).ToListAsync();

            var query = from kit in kitListRaw
                        orderby kit.kitName
                        select kit.kitName;

            var queryList = query.ToList();
            return new ObservableCollection<string>(queryList);
        }

        public static async Task<Kits> getKitAsync(string kitName)
        {
            var kitCol = MongoDBServer<Kits>.openMongoDB(collection);
            var filter = Builders<Kits>.Filter.Eq(nameof(kitName), kitName);
            var kit = await kitCol.Find(filter).FirstOrDefaultAsync();

            return kit;
        }

        public async Task addToKitCollectionAsync()
        {
            var kitCol = MongoDBServer<Kits>.openMongoDB(collection);

            var query = from kit in kitCol.AsQueryable()
                        where kit.kitName == kitName
                        select kit.kitName;

            if(query.ToList().Count() > 0) // Removing older entry
            {
                var filter = Builders<Kits>.Filter.Eq(nameof(kitName), kitName);
                await kitCol.FindOneAndDeleteAsync(filter);
            }

            await kitCol.InsertOneAsync(this);
        }

        public static async Task removeFromKitCollectionAsync(string kitName)
        {
            var kitCol = MongoDBServer<Kits>.openMongoDB(collection);
            var filter = Builders<Kits>.Filter.Eq(nameof(kitName), kitName);
            await kitCol.FindOneAndDeleteAsync(filter);
        }
    }
}
