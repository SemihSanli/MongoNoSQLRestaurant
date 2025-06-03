using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.ProductDTO
{
    public class GetProductDTO
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string ProducContent { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageURL { get; set; }
        public string CategoryId { get; set; }
    }
}
