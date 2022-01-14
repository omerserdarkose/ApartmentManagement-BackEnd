using ApartmentManagement.Core.Utilities.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ApartmentManagement.DataAccess.Context
{
    public class MongoDbContext
    {
        private IMongoDatabase _mongoDatabase;

        public MongoDbContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _mongoDatabase = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            return _mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name.Trim());
        }

        public IMongoDatabase GetDatabase()
        {
            return _mongoDatabase;
        }
    }
}
