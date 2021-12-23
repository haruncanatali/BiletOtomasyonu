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
    public class SehirController : Controller
    {
        private ISehirDal sehirServis;

        public SehirController()
        {
            sehirServis = new SehirDal();
        }

        public ActionResult Index(string val = null)
        {
            if (!String.IsNullOrEmpty(val))
            {
                var result = sehirServis.GetEntities(c=>c.SehirAdi.ToLower() == val.ToLower());
                if (result!=null && result.Count>0)
                {
                    return View(result);
                }
            }
            return View(sehirServis.GetEntities(null));
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Sehir());
        }

        [HttpPost]
        public ActionResult Add(Sehir model)
        {
            try
            {
                sehirServis.Add(model);
                return RedirectToAction("Index", sehirServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", sehirServis.GetEntities(null));

            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = sehirServis.GetEntity(c => c.Id == id);
                if (result != null)
                {
                    sehirServis.Delete(result);
                }
                return RedirectToAction("Index", sehirServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", sehirServis.GetEntities(null));
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            try
            {
                var result = sehirServis.GetEntity(c => c.Id == id);
                return View(result);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", sehirServis.GetEntities(null));
            }
        }

        [HttpPost]
        public ActionResult Update(Sehir model)
        {
            try
            {
                sehirServis.Update(model);
                return RedirectToAction("Index", sehirServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", sehirServis.GetEntities(null));
            }
        }
    }
}