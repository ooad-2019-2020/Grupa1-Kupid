using System.ComponentModel.DataAnnotations.Schema;

namespace Lovid20.Models
{
    public class KorisnikUChatu
    {
        public int chatID { get; set; }
        public int korisnikID { get; set; }
        [ForeignKey("chatID")]

        public virtual ChatDB Chat { get; set; }
        [ForeignKey("korisnikID")]
        public virtual RegistrovaniKorisnikDB Korisnik { get; set; }
    }
}