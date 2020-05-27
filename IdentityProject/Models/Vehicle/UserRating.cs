
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityProject.Models.Vehicle
{ 
    public class UserRating
    {
        public int Id { get; set; }
        public string UserComment { get; set; }
        public DateTime Date { get; set; }
        public int ViewNumber { get; set; }
        public virtual ApplicationUser Added_User { get; set; }

    }
}