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
    public class BookATableManager : IBookATableService
    {
        private readonly IBookATableDal _bookATableDal;
        public BookATableManager(IBookATableDal bookATableDal)
        {
            _bookATableDal = bookATableDal;
        }

        public void TDelete(string id)
        {
           _bookATableDal.Delete(id);
        }

        public BookATable TGetByID(string id)
        {
            return _bookATableDal.GetByID(id);
        }

        public List<BookATable> TGetList()
        {
           return _bookATableDal.GetList();
        }

        public void TInsert(BookATable t)
        {
           _bookATableDal.Insert(t);
        }

        public void TUpdate(BookATable t)
        {
            _bookATableDal.Update(t);
        }
    }
}
