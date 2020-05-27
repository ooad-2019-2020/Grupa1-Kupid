using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lovid20.Models
{
    public class RecenzijaDB
    {
        public int id { get; set; }
        public int korisnik { get; set; }
        public string tekst { get; set; }
        public int ocjena { get; set; }
        public DateTime datum { get; set; }
        [ForeignKey("korisnik")]

        public virtual RegistrovaniKorisnikDB Korisnik { get; set; }
    }
}