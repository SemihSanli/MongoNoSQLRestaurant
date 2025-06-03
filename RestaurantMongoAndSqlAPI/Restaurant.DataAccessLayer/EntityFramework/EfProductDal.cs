using MongoDB.Bson;
using MongoDB.Driver;
using Restaurant.DataAccessLayer.Abstract;
using Restaurant.DataAccessLayer.Context;
using Restaurant.DataAccessLayer.Repositories;
using Restaurant.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DataAccessLayer.EntityFramework
{
    public class EfProductDal:GenericRepository<Product>,IProductDal
    {
        public EfProductDal(MongoContext context) : base(context.GetCollection<Product>("Products"))
        {
            
        }

        public async Task<List<Product>> GetProductByCategoryIdAsync(string categoryId)
        {
          var filter = Builders<Product>.Filter.Eq(p=>p.CategoryId,categoryId);
            return await _collection.Find(filter).ToListAsync();
        }
    }
}
