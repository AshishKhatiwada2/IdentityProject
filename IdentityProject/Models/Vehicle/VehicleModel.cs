using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityProject.Models.Vehicle
{
    public class VehicleModel 
    {

        
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model_Name { get; set; }
        
        public float Popularity { get; set; }
        
        public bool IsActive { get; set; } 
        public float User_Rating { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? AddedDate { get; set; }

        public int? VehicleTypeId { get; set; }

        public virtual VehicleType VehicleType { get; set; }
        public  ApplicationUser Added_User {get;set;}
        



    }
}