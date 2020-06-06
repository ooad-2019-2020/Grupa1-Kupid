using System;
using System.Collections.Generic;

namespace Lovid_API
{
    public partial class TipKorisnika
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual RegistrovaniKorisnik IdNavigation { get; set; }
    }
}
