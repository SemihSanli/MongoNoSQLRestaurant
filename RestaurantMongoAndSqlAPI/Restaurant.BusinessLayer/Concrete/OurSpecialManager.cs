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
    public class OurSpecialManager : IOurSpecialService
    {
        private readonly IOurSpecialDal _ourSpecialDal;

        public OurSpecialManager(IOurSpecialDal ourSpecialDal)
        {
            _ourSpecialDal = ourSpecialDal;
        }

        public void TDelete(string id)
        {
            _ourSpecialDal.Delete(id);
        }

        public OurSpecial TGetByID(string id)
        {
          return   _ourSpecialDal.GetByID(id);
        }

        public List<OurSpecial> TGetList()
        {
            return _ourSpecialDal.GetList();
        }

        public void TInsert(OurSpecial t)
        {
            _ourSpecialDal.Insert(t);
        }

        public void TUpdate(OurSpecial t)
        {
            _ourSpecialDal.Update(t);
        }
    }
}
