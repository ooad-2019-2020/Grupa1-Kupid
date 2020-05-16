using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lovid20.Models
{
    interface IProfil
    {
        public void urediProfil(String ime, String prezime, String username, String grad, String drzava, String biografija, DateTime datumRodjenja);
        public void promijeniLozinku(String lozinka);
        public void obrisiRacun();
    }
}
