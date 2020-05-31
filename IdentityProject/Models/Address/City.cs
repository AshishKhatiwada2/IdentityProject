using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentityProject.Models.Address
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? AddedDate { get; set; }
        public bool IsActive { get; set; }
        public virtual ApplicationUser Added_User { get; set; }
        public virtual State State { get; set; }
    }
}