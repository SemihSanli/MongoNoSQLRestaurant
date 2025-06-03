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
    public class ContactDetailManager : IContactDetailService
    {
        private readonly IContactDetailDal _contactDetailDal;

        public ContactDetailManager(IContactDetailDal contactDetailDal)
        {
            _contactDetailDal = contactDetailDal;
        }

        public void TDelete(string id)
        {
           _contactDetailDal.Delete(id);
        }

        public ContactDetail TGetByID(string id)
        {
          return _contactDetailDal.GetByID(id);
        }

        public List<ContactDetail> TGetList()
        {
           return  _contactDetailDal.GetList();
        }

        public void TInsert(ContactDetail t)
        {
            _contactDetailDal.Insert(t);
        }

        public void TUpdate(ContactDetail t)
        {
           _contactDetailDal.Update(t);
        }
    }
}
