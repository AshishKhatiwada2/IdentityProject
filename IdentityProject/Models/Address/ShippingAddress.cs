using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityProject.Models.Address
{
    public class ShippingAddress
    {
        public int Id { get; set; }
        public virtual Continent continent { get; set; }
        public virtual Country country { get; set; }
        public virtual State state { get; set; }
        public virtual City city { get; set; }
        public virtual Street street { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime AddedDate { get; set; }
        public bool IsActive { get; set; }
    }
}