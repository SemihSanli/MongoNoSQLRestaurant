﻿using Restaurant.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        Task<List<Product>> GetProductByCategoryIdAsync(string categoryId); 
    }
}
