using System;
using System.Collections.Generic;

namespace Lovid_API
{
    public partial class Recenzija
    {
        public int Id { get; set; }
        public int Korisnik { get; set; }
        public string Tekst { get; set; }
        public int Ocjena { get; set; }
        public DateTime Datum { get; set; }

        public virtual RegistrovaniKorisnik KorisnikNavigation { get; set; }
    }
}
