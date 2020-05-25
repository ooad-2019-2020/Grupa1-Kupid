using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lovid20.Models
{
    public class Chat : IDodajPoruku
    {
        public RegistrovaniKorisnik prvi { get; set; }
        public RegistrovaniKorisnik drugi { get; set; }
        public List<Poruka> poruke { get; set; }

        public Chat(RegistrovaniKorisnik first, RegistrovaniKorisnik second, List<Poruka> mssg)
        {
            prvi = first; drugi = second; poruke = mssg;
        }

        public void dodajPoruku(Poruka poruka)
        {
            throw new NotImplementedException();
        }
    }
}
