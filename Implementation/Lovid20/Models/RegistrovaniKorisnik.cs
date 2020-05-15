using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Models
{
    public class RegistrovaniKorisnik : Korisnik, IPregledPaketa
    {
        private int _brojPratitelja;
        private List<RegistrovaniKorisnik> pratitelji;

        public int brojPratitelja { get; set; }
        public List<RegistrovaniKorisnik> Pratitelji { get => pratitelji; set => pratitelji = value; }
        //IStrategija strategija;

        public RegistrovaniKorisnik(String ime, String prezime, String drzava, String grad, String username, String email, String biografija, DateTime datumRodjenja, String spol, String stanje) : base(ime, prezime, drzava, grad, username, email, biografija, datumRodjenja, spol, stanje)
        {
            this.brojPratitelja = 0;
            this.pratitelji = new List<RegistrovaniKorisnik>();
        }

        public List<String> pregledajPakete()
        {
            throw new NotImplementedException();
        }
    }
}
