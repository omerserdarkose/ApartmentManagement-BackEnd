using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Utilities.Settings;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.DataAccess.Context;
using ApartmentManagement.DataAccess.Repository.Mongo;
using ApartmentManagement.Entities.Concrete;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ApartmentManagement.DataAccess.Concrete.Mongo
{
    public class MPaymentDal: MongoRepositoryBase<Payment>, IPaymentDal
    {
        private MongoDbContext _context;
        private IMongoCollection<Payment> _collection;
        public MPaymentDal(IOptions<MongoSettings> settings) : base(settings)
        {
            _context = new MongoDbContext(settings);
            _collection = _context.GetCollection<Payment>();
        }
    }
}
