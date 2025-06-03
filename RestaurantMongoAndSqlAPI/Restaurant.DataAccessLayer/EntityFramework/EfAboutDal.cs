using Restaurant.DataAccessLayer.Abstract;
using Restaurant.DataAccessLayer.Context;
using Restaurant.DataAccessLayer.Repositories;
using Restaurant.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DataAccessLayer.EntityFramework
{
    public class EfAboutDal:GenericRepository<About>,IAboutDal
    {
        public EfAboutDal(MongoContext context) : base(context.GetCollection<About>("Abouts")) //mongocontext sınıfındaki About koleksiyonuna erişim sağlanıyor
        {
            
        }
    }
}
