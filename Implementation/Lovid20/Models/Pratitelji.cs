using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lovid20.Models
{
    public class Pratitelji
    {
        public int id { get; set; }
        public int pratitelji { get; set; }
        [ForeignKey("id")]
        [NotMapped]
        public virtual RegistrovaniKorisnikDB Korisnik { get; set; }
        [ForeignKey("pratitelji")]

        public virtual ICollection<RegistrovaniKorisnikDB> Korisnici { get; set; }
    }
}