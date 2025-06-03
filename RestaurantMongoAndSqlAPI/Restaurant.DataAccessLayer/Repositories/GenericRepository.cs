using MongoDB.Driver;
using Restaurant.DataAccessLayer.Abstract;
using Restaurant.DataAccessLayer.Context;
using Restaurant.EntityLayer.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class , IBaseEntity //BaseEntity'i burada da örnek alarak Tüm Koleksiyonlardaki id için işlem yaptım
    {
        protected readonly IMongoCollection<T> _collection;

        public GenericRepository(IMongoCollection<T> collection) //İlgili koleksiyonu buraya bağımlılık ile getirttim (DI Uyguladım) 
        {
            _collection = collection;
        }

        public void Delete(string id)
        {
            _collection.FindOneAndDelete(x => x.Id == id);
        }

        public T GetByID(string id)
        {
           return _collection.Find(x=>x.Id==id).FirstOrDefault();
        }

        public List<T> GetList()
        {
            return _collection.AsQueryable().ToList(); //AsQueryable metodu LINQ Sorguları ile çalışmasını sağlar
        }

        public void Insert(T t)
        {
            _collection.InsertOne(t);
        }

        public void Update(T t)
        {
            _collection.FindOneAndReplace(x => x.Id == t.Id, t); //Eşleşen Id'yi bulup içerisindeki her şeyi yenisiyle değiştir anlamındadır
        }
    }
}
