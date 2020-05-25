using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lovid20.Models
{
    public class Poruka
    {
        public RegistrovaniKorisnik posiljalac { get; set; }
        public RegistrovaniKorisnik primalac { get; set; }
        public String poruka { get; set; }
        public Poruka(RegistrovaniKorisnik sender, RegistrovaniKorisnik reciever, String mssg){
            posiljalac = sender; primalac = reciever; poruka = mssg;
    }
}
