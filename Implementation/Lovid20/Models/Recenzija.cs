using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lovid20.Models
{
    public class Recenzija
    {
        public String tekst { get; set; }
        public int brojZvjezdica { get; set; }
        public DateTime datumObjave { get; }
        public RegistrovaniKorisnik autor { get; set; }
        public Recenzija(String text, int stars, RegistrovaniKorisnik author)
        {
            tekst = text; brojZvjezdica = stars; autor = author; datumObjave = DateTime.Now;
        }
    }
}
