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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task<List<Product>> GetProductByCategoryIdAsync(string categoryId)
        {
            return await _productDal.GetProductByCategoryIdAsync(categoryId);
        }

        public void TDelete(string id)
        {
            _productDal.Delete(id);
        }

        public Product TGetByID(string id)
        {
           return _productDal.GetByID(id);
        }

        public List<Product> TGetList()
        {
            return _productDal.GetList();
        }

        public void TInsert(Product t)
        {
            _productDal.Insert(t);
        }

        public void TUpdate(Product t)
        {
          _productDal.Update(t);
        }
    }
}
