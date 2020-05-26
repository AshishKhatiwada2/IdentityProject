using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityProject.Models.Vehicle
{
    public class EngineEmission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public bool IsActive { get; set; }
        public virtual ApplicationUser Added_User { get; set; }
        
    }
}