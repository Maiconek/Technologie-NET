using Newtonsoft.Json.Bson;
using RejestrPracowników.Pracownicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracownicyTesty
{
    [TestFixture]
    public class AddressTest
    {
        Address _adres;
        
        [SetUp]
        public void Setup() {
            _adres = new Address("Jaskolcza", "15", "2", "Gdynia");
        }

        [Test]
        public void CheckIfGetCityWorks()
        {
            var miasto = _adres.City;

            Assert.That(miasto, Is.EqualTo("Gdynia"));
        }

        [Test]
        public void CheckIfGetStreetNameWorks()
        { 
            var ulica = _adres.StreetName;
            Assert.That(ulica, Is.EqualTo("Jaskolcza"));
        }
    }
}
