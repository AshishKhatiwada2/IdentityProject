using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentityProject.Models.Vehicle
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string OriginCountry { get; set; }
        public string BusinessNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? AddedDate { get; set; }
        public bool IsActive { get; set; }
       
        public virtual ApplicationUser Added_User { get; set; }
        
    }
}