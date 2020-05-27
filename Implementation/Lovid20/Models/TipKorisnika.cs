using System.ComponentModel.DataAnnotations.Schema;

namespace Lovid20.Models
{
    public class TipKorisnika
    {
        public int id { get; set; }
        public string naziv { get; set; }
        [ForeignKey("id")]

        public virtual RegistrovaniKorisnikDB Korisnik {get;set;}
    }
}