using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BiletOtomasyonu.Models
{
    public class Bilet:IEntity
    {
        public int Id { get; set; }

        public int MusteriId { get; set; }
        public int SeferId { get; set; }
        public int SorumluId { get; set; }

        public virtual Musteri Musterisi { get; set; }
        public virtual Sefer Seferi { get; set; }
        public virtual Sorumlu Sorumlusu { get; set; }
    }
}