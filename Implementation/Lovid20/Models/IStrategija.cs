using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lovid20.Models
{
    interface IStrategija
    {
        public List<RegistrovaniKorisnik> pretrazi(String filter);
    }
}
