using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lovid20.Models
{
    interface IPretragaKorisnika
    {
        public List<RegistrovaniKorisnik> pretraziKorisnike(String filter);
    }
}
