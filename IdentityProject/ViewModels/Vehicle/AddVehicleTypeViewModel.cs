using IdentityProject.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityProject.ViewModels
{
    public class AddVehicleTypeViewModel
    {
        public virtual List<Manufacturer> ManufacturerList { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}