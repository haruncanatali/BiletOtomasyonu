using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiletOtomasyonu.Models
{
    public class Otobus:IEntity
    {
        public Otobus()
        {
            Seferleri = new List<Sefer>();
        }

        public int Id { get; set; }
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Firma { get; set; }
        public int Mevcut { get; set; }
        public string Ozellikler { get; set; }

        public virtual ICollection<Sefer> Seferleri { get; set; }
    }
}