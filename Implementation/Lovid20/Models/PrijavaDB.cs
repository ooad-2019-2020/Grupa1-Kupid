using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lovid20.Models
{
    public class PrijavaDB
    {
        public int id { get; set; }
        public string razlog { get; set; }
        public DateTime datum { get; set; }
        [ForeignKey("id")]

        public virtual ICollection<RegistrovaniKorisnikDB> Korisnici { get; set; }
    }
}