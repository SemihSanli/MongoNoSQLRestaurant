using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.AboutDTO
{
    public class UpdateAboutDTO
    {
        public string Id { get; set; }
        public string AboutTitle { get; set; }
        public string AboutSubTitle { get; set; }
        public string AboutArticle { get; set; }
        public string AboutDescription { get; set; }
        public string AboutImageURL { get; set; }
    }
}
