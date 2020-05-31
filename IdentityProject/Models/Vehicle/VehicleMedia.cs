using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentityProject.Models.Vehicle
{
    public class VehicleMedia
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Added_Date { get; set; }
        public string Path { get; set; }

        public int? VehicleModelId { get; set; }
        public int? VariantId { get; set; }
        public virtual  VehicleModel  VehicleModel { get; set; }
        public virtual Variant Variant { get; set; }
        public bool IsActive { get; set; }
        public virtual ApplicationUser Added_User { get; set; }
    }
}