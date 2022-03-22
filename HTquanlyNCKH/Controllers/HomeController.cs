using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTquanlyNCKH.Models;

namespace HTquanlyNCKH.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (DBModel db = new DBModel()) {

                //{
                //    List<Slider> sliderList = db.Sliders.ToList<Slider>();
                //    return Json(new { data = sliderList },
                //    JsonRequestBehavior.AllowGet);

                //List<Slider> sliderList = db.Sliders.ToList<Slider>();
                var sliderList = from p in db.Sliders.OrderByDescending(n => n.sliderID)
                                 select p;
                ViewBag.slider = sliderList;
            return View(sliderList);
            }            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public JsonResult GetCountries()
        //{
        //    var Countries = new List<string>();
        //    Countries.Add("Australia");
        //    Countries.Add("India");
        //    Countries.Add("Russia");
        //    return Json(Countries, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult GetCountries()
        {
            using (DBModel db = new DBModel())
            {
                List<Classification> cls = db.Classifications.ToList<Classification>();
                var Countries = cls.Select(n => n.clsName);
                return Json(Countries, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult GetStates(string country)
        {
            var States = new List<string>();
            if (!string.IsNullOrWhiteSpace(country))
            {
                if (country.Equals("Australia"))
                {
                    States.Add("Sydney");
                    States.Add("Perth");
                }
                if (country.Equals("India"))
                {
                    States.Add("Delhi");
                    States.Add("Mumbai");
                }
                if (country.Equals("Russia"))
                {
                    States.Add("Minsk");
                    States.Add("Moscow");
                }
            }
            return Json(States, JsonRequestBehavior.AllowGet);
        }
    }
}