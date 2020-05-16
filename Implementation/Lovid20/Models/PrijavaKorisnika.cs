using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lovid20.Models
{
    public class PrijavaKorisnika
    {
        private RegistrovaniKorisnik prijavljeni { get; set; }
        private String razlog { get; set; }
        private DateTime datumPrijave { get; }

        public PrijavaKorisnika(RegistrovaniKorisnik prijavljeni, String razlog)
        {
            this.prijavljeni = prijavljeni;
            this.razlog = razlog;
            datumPrijave = DateTime.Now;
        }


    }
}
