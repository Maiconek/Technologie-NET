using RejestrPracownikow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrPracowników.Pracownicy
{
    public class PracownikBiurowy : Pracownik
    {
        public int StanowiskoBiuroweCounter = 0;
        public int StanowiskoBiuroweID { get; set; }
        public int _IQ;
        public int IQ {
            get => _IQ;
            set
            {
                if(value < 70)
                {
                    throw new Exception("Podane IQ jest za małe");
                } 
                else if(value > 150)
                {
                    throw new Exception("Podane IQ jest za wysokie");
                } else
                {
                    _IQ = value;
                }
            }
        }

        public PracownikBiurowy(string imie, string nazwisko, int wiek, int doswiadczenie, Address adres, int iq)
            : base(imie, nazwisko, wiek, doswiadczenie, adres) 
        {
            IQ = iq;
            StanowiskoBiuroweID = GenerateOfficeDeskNumber();
        }
        

        public override int ValueForCompany()
        {
            return Doswiadczenie * IQ;
        }

        public override string ToString()
        {
            return base.ToString() + $"IQ: {IQ} ; ID Pracownika Biurowego: {StanowiskoBiuroweID}\n";
        }

        private int GenerateOfficeDeskNumber()
        {
            Interlocked.Increment(ref StanowiskoBiuroweCounter);
            return StanowiskoBiuroweCounter;
        }
    }
}
