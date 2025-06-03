using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.BookATableDTO
{
    public class ResultATableDTO
    {
        public string Id { get; set; }
        public string BookFullName { get; set; }
        public string BookEmail { get; set; }
        public string BookPhone { get; set; }
        public DateTime BookDate { get; set; }
        public int BookPersonCount { get; set; }
        public string BookMessage { get; set; }
    }
}
