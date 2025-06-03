using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.EntityLayer.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public string FullName { get; set; }
    }
}
