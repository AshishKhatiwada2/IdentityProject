using IdentityProject.Models.Address;

using IdentityProject.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentityProject.Models
{
    public class MainApplicationDBContext : ApplicationDbContext
    {
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<EngineEmission> EngineEmissions { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }
        public DbSet<VehicleMedia> VehicleMedias { get; set; }
        
        public DbSet<Variant> Variants { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        public System.Data.Entity.DbSet<IdentityProject.Models.Address.City> Cities { get; set; }

        
    }
}