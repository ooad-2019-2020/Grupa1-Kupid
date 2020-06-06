using System;
using System.Collections.Generic;

namespace Lovid_API
{
    public partial class RegistrovaniKorisnik
    {
        public int Id { get; set; }
        public int IdKorisnika { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Drzava { get; set; }
        public string Grad { get; set; }
        public string Username { get; set; }
        public string Slika { get; set; }
        public string Email { get; set; }
        public string Biografija { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Spol { get; set; }
        public string Stanje { get; set; }
        public DateTime TrajanjeVip { get; set; }
        public int? Pratitelji { get; set; }

        public virtual Prijava IdNavigation { get; set; }
        public virtual Recenzija Recenzija { get; set; }
        public virtual TipKorisnika TipKorisnika { get; set; }
    }
}
