using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lovid20.Models
{
    public abstract class Korisnik
    {
        //public int idKorisnika { get; set; }
        // public String lozinka { get; set; }
      //  public int ID { get; set; }
        public String ime { get; set; }
        public String prezime { get; set; }
        public String drzava { get; set; }
        public String grad { get; set; }
        public String username { get; set; }
        public String slika { get; set; }
        public String email { get; set; }
        public String biografija { get; set; }
        public DateTime datumRodjenja { get; set; }
        public String spol { get; set; }
        public String stanje { get; set; }


        public Korisnik(String ime, String prezime, String drzava, String grad, String username, String email, String biografija, DateTime datumRodjenja, String spol, String stanje)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.drzava = drzava;
            this.grad = grad;
            this.username = username;
            this.email = email;
            this.biografija = biografija;
            this.datumRodjenja = datumRodjenja;
            this.spol = spol;
            this.stanje = stanje;

        }
    }
}
