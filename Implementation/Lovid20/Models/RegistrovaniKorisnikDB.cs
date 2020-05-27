using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Lovid20.Models
{
    public class RegistrovaniKorisnikDB
    {
        public int idKorisnika { get; set; }
        public String lozinka { get; set; }
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
        [AllowNull]
        public DateTime trajanjeVIP { get; set; }

        public virtual TipKorisnika Tip { get; set; }
        public virtual PrijavaDB Prijava { get; set; }
        public virtual RecenzijaDB Recenzija { get; set; }
        [NotMapped]
        public virtual Pratitelji Pratitelji { get; set; }
        [NotMapped]
        public virtual KorisnikUChatu KorisnikUChatu { get; set; }
    }
}
