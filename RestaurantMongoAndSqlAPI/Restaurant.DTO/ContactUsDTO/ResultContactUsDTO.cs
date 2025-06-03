using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.ContactUsDTO
{
    public class ResultContactUsDTO
    {
        public string Id { get; set; }
        public string ContactUsFullName { get; set; }
        public string ContactUsEmail { get; set; }
        public string ContactUsSubject { get; set; }
        public string ContactUsMessage { get; set; }
    }
}
