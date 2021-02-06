using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AdvancedDbContext : DbContext
    {
        protected IDatabaseSettings _databaseSettings;

        public AdvancedDbContext(IDatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_databaseSettings.ConnectionString);
        }
    }
}