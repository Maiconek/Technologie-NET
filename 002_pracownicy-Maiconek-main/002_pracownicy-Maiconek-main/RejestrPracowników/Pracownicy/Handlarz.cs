using RejestrPracownikow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrPracowników.Pracownicy
{
    public class Handlarz : Pracownik
    {
        public enum Skutecznosc : int {
            NISKA = 60,
            SREDNIA = 80,
            WYSOKA = 120
        }

        public Skutecznosc skutecznosc { get; set; }
        public decimal Prowizja { get; set; }

        public Handlarz(string imie, string nazwisko, int wiek, int doswiadczenie, Address adres, Skutecznosc _skutecznosc
            , decimal prowizja)
            : base(imie, nazwisko, wiek, doswiadczenie, adres)
        {
            skutecznosc = _skutecznosc;
            Prowizja = prowizja;
        }

        public override int ValueForCompany()
        {
            return Doswiadczenie * (int)(skutecznosc);
        }

        public override string ToString()
        {
            return base.ToString() + $"Efektywnosc: {Enum.GetName(skutecznosc.GetType(), skutecznosc)};Prowizja: {Prowizja} % \n";
        }


    }
}
