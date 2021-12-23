using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiletOtomasyonu.DbAccess.Abstract;
using BiletOtomasyonu.DbAccess.Concrete;
using BiletOtomasyonu.Models;

namespace BiletOtomasyonu.Controllers
{
    public class BiletController : Controller
    {
        private IBiletDal biletServis;
        private IMusteriDal musteriServis;
        private ISeferDal seferServis;
        private ISorumluDal sorumluServis;

        public BiletController()
        {
            biletServis = new BiletDal();
            musteriServis = new MusteriDal();
            seferServis = new SeferDal();
            sorumluServis = new SorumluDal();
        }

        public ActionResult Index(string val = null)
        {
            if (!String.IsNullOrEmpty(val))
            {
                var result = biletServis.GetEntities(c =>
                    (c.Musterisi.Ad + " " + c.Musterisi.Soyad).ToLower().Contains(val.ToLower()));
                if (result!=null && result.Count>0)
                {
                    return View(result);
                }
            }
            return View(biletServis.GetEntities(null));
        }

        [HttpGet]
        public ActionResult Add()
        {
            IliskiliBilgileriAyarla();
            return View(new Bilet());
        }

        [HttpPost]
        public ActionResult Add(Bilet model)
        {
            try
            {
                biletServis.Add(model);
                return RedirectToAction("Index", biletServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", biletServis.GetEntities(null));
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = biletServis.GetEntity(c => c.Id == id);
                if (result != null)
                {
                    biletServis.Delete(result);
                }
                return RedirectToAction("Index", biletServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", biletServis.GetEntities(null));
            }
        }

        public void IliskiliBilgileriAyarla()
        {
            ViewBag.musteriler = (from x in musteriServis.GetEntities(null)
                                  select new SelectListItem
                                  {
                                      Text = x.Ad + " " + x.Soyad + " " + x.Tckn,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewBag.seferler = (from x in seferServis.GetEntities(c => c.Biletleri.Count != c.Otobusu.Mevcut)
                                select new SelectListItem
                                {
                                    Text = x.KalkisYeri + "->" + x.VarisYeri + ":" + x.KalkisZamani.ToString("dddd, dd MMMM yyyy HH:mm:ss") + " " + x.Otobusu.Plaka,
                                    Value = x.Id.ToString()
                                }).ToList(); // kapasitesi dolmayan otobüsler geliyor
            ViewBag.sorumlular = (from x in sorumluServis.GetEntities(null) select new SelectListItem
            {
                Text = x.Ad+" "+x.Soyad+" "+x.Tckn,
                Value = x.Id.ToString()
            }).ToList();
        }
    }
}