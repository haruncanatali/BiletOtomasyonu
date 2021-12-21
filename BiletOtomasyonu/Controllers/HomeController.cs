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
        private ISehirDal denemeServis;

        public HomeController()
        {
            denemeServis = new SehirDal();
        }

        public ActionResult Index()
        {
            ViewBag.denemeData = denemeServis.GetEntities(null).Count;
            return View();
        }
    }
}