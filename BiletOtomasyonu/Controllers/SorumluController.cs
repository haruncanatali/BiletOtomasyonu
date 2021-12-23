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
    public class SorumluController : Controller
    {
        private ISorumluDal sorumluServis;

        public SorumluController()
        {
            sorumluServis = new SorumluDal();
        }

        public ActionResult Index(string val = null)
        {
            if (!String.IsNullOrEmpty(val))
            {
                var result = sorumluServis.GetEntities(c => (c.Ad + " " + c.Soyad).ToLower().Contains(val.ToLower()));
                if (result != null && result.Count > 0)
                {
                    return View(result);
                }
            }
            return View(sorumluServis.GetEntities(null));
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Sorumlu());
        }

        [HttpPost]
        public ActionResult Add(Sorumlu model)
        {
            try
            {
                sorumluServis.Add(model);
                return RedirectToAction("Index", sorumluServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", sorumluServis.GetEntities(null));
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            try
            {
                var result = sorumluServis.GetEntity(c => c.Id == id);
                if (result != null)
                {
                    return View(result);
                }
                return RedirectToAction("Index", sorumluServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", sorumluServis.GetEntities(null));
            }
        }

        [HttpPost]
        public ActionResult Update(Sorumlu model)
        {
            try
            {
                sorumluServis.Update(model);
                return RedirectToAction("Index", sorumluServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", sorumluServis.GetEntities(null));
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = sorumluServis.GetEntity(c => c.Id == id);
                if (result != null)
                {
                    sorumluServis.Delete(result);
                }
                return RedirectToAction("Index", sorumluServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", sorumluServis.GetEntities(null));
            }
        }
    }
}