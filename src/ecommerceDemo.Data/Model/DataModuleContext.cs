using Infrastructure.Data;

namespace ecommerceDemo.Data.Model
{
    public class DataModuleContext
    {
        public DatabaseType DatabaseType { get; set; }
        public MongoDBSettings MongoDBSettings { get; set; }
        public MySQLDatabaseSettings MySQLSettings { get; set; }
    }
}