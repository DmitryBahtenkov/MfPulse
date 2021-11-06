using System;
using System.Threading.Tasks;
using MfPulse.Mongo.Document;
using MfPulse.Mongo.Security;
using MongoDB.Driver;

namespace MfPulse.Mongo.Operations.Implementations
{
    public abstract class BaseOperations<TDocument> where TDocument : IDocument
    {
        protected FilterDefinitionBuilder<TDocument> F => Builders<TDocument>.Filter;
        protected UpdateDefinitionBuilder<TDocument> U => Builders<TDocument>.Update;
        protected readonly MongoSecurityFilter _mongoSecurityFilter;

        protected readonly IMongoCollection<TDocument> Collection;
        
        protected BaseOperations(DbContext dbContext, MongoSecurityFilter mongoSecurityFilter)
        {
            _mongoSecurityFilter = mongoSecurityFilter;
            Collection = dbContext.Database.GetCollection<TDocument>(typeof(TDocument).Name.Replace("Document", ""));
        }

        /// <summary>
        /// Метод выполнения некой операции в монго с применением фильтров.
        /// Применяет все SecureFilters для фильтра в операции 
        /// </summary>
        /// <param name="operation">Функция, которую необходимо выполнить</param>
        /// <param name="filterDefinition">Фильтр, который необходимо обогатить и передать в функцию</param>
        /// <typeparam name="TResult">Тип результата, который вернёт функция</typeparam>
        /// <returns>Указанный результат в TResult</returns>
        protected async Task<TResult> ExecuteOperation<TResult>(Func<FilterDefinition<TDocument>, Task<TResult>> operation, FilterDefinition<TDocument> filterDefinition)
        {
            filterDefinition &= _mongoSecurityFilter.GetSecureFilter(filterDefinition);
            
            return await operation(filterDefinition);
        }
    }
}