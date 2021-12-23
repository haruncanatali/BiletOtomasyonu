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
    public class SoforController : Controller
    {
        private ISurucuDal surucuServis;
        private IOtobusDal otobusServis;

        public SoforController()
        {
            surucuServis = new SurucuDal();
            otobusServis = new OtobusDal();
        }

        private void OtobusBilgileriniCek()
        {
            ViewBag.otobusler = (from x in otobusServis.GetEntities(null)
                                 select new SelectListItem
                                 {
                                     Text = x.Plaka,
                                     Value = x.Id.ToString()
                                 }).ToList();
        }

        [HttpGet]
        public ActionResult Add()
        {
            OtobusBilgileriniCek();
            return View(new Surucu());
        }

        [HttpPost]
        public ActionResult Add(Surucu model)
        {
            try
            {
                surucuServis.Add(model);
                return RedirectToAction("Index", surucuServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", surucuServis.GetEntities(null));
            }
        }

        public ActionResult Index(string val = null)
        {
            if (!String.IsNullOrEmpty(val))
            {
                var result = surucuServis.GetEntities(c => (c.Ad + " " + c.Soyad).ToLower().Contains(val.ToLower()));
                if (result !=null && result.Count>0)
                {
                    return View(result);
                }
            }
            return View(surucuServis.GetEntities(null));
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            OtobusBilgileriniCek();
            try
            {
                var result = surucuServis.GetEntity(c => c.Id == id);
                if (result != null)
                {
                    return View(result);
                }

                return RedirectToAction("Index", surucuServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", surucuServis.GetEntities(null));
            }
        }

        [HttpPost]
        public ActionResult Update(Surucu model)
        {
            try
            {
                surucuServis.Update(model);
                return RedirectToAction("Index", surucuServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", surucuServis.GetEntities(null));
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = surucuServis.GetEntity(c => c.Id == id);
                if (result != null)
                {
                    surucuServis.Delete(result);
                }
                return RedirectToAction("Index", surucuServis.GetEntities(null));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", surucuServis.GetEntities(null));
            }
        }
    }
}