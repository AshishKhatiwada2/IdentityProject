using IdentityProject.Models.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityProject.ViewModels
{
    public class AddressViewModel
    {
        public IEnumerable<Continent> ContinentList { get; set; }
        public IEnumerable<Country> CountryList { get; set; }
        public IEnumerable<State> StateList { get; set; }
        public IEnumerable<City> CityList { get; set; }
        public IEnumerable<Street> StreetList { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
        public Street Street { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public UserAddress UserAddress { get; set; }
    }
}