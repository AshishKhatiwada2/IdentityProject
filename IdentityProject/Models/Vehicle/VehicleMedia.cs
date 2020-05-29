using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityProject.Models.Vehicle
{
    public class VehicleMedia
    {
        public int Id { get; set; }
        public DateTime Added_Date { get; set; }
        public string Path { get; set; }
        public virtual  VehicleModel  VehicleModel { get; set; }
        public bool IsActive { get; set; }
        public virtual ApplicationUser Added_User { get; set; }
    }
}