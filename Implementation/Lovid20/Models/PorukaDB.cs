using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lovid20.Models
{
    public class PorukaDB
    {
        public int id { get; set; }
        public int chatID { get; set; }
        public DateTime datum { get; set; }
        public String tekst { get; set; }
        [ForeignKey("chatID")]
        public virtual ChatDB Chat { get; set; }
    }
}