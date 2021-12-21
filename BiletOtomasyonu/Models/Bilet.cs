using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiletOtomasyonu.Models
{
    public class Bilet:IEntity
    {
        public int Id { get; set; }
        public int MusteriId { get; set; }
        public int SeferId { get; set; }

        public virtual Musteri Musterisi { get; set; }
        public virtual Sefer Seferi { get; set; }
    }
}