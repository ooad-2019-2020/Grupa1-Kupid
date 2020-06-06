using System;
using System.Collections.Generic;

namespace Lovid_API
{
    public partial class Prijava
    {
        public int Id { get; set; }
        public string Razlog { get; set; }
        public DateTime Datum { get; set; }

        public virtual RegistrovaniKorisnik RegistrovaniKorisnik { get; set; }
    }
}
