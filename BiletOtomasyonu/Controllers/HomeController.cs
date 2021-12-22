using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiletOtomasyonu.DbAccess.Abstract;
using BiletOtomasyonu.DbAccess.Concrete;

namespace BiletOtomasyonu.Controllers
{
    public class HomeController : Controller
    {
        //t_bilet,t_musteri,t_otobus,t_sehir,t_sefer,t_kasa
        private IBiletDal biletServis;
        private IMusteriDal musteriServis;
        private IOtobusDal otobusServis;
        private ISehirDal sehirServis;
        private ISeferDal seferServis;
        public HomeController()
        {
            biletServis = new BiletDal();
            musteriServis = new MusteriDal();
            otobusServis = new OtobusDal();
            seferServis = new SeferDal();
            sehirServis = new SehirDal();
        }

        public void BilgileriAyarla()
        {
            ViewBag.biletSayisi = biletServis.GetEntities(null).Count.ToString();
            ViewBag.musteriSayisi = musteriServis.GetEntities(null).Count.ToString();
            ViewBag.otobusSayisi = otobusServis.GetEntities(null).Count.ToString();
            ViewBag.seferSayisi = seferServis.GetEntities(null).Count.ToString();
            ViewBag.sehirSayisi = sehirServis.GetEntities(null).Count.ToString();
            ViewBag.kasa = biletServis.GetEntities(null).Sum(c=>int.Parse(c.Seferi.Ucret)).ToString();
        }

        public ActionResult Index()
        {
            BilgileriAyarla();
            return View();
        }
    }
}