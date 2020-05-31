using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentityProject.Models.Vehicle
{
    public class EngineEmission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? AddedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? EffectiveDate { get; set; }

        public bool IsActive { get; set; }
        public virtual ApplicationUser Added_User { get; set; }
        
    }
}