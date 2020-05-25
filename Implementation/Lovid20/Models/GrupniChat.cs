using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lovid20.Models
{
    public class GrupniChat
    {
        public List<RegistrovaniKorisnik> clanovi { get; set; }
        public List<Poruka> poruke { get; set; }
        public GrupniChat(List<RegistrovaniKorisnik> participants, List<Poruka> mssgs)
        {
            clanovi = participants; poruke = mssgs;
        }
        public void dodajPoruku(Poruka poruka)
        {
            throw new NotImplementedException();
        }
    }
}
