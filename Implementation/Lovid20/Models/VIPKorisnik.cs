using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lovid20.Models
{
    public class VIPKorisnik : RegistrovaniKorisnik
    {
        public DateTime datumIstekaVIP { get; set; }
        public VIPKorisnik(String ime, String prezime, String drzava, String grad, String username, String email, String biografija, DateTime datumRodjenja, String spol, String stanje, DateTime datumIstekaVIP) : base(ime, prezime, drzava, grad, username, email, biografija, datumRodjenja, spol, stanje)
        {
            this.datumIstekaVIP = datumIstekaVIP;
        }
    }
}
