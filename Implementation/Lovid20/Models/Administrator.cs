using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Manage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lovid20.Models
{
    public class Administrator : IPregledPaketa, IPretragaKorisnika
    {
        public String email { get; set; }
        public String lozinka { get; set; }
      //  IStrategija strategija;
        
        public Administrator(String email, String lozinka)
        {
            this.email = email;
            this.lozinka = lozinka;
        }
        public List<String> pregledajPakete()
        {
            throw new NotImplementedException();
        }

        public List<RegistrovaniKorisnik> pretraziKorisnike(String filter)
        {
            throw new NotImplementedException();
        }

        public void obrisiKorisnika(RegistrovaniKorisnik korisnik)
        {
            throw new NotImplementedException();
        }
    }
}
