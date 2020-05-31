
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentityProject.Models.Vehicle
{ 
    public class UserRating
    {
        public int Id { get; set; }
        public string UserComment { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Date { get; set; }
        public int ViewNumber { get; set; }
        public virtual ApplicationUser Added_User { get; set; }

    }
}