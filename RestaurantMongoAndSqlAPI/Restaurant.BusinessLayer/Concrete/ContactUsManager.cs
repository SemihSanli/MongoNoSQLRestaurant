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
    public class ContactUsManager : IContactUsService
    {
        private readonly IContactUsDal _contactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public void TDelete(string id)
        {
            _contactUsDal.Delete(id);
        }

        public ContactUs TGetByID(string id)
        {
           return _contactUsDal.GetByID(id);
        }

        public List<ContactUs> TGetList()
        {
            return _contactUsDal.GetList();
        }

        public void TInsert(ContactUs t)
        {
           _contactUsDal.Insert(t);
        }

        public void TUpdate(ContactUs t)
        {
           _contactUsDal.Update(t);
        }
    }
}
