using RejestrPracownikow;
using RejestrPracowników.Pracownicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracownicyTesty
{
    [TestFixture]
    public class RejestrTest
    {
        public Rejestr _rejestr;
        public Handlarz _handlarz;
        public Handlarz _handlarz2;
        public PracownikBiurowy _pracownikBiurowy;
        public PracownikBiurowy _pracownikBiurowy2;
        public PracownikBiurowy _pracownikBiurowy3;
        public PracownikFizyczny _pracownikFizyczny;
        public PracownikFizyczny _pracownikFizyczny2;
        public PracownikFizyczny _pracownikFizyczny3;
        public Address _adres;
        public Address _adres2;
        public Address _adres3;
        public Address _adres4;
        public Address _adres5;

        [SetUp]
        public void Setup()
        {
            _rejestr = new Rejestr();
            _adres = new Address("Jeziorna", "22", "5", "Warszawa");
            _adres2 = new Address("Jeziorna", "22", "5", "Sopot");
            _adres3 = new Address("Jeziorna", "24", "6", "Sopot");
            _adres4 = new Address("Jeziorna", "23", "7", "Sopot");
            _adres5 = new Address("Długa", "40", "3", "Reda");

            _handlarz = new Handlarz("Mirosław", "Baka", 52, 7, _adres, Handlarz.Skutecznosc.SREDNIA, 50);
            _handlarz2 = new Handlarz("Wojtek", "Warchol", 32, 2, _adres, Handlarz.Skutecznosc.NISKA, 23);
            _pracownikBiurowy = new PracownikBiurowy("Daniel", "Nowak", 30, 5, _adres2, 90);
            _pracownikBiurowy2 = new PracownikBiurowy("Damian", "Wasik", 20, 1, _adres, 80);
            _pracownikBiurowy3 = new PracownikBiurowy("Wiesław", "Paleta", 60, 30, _adres5, 70);
            _pracownikFizyczny = new PracownikFizyczny("Mariusz", "Pudzianowski", 46, 6, _adres3, 99);
            _pracownikFizyczny2 = new PracownikFizyczny("Marcin", "Najman", 40, 6, _adres4, 2);
            _pracownikFizyczny3 = new PracownikFizyczny("Karol", "Kaszuba", 40, 6, _adres2, 70);

            // Dodanie pracowników do rejestru
            _rejestr.addPracownik(_handlarz);
            _rejestr.addPracownik(_pracownikFizyczny);
            _rejestr.addPracownik(_pracownikFizyczny2);
            _rejestr.addPracownik(_pracownikFizyczny3);

        }

        [Test]
        public void AddPracownik()
        {
            _rejestr.addPracownik(_pracownikBiurowy);
            Assert.That(_rejestr.pracownicy.Contains(_pracownikBiurowy), Is.EqualTo(true));
        }
        [Test]
        public void DeletePracownik()
        {
            Assert.That(_rejestr.deletePracownik(_handlarz.Id), Is.EqualTo(true));
        }
        [Test]
        public void DodajKilkuPracownikow()
        {
            _rejestr.DodajPracownikow(_handlarz2, _pracownikBiurowy2, _pracownikBiurowy3);
            Assert.That(_rejestr.pracownicy.Contains(_handlarz2), Is.EqualTo(true)); 
            Assert.That(_rejestr.pracownicy.Contains(_pracownikBiurowy2), Is.EqualTo(true));
            Assert.That(_rejestr.pracownicy.Contains(_pracownikBiurowy3), Is.EqualTo(true));
        }
        [Test]
        public void CityList()
        {
            List<Pracownik> p = _rejestr.city(_rejestr.pracownicy, "Sopot");
            Assert.That(p.Contains(_pracownikFizyczny), Is.EqualTo(true));
            Assert.That(p.Contains(_pracownikFizyczny2), Is.EqualTo(true));
            Assert.That(p.Contains(_pracownikFizyczny3), Is.EqualTo(true));
        }
        [Test]
        public void WszyscyPracownicySorted()
        {
            List<Pracownik> p = _rejestr.allPracownicy();
            var a = p.ToArray();

            Assert.That(a[0], Is.EqualTo(_handlarz));
            Assert.That(a[1], Is.EqualTo(_pracownikFizyczny3));
            Assert.That(a[2], Is.EqualTo(_pracownikFizyczny2));
            Assert.That(a[3], Is.EqualTo(_pracownikFizyczny));
        }
        [Test]
        public void PracownikValueTest()
        {
            Assert.That(_handlarz.ValueForCompany(), Is.EqualTo(560));
            Assert.That(_pracownikFizyczny.ValueForCompany(), Is.EqualTo(12));
            Assert.That(_pracownikFizyczny2.ValueForCompany(), Is.EqualTo(0));
        }
    }
}
