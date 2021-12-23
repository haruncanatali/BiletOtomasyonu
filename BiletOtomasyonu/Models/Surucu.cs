using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiletOtomasyonu.Models
{
    public class Surucu:IEntity
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public int OtobusId { get; set; }

        public virtual Otobus Otobusu { get; set; }
    }
}