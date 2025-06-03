using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.FeatureDTO
{
    public class UpdateFeatureDTO
    {
        public string Id { get; set; }
        public string FeatureTitle { get; set; }
        public string FeatureSubTitle { get; set; }
        public string FeatureImageURL { get; set; }
    }
}
