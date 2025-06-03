using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.ServiceDTO
{
    public class GetServiceDTO
    {
        public string Id { get; set; }
        public string ServiceTitle { get; set; }
        public int ServicePrice { get; set; }
        public string ServiceSubTitle { get; set; }
        public string ServiceArticle { get; set; }
        public string ServiceMinDescription { get; set; }
        public string ServiceImageURL { get; set; }
    }
}
