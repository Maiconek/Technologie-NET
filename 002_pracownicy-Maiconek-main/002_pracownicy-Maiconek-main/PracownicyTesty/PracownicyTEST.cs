using NUnit.Framework;
using RejestrPracowników.Pracownicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RejestrPracowników
{
    [TestFixture]
    public class Test
    {
        public Handlarz _handlarz;
        public PracownikBiurowy _pracownikBiurowy;
        public PracownikFizyczny _pracownikFizyczny;
        public Address _adres;
        public Address _adres2;
        public Address _adres3;


        [SetUp]
        public void Setup()
        {
            _adres = new Address("Radunska", "22", "5", "Gdynia");
            _adres2 = new Address("Sokola", "3", "2", "Gdynia");
            _adres3 = new Address("Kcynska", "14", "3", "Gdynia");
            _handlarz = new Handlarz("Kamil", "Zdun", 52, 20, _adres, Handlarz.Skutecznosc.SREDNIA, 50);
            _pracownikBiurowy = new PracownikBiurowy("Daniel", "Nowak", 30, 5, _adres2, 90);
            _pracownikFizyczny = new PracownikFizyczny("Mariusz", "Pudzianowski", 26, 6, _adres3, 99);
        }

        [Test]
        public void CheckIfTestWorks()
        {
            Assert.Pass();
        }

        [Test]
        public void CheckIfGetWorks()
        {

            Assert.That(_handlarz.Imie, Is.EqualTo("Kamil"));

        }
        [Test]
        public void getIQ()
        {
            Assert.That(_pracownikBiurowy.IQ, Is.EqualTo(90));
        }
        [Test]
        public void TooLowIQException()
        {
            Assert.Throws<Exception>(() => _pracownikBiurowy.IQ = 40);
        }
        [Test]
        public void TooHigIQException()
        {
            Assert.Throws<Exception>(() => _pracownikBiurowy.IQ = 200);
        }
        [Test]
        public void TooLowSilaFizycznaException()
        {
            Assert.Throws<Exception>(() => _pracownikFizyczny.SilaFizyczna = -2);
        }
        [Test]
        public void TooHighSilaFizycznaException()
        {
            Assert.Throws<Exception>(() => _pracownikFizyczny.SilaFizyczna = 104);
        }
    }
}


