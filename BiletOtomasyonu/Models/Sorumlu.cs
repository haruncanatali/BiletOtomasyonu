using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiletOtomasyonu.Models
{
    public class Sorumlu:IEntity
    {
        public Sorumlu()
        {
            SattigiBiletler = new List<Bilet>();
        }
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Tckn { get; set; }

        public ICollection<Bilet> SattigiBiletler { get; set; }
    }
}