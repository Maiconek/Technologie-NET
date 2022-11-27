using RejestrPracownikow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrPracowników.Pracownicy
{
    public class Rejestr
    {
        public List<Pracownik> pracownicy = new List<Pracownik>();

        public Pracownik addPracownik(Pracownik pracownik)
        {
            pracownicy.Add(pracownik);
            return pracownik;
        }

        public Boolean deletePracownik(String Id) {
            
            foreach (var p in pracownicy) {
                if (Object.Equals(p.Id, Id)) {
                    pracownicy.Remove(p);
                    return true;
                }
            }

            return false;
        }

        public void DodajPracownikow(params Pracownik[] _pracownicy)
        {
            foreach (var pracownik in _pracownicy)
            {
                pracownicy.Add(pracownik);
            }
        }

        public List<Pracownik> allPracownicy()
        {
            pracownicy.Sort();
            return pracownicy;
        }


        public List<Pracownik> city(List<Pracownik> pracownicy, String miasto) 
        {
            List<Pracownik> pMiasto = new List<Pracownik>();
            foreach (var p in pracownicy) { 
                if(p.Adres.City.Equals(miasto))
                {
                    pMiasto.Add(p);
                } 
            }

            return pMiasto;
        }

        public List<Pracownik> pracownikWithValue(List<Pracownik> pracownicy)
        {
            List<Pracownik> list = new List<Pracownik>();
            foreach(var p in pracownicy)
            {
                Console.WriteLine(p.ToString + " " + p.ValueForCompany());
            }

            return list;
        }

       
    }
}
