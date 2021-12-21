using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiletOtomasyonu.Models
{
    public class Sehir:IEntity
    {
        public int Id { get; set; }
        public string SehirAdi { get; set; }
    }
}