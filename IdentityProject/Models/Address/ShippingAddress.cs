using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentityProject.Models.Address
{
    public class ShippingAddress
    {
        public int Id { get; set; }
        public int? ContinentId { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public int? StreetId { get; set; }

        public virtual Continent continent { get; set; }
        public virtual Country country { get; set; }
        public virtual State state { get; set; }
        public virtual City city { get; set; }
        public virtual Street street { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? AddedDate { get; set; }
        public bool IsActive { get; set; }
    }
}