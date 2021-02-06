using System.Collections.Generic;
using ecommerceDemo.Data.Model;
using ecommerceDemo.Data.Repository.MySQL;

namespace ecommerceDemo.Data.Utility
{
    public static class Initializer
    {
        public static class ecommerceDb
        {
            public static void InitializeRepository<TEntity>(DbType databaseTypeToInitialize, List<TEntity> initialData)
            {
                using (var context = new ecommerceDbContext(ecommerceDemo.Data.Descriptor._dataModuleContext.MySQLSettings))
                {
                    if (context.Database.EnsureCreated())
                    {
                        initialData.ForEach(d => context.Add(d));

                        context.SaveChanges();
                    }
                }
            }
        }
    }
}