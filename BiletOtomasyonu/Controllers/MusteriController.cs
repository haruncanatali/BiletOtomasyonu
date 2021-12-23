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
    public class MusteriController : Controller
    {
        private IMusteriDal musteriServis;

        public MusteriController()
        {
            musteriServis = new MusteriDal();
        }

        public ActionResult Index(string val = null)
        {
            if (!String.IsNullOrEmpty(val))
            {
                var result = musteriServis.GetEntities(c => (c.Ad + " " + c.Soyad).ToLower().Contains(val.ToLower()));
                if (result !=null && result.Count>0)
                {
                    return View(result);
                }
            }
            return View(musteriServis.GetEntities(null));
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Musteri());
        }

        [HttpPost]
        public ActionResult Add(Musteri model)
        {
            try
            {
                musteriServis.Add(model);
                return RedirectToAction("Index", musteriServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", musteriServis.GetEntities(null));
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = musteriServis.GetEntity(c => c.Id == id);
                if (result != null)
                {
                    musteriServis.Delete(result);
                }

                return RedirectToAction("Index",musteriServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", musteriServis.GetEntities(null));
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var result = musteriServis.GetEntity(c => c.Id == id);
            if (result != null)
            {
                return View(result);
            }
            return RedirectToAction("Index", musteriServis.GetEntities(null));
        }

        [HttpPost]
        public ActionResult Update(Musteri model)
        {
            try
            {
                musteriServis.Update(model);
                return RedirectToAction("Index", musteriServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", musteriServis.GetEntities(null));
            }
        }
    }
}