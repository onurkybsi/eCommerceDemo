using MongoDB.Driver;

namespace Infrastructure.Data
{
    public class MongoDBCollectionSettings : IRepositorySettings<MongoDBSettings>
    {
        public MongoDBSettings DatabaseSettings { get; set; }
        public string CollectionName { get; set; }
        public CreateCollectionOptions CreateCollectionOptions { get; set; }
    }
}