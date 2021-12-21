using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiletOtomasyonu.Models
{
    public class Musteri:IEntity
    {
        public Musteri()
        {
            Biletleri = new List<Bilet>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }
        public string Cinsiyet { get; set; }
        public string Tckn { get; set; } // TC Kimlik No

        public virtual ICollection<Bilet> Biletleri { get; set; }
    }
}