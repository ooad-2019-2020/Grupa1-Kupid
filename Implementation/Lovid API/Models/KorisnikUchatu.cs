using System;
using System.Collections.Generic;

namespace Lovid_API
{
    public partial class KorisnikUchatu
    {
        public int ChatId { get; set; }
        public int KorisnikId { get; set; }

        public virtual Chat Chat { get; set; }
        public virtual RegistrovaniKorisnik Korisnik { get; set; }
    }
}
