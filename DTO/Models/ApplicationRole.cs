using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class ApplicationRole : IdentityRole
    {        
        public string IPAddress { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
