using System;
using System.Collections.Generic;
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
        public DateTime AddedDate { get; set; }
        public bool IsActive { get; set; }
        public virtual List<VehicleType> VehicleTypes { get; set; }
    }
}