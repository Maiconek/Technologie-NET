using RejestrPracownikow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrPracowników.Pracownicy
{
    public class PracownikFizyczny : Pracownik
    {
        public int _SilaFizyczna;
        public int SilaFizyczna
        {
            get => _SilaFizyczna;
            set
            {
                if (value < 1) {
                    throw new Exception("Podana siła jest za mała");
                } else if(value > 100) {
                    throw new Exception("Podana siła jest za wysoka");
                } else
                {
                    _SilaFizyczna = value;
                }
            }
        }

        public PracownikFizyczny(string imie, string nazwisko, int wiek, int doswiadczenie, Address adres, int silaFizyczna)
            : base(imie, nazwisko, wiek, doswiadczenie, adres)
        {
            SilaFizyczna = silaFizyczna;
        }

        public override int ValueForCompany() {
            return Doswiadczenie * SilaFizyczna / Wiek; 
        }

        public override string ToString()
        {
            return base.ToString() + $"Siła Fizyczna: {SilaFizyczna}\n";
        }
    }
}
