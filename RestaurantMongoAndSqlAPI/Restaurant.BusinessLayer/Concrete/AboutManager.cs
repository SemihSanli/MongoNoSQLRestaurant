using Restaurant.BusinessLayer.Abstract;
using Restaurant.DataAccessLayer.Abstract;
using Restaurant.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TDelete(string id)
        {
           _aboutDal.Delete(id);    
        }

        public About TGetByID(string id)
        {
           return _aboutDal.GetByID(id);
        }

        public List<About> TGetList()
        {
           return _aboutDal.GetList();
        }

        public void TInsert(About t)
        {
           _aboutDal.Insert(t);
        }

        public void TUpdate(About t)
        {
           _aboutDal.Update(t);
        }
    }
}
