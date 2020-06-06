using System;
using System.Collections.Generic;

namespace Lovid_API
{
    public partial class Poruka
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public DateTime Datum { get; set; }
        public string Tekst { get; set; }

        public virtual Chat Chat { get; set; }
    }
}
