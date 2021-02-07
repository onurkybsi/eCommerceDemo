using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;

namespace Infrastructure.Data
{
    public abstract class MongoDBCollectionBase<TMongoEntity, TResult> : IEntityRepository<TResult> where TResult : IEntity where TMongoEntity : IMongoDBEntity, TResult 
    {
        protected readonly IMongoCollection<TMongoEntity> _collection;

        private Mapper TResultMapper;
        private Mapper TMongoEntityMapper;

        public MongoDBCollectionBase(MongoDBCollectionSettings collectionSettings)
        {
            var client = new MongoClient(collectionSettings.DatabaseSettings.ConnectionString);
            var database = client.GetDatabase(collectionSettings.DatabaseSettings.DatabaseName);

            _collection = database.CreateCollectionIfNotExists<TMongoEntity>(collectionSettings.CollectionName, collectionSettings.CreateCollectionOptions);

            TResultMapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TMongoEntity, TResult>()));
            TMongoEntityMapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TResult, TMongoEntity>()));
        }

        public async Task<TResult> Get(Expression<Func<TResult, bool>> filter)
        {
            var filterForMongoEntity = filter as Expression<Func<TMongoEntity, bool>>;
            var entity = (await _collection.FindAsync<TMongoEntity>(new ExpressionFilterDefinition<TMongoEntity>(filterForMongoEntity))).FirstOrDefault();
            return TResultMapper.Map<TResult>(entity);
        }

        public async Task<List<TResult>> GetList(Expression<Func<TResult, bool>> filter = null)
        {
            var filterForMongoEntity = filter as Expression<Func<TMongoEntity, bool>>;

            var entityList = filterForMongoEntity is null
                ? (await _collection.FindAsync(document => true)).ToList()
                : (await _collection.FindAsync(new ExpressionFilterDefinition<TMongoEntity>(filterForMongoEntity))).ToList();

            return TResultMapper.Map<List<TMongoEntity>, List<TResult>>(entityList);
        }

        public async Task Create(TResult entity)
        {
            TMongoEntity inserted = TMongoEntityMapper.Map<TMongoEntity>(entity);
            await _collection.InsertOneAsync(inserted);
        }

        public abstract Task Update(TResult entity);

        // It will be changed. This may not be optimal solution
        public async Task FindAndUpdate(Expression<Func<TResult, bool>> filterDefinition, Action<TResult> updateDefinition)
        {
            var filterForMongoEntity = filterDefinition as Expression<Func<TMongoEntity, bool>>;
            var updateDefinitionForMongoEntity = updateDefinition as Action<TMongoEntity>;

            TMongoEntity updatedEntity = (await _collection.FindAsync(new ExpressionFilterDefinition<TMongoEntity>(filterForMongoEntity))).FirstOrDefault();
            updateDefinitionForMongoEntity(updatedEntity);

            await this.Update(updatedEntity);
        }

        public abstract Task Remove(TResult entity);
    }
}