using System.Collections.Generic;
using Infrastructure.Data;
using MongoDB.Driver;
using RepositoryContexts = ecommerceDemo.Data.Repository.RepositoryContexts;

namespace ecommerceDemo.Data.Utility
{
    public static class Initializer
    {
        public static class ecommerceDb
        {
            public static void InitializeRepository<TEntity>(List<TEntity> initialData) where TEntity : class, IEntity
                => InitializeMongoDBRepository(initialData);

            private static void InitializeMongoDBRepository<TEntity>(List<TEntity> initialData) where TEntity : IEntity
            {
                var client = new MongoClient(Data.Descriptor.ModuleContext.MongoDBSettings.ConnectionString);
                var database = client.GetDatabase(Data.Descriptor.ModuleContext.MongoDBSettings.DatabaseName);

                var collection = database.CreateCollectionIfNotExists<TEntity>(RepositoryContexts.GetCollectionNameByEntityType<TEntity>(),
                    RepositoryContexts.GetMongoDBCreateCollectionOptionsByEntityType<TEntity>());

                if (collection.CountDocuments(document => true) > 0)
                    return;

                var initialAction = RepositoryContexts.GetInitialActionByEntityType<TEntity>();
                if (initialAction != null)
                    initialAction(collection);

                collection?.InsertMany(initialData);
            }
        }
    }
}