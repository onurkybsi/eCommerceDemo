using Infrastructure.Data;

namespace ecommerceDemo.Data.Model
{
    public class DataModuleContext
    {
        public DbType DbType { get; set; }
        public MongoDBSettings MongoDBSettings { get; set; }
        public MySQLDatabaseSettings MySQLSettings { get; set; }
    }
}