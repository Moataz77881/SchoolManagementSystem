using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
