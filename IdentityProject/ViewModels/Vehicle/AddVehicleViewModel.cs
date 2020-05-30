using IdentityProject.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityProject.ViewModels
{
    public class AddVehicleViewModel
    {
        
        public IEnumerable<Color> ColorList { get; set; }
        public IEnumerable<EngineEmission> EngineEmissionList { get; set; }
        public IEnumerable<Manufacturer> ManufacturerList { get; set; }
        public IEnumerable<VehicleType> VehicleTypeList { get; set; }
        public IEnumerable<VehicleModel> VehicleModelList { get; set; }
        public Variant Variant { get; set; }
        public VehicleMedia VehicleMedia { get; set; }

        public UserRating UserRating { get; set; }
    }
}