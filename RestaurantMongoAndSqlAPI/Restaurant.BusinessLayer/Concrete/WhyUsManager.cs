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
    public class WhyUsManager : IWhyUsService
    {
        private readonly IWhyUsDal _whyUsDal;

        public WhyUsManager(IWhyUsDal whyUsDal)
        {
            _whyUsDal = whyUsDal;
        }

        public void TDelete(string id)
        {
            _whyUsDal.Delete(id);
        }

        public WhyUs TGetByID(string id)
        {
          return  _whyUsDal.GetByID(id);
        }

        public List<WhyUs> TGetList()
        {
           return _whyUsDal.GetList();
        }

        public void TInsert(WhyUs t)
        {
            _whyUsDal.Insert(t);
        }

        public void TUpdate(WhyUs t)
        {
            _whyUsDal.Update(t);
        }
    }
}
