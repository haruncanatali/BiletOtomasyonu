using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiletOtomasyonu.Models
{
    public class Sefer:IEntity
    {
        public Sefer()
        {
            Biletleri = new List<Bilet>();
        }

        public int Id { get; set; }
        public string KalkisYeri { get; set; }
        public string VarisYeri { get; set; }
        public DateTime KalkisZamani { get; set; }
        public DateTime TahminiVarisZamani { get; set; }
        public string Ucret { get; set; }

        public int OtobusId { get; set; }

        public virtual Otobus Otobusu { get; set; }
        public virtual ICollection<Bilet> Biletleri { get; set; }
    }
}