using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiletOtomasyonu.Models
{
    public class OtobusDto
    {
        public string Id{ get; set; }
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Firma { get; set; }
        public string Mevcut { get; set; }
        public string Ozellikler { get; set; }
    }
}