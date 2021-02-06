using System.Collections.Generic;
using ecommerceDemo.Data.Model;
using ecommerceDemo.Data.Repository.MySQL;
using Infrastructure.Data;
using MongoDB.Driver;
using RepositoryContexts = ecommerceDemo.Data.Repository.RepositoryContexts;

namespace ecommerceDemo.Data.Utility
{
    public static class Initializer
    {
        public static class ecommerceDb
        {
            public static void InitializeRepository<TEntity>(List<TEntity> initialData) where TEntity : class
            {
                if (Data.Descriptor.ModuleContext.DatabaseType == DatabaseType.MongoDB)
                    InitializeMongoDBRepository(initialData);
                else
                    InitializeMySQLRepository(initialData);
            }

            private static void InitializeMongoDBRepository<TEntity>(List<TEntity> initialData)
            {
                var client = new MongoClient(Data.Descriptor.ModuleContext.MongoDBSettings.ConnectionString);
                var database = client.GetDatabase(Data.Descriptor.ModuleContext.MongoDBSettings.DatabaseName);

                var collection = database.CreateCollectionIfNotExists<TEntity>(GetCollectionNameByType<TEntity>());

                collection?.InsertMany(initialData);
            }

            private static string GetCollectionNameByType<TEntity>()
            {
                if (typeof(TEntity) == typeof(Data.Model.Product))
                    return RepositoryContexts.ProductRepository.Name;
                else if (typeof(TEntity) == typeof(Data.Model.Category))
                    return RepositoryContexts.CategoryRepository.Name;
                else if (typeof(TEntity) == typeof(Data.Model.Basket))
                    return RepositoryContexts.BasketRepository.Name;
                else if (typeof(TEntity) == typeof(Data.Model.Address))
                    return RepositoryContexts.AddressRepository.Name;
                else if (typeof(TEntity) == typeof(Data.Model.Order))
                    return RepositoryContexts.OrderRepository.Name;
                else if (typeof(TEntity) == typeof(Data.Model.User))
                    return RepositoryContexts.UserRepository.Name;

                return string.Empty;
            }

            private static void InitializeMySQLRepository<TEntity>(List<TEntity> initialData) where TEntity : class
            {
                using (var context = new ecommerceDbContext(Descriptor.ModuleContext.MySQLSettings))
                {
                    if (context.Database.EnsureCreated())
                    {
                        var dbSet = context.Set<TEntity>();

                        dbSet.AddRange(initialData);

                        context.SaveChanges();
                    }
                }
            }
        }
    }
}