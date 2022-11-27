using RejestrPracowników.Pracownicy;
using System;
using System.Net;

namespace RejestrPracownikow
{
    public abstract class Pracownik : IComparable<Pracownik>
    {   
        public String Id { get; set; }
        public String Imie { get; set; }
        public String Nazwisko { get; set; }
        public int Wiek { get; set; }
        public int Doswiadczenie { get; set; }
        public Address Adres { get; set; }

        public Pracownik(string imie, string nazwisko, int wiek, int doswiadczenie, Address adres)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Doswiadczenie = doswiadczenie;
            Adres = adres;
            Id = Guid.NewGuid().ToString();
        }

        public int CompareTo(Pracownik inny)
        {
            int i = Doswiadczenie.CompareTo(inny.Doswiadczenie);
            if (i > 0)
                return -1;
            if (i < 0)
                return 1;
            i = Wiek.CompareTo(inny.Wiek);
            if (i > 0)
                return 1;
            if (i < 0)
                return -1;
            return Nazwisko.CompareTo(inny.Nazwisko);
        }

        public abstract int ValueForCompany();

        public override string ToString()
        {
            return $"Imie: {Imie};Nazwisko: {Nazwisko};Doświadczenie: {Doswiadczenie};Wiek: {Wiek};Wartość Pracownika: {ValueForCompany()} ;Miasto: {Adres.City};";
        }
    }
}