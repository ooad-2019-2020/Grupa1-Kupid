using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lovid20.Models
{
    public class ChatDB
    {
        public int id { get; set; }
        [NotMapped]
        public virtual KorisnikUChatu KorisnikUChatu { get; set; }
        [NotMapped]
        public virtual ICollection<PorukaDB> Poruke { get; set; }
    }
}