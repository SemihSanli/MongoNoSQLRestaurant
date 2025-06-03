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
    public class GalleryManager : IGalleryService
    {
        private readonly IGalleryDal _galleryDal;

        public GalleryManager(IGalleryDal galleryDal)
        {
            _galleryDal = galleryDal;
        }

        public void TDelete(string id)
        {
            _galleryDal.Delete(id);
        }

        public Gallery TGetByID(string id)
        {
          return _galleryDal.GetByID(id);
        }

        public List<Gallery> TGetList()
        {
            return _galleryDal.GetList();
        }

        public void TInsert(Gallery t)
        {
           _galleryDal.Insert(t);
        }

        public void TUpdate(Gallery t)
        {
           _galleryDal.Update(t);
        }
    }
}
