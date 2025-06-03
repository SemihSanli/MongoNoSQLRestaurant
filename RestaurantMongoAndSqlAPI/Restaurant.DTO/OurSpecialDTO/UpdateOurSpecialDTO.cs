using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.OurSpecialDTO
{
    public class UpdateOurSpecialDTO
    {
        public string Id { get; set; }
        public string OurSpecialColumnTitle { get; set; }
        public string OurSpecialTitle { get; set; }
        public string OurSpecialContent { get; set; }
        public string OurSpecialImageURL { get; set; }
    }
}
