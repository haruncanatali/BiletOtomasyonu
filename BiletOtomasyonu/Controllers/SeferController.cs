using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiletOtomasyonu.DbAccess.Abstract;
using BiletOtomasyonu.DbAccess.Concrete;
using BiletOtomasyonu.Models;

namespace BiletOtomasyonu.Controllers
{
    public class SeferController : Controller
    {
        private ISeferDal seferServis;
        private IOtobusDal otobusServis;
        private ISehirDal sehirServis;
        private IBiletDal biletServis;

        public SeferController()
        {
            seferServis = new SeferDal();
            otobusServis = new OtobusDal();
            sehirServis = new SehirDal();
            biletServis = new BiletDal();

            İliskiliBilgileriAl();
        }

        public ActionResult Index(string val = null)
        {
            if (!String.IsNullOrEmpty(val))
            {
                var result = seferServis.GetEntities(c => c.KalkisYeri.ToLower().Contains(val.ToLower()));
                if (result !=null && result.Count>0)
                {
                    return View(result);
                }
            }
            return View(seferServis.GetEntities(null));
        }

        [HttpGet]
        public ActionResult Add()
        {
            İliskiliBilgileriAl();
            return View(new Sefer());
        }

        private void İliskiliBilgileriAl()
        {
            ViewBag.otobusler = (from x in otobusServis.GetEntities(null)
                select new SelectListItem
                {
                    Text = x.Plaka,
                    Value = x.Id.ToString()
                }).ToList();
            ViewBag.sehirler = (from x in sehirServis.GetEntities(null)
                select new SelectListItem
                {
                    Text = x.SehirAdi,
                    Value = x.SehirAdi
                }).ToList();
        }

        [HttpPost]
        public ActionResult Add(Sefer model)
        {
            try
            {
                seferServis.Add(model);
                return RedirectToAction("Index", seferServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", seferServis.GetEntities(null));
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = seferServis.GetEntity(c => c.Id == id);
                if (result != null)
                {
                    var biletler = biletServis.GetEntities(c => c.SeferId == id);
                    for (int i = 0; i < biletler.Count; i++)
                    {
                        biletServis.Delete(new Bilet
                        {
                            Id = biletler[i].Id
                        });
                    }

                    result.Biletleri = null;
                    seferServis.Delete(result);
                }
                return RedirectToAction("Index", seferServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", seferServis.GetEntities(null));
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            try
            {
                var result = seferServis.GetEntity(c => c.Id == id);
                return View(result);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", seferServis.GetEntities(null));
            }
        }

        [HttpPost]
        public ActionResult Update(Sefer model)
        {
            try
            {
                seferServis.Update(model);
                return RedirectToAction("Index", seferServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", seferServis.GetEntities(null));
            }
        }
    }
}