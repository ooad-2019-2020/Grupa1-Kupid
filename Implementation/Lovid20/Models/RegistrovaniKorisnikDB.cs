using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Lovid20.Models
{
    public class RegistrovaniKorisnikDB
    {
        [Key]
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
        [NotMapped]
        public virtual TipKorisnika Tip { get; set; }
        [NotMapped]
        public virtual PrijavaDB Prijava { get; set; }
        [NotMapped]
        public virtual RecenzijaDB Recenzija { get; set; }
        [NotMapped]
        public virtual Pratitelji Pratitelji { get; set; }
        [NotMapped]
        public virtual KorisnikUChatu KorisnikUChatu { get; set; }
        public RegistrovaniKorisnikDB()
        {

        }
        public RegistrovaniKorisnikDB(String name, String pass, String sur, String mail, int id)
        {
            idKorisnika = id;
            ime = name;
            lozinka = pass;
            prezime = sur;
            email = mail;
            trajanjeVIP = new DateTime(2025, 5, 5);
            datumRodjenja = new DateTime(2002, 6, 6);
        }
    }
}
