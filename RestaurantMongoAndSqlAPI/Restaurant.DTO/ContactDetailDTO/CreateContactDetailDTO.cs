using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.ContactDetailDTO
{
    public class CreateContactDetailDTO
    {
        public string ContactDetailLocation { get; set; }
        public string ContactDetailLocationMapURL { get; set; }
        public string ContactDetailOpenHours { get; set; }
        public string ContactDetailCallUs { get; set; }
        public string ContactDetailEmailUs { get; set; }
    }
}
