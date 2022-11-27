using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrPracowników.Pracownicy
{
    public class Address
    {
        public String StreetName { get; set; }
        public String NumberOfBuilding { get; set; }
        public String NumberOfApartment { get; set; }
        public String City { get; set; }

        public Address(string streetName, string numberOfBuilding, string numberOfApartment, string city)
        {
            StreetName = streetName;
            NumberOfBuilding = numberOfBuilding;
            NumberOfApartment = numberOfApartment;
            City = city;
        }
    }
}
