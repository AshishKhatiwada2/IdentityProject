using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityProject.Models.Vehicle
{
    public class VehicleMedia
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public virtual List<VehicleModel>  Motorcycle { get; set; }
    }
}