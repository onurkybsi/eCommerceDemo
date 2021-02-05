namespace Infrastructure.Data
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
    }
}