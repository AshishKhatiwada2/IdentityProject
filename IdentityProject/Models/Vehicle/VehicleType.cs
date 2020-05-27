using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityProject.Models.Vehicle
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
       
        public bool IsActive { get; set; }
        public List<VehicleModel> vehicleModel { get; set; }
        public virtual ApplicationUser Added_User { get; set; }
    }
}