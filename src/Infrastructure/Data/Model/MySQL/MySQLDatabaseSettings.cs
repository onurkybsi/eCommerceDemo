namespace Infrastructure.Data
{
    public class MySQLDatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
    }
}