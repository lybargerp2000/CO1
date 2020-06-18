using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CO.Models
{
    public class Associate
    {
        public int AssociateId { get; set; }
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        [Display(Name = "First Name")]
        public IdentityUser IdentityUser { get; set; }
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Description { get; set; }
    }
}
