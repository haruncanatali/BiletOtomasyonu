using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiletOtomasyonu.DbAccess.Abstract;
using BiletOtomasyonu.DbAccess.Concrete;
using BiletOtomasyonu.Models;

namespace BiletOtomasyonu.Controllers
{
    public class OtobusController : Controller
    {
        private IOtobusDal otobusServis;

        public OtobusController()
        {
            otobusServis = new OtobusDal();
        }

        public ActionResult Index()
        {
            return View(otobusServis.GetEntities(null));
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new OtobusDto());
        }

        [HttpPost]
        public ActionResult Add(string Plaka,string Marka,string Model,string Firma,string Mevcut,string Ozellikler)
        {
            try
            {
                otobusServis.Add(new Otobus
                {
                    Plaka = Plaka,
                    Marka = Marka,
                    Model = Model,
                    Firma = Firma,
                    Mevcut = int.Parse(Mevcut),
                    Ozellikler = Ozellikler
                });
                return RedirectToAction("Index", otobusServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", otobusServis.GetEntities(null));
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            try
            {
                var result = otobusServis.GetEntity(c => c.Id == id);
                return View(new OtobusDto
                {
                    Id = result.Id.ToString(),
                    Marka = result.Marka,
                    Model = result.Model,
                    Firma = result.Firma,
                    Mevcut = result.Mevcut.ToString(),
                    Plaka = result.Plaka,
                    Ozellikler = result.Ozellikler
                });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", otobusServis.GetEntities(null
                ));
            }
        }

        [HttpPost]
        public ActionResult Update(string Id,string Plaka, string Marka, string Model, string Firma, string Mevcut, string Ozellikler)
        {
            try
            {
                otobusServis.Update(new Otobus
                {
                    Id = int.Parse(Id),
                    Plaka = Plaka,
                    Marka = Marka,
                    Model = Model,
                    Firma = Firma,
                    Mevcut = int.Parse(Mevcut),
                    Ozellikler = Ozellikler
                });
                return RedirectToAction("Index", otobusServis.GetEntities(null
                ));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", otobusServis.GetEntities(null
                ));
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = otobusServis.GetEntity(c => c.Id == id);
                if (result != null)
                {
                    otobusServis.Delete(result);
                }
                return RedirectToAction("Index", otobusServis.GetEntities(null
                ));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", otobusServis.GetEntities(null
                ));
            }
        }
    }
}