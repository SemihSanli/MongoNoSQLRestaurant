using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T :class
    {
        void TInsert(T t);
        void TUpdate(T t);
        void TDelete(string id);
        List<T> TGetList();
        T TGetByID(string id);
    }
}
