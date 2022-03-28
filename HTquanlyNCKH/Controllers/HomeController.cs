using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTquanlyNCKH.Models;
using System.Data.Entity;
namespace HTquanlyNCKH.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();        
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

        // Xử lý hiển thị và tìm kiếm danh sách đề tài nghiên cứu khoa học
        public ActionResult TopicGetData()
        {
            using (DBModel db = new DBModel())
            {
                List<Topic> topicList = db.Topics.ToList<Topic>();
                return Json(new { data = topicList },
                    JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult TopicStoreOrEdit(int id = 0)
        {
            if (id == 0)
            {
                using (DBModel db = new DBModel())
                {
                    List<Field> fie = db.Fields.OrderByDescending(n => n.fieldID).ToList<Field>();
                    ViewBag.fie = fie;


                    List<Classification> cls = db.Classifications.OrderByDescending(n => n.classifiID).ToList<Classification>();
                    ViewBag.cls = cls;

                    List<Status> sts = db.Status.OrderByDescending(n => n.statusID).ToList<Status>();
                    ViewBag.sts = sts;



                    return View(new Topic());
                }
            }
            else
            {
                using (DBModel db = new DBModel())
                {
                    List<Field> fie = db.Fields.OrderByDescending(n => n.fieldID).ToList<Field>();
                    ViewBag.fie = fie;

                    List<Classification> cls = db.Classifications.OrderByDescending(n => n.classifiID).ToList<Classification>();
                    ViewBag.cls = cls;

                    List<Status> sts = db.Status.OrderByDescending(n => n.statusID).ToList<Status>();
                    ViewBag.sts = sts;

                    var tpc = db.Topics.Where(x => x.topicID == id).FirstOrDefault<Topic>();
                    ViewBag.tpcStartDate = tpc.tpcStartDate;
                    return View(db.Topics.Where(x => x.topicID == id).FirstOrDefault<Topic>());
                }
            }
        }
        [HttpPost]
        public ActionResult TopicStoreOrEdit(Topic topicob)
        {
            using (DBModel db = new DBModel())
            {
                if (topicob.topicID == 0)
                {
                    db.Topics.Add(topicob);
                    topicob.tpcCreateData = DateTime.Now;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Lưu lại thànhc công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    topicob.tpcModifierData = DateTime.Now;
                    db.Entry(topicob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
                }
            }
        }
        [HttpPost]
        public ActionResult TopicDelete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Topic emp = db.Topics.Where(x => x.topicID == id).FirstOrDefault<Topic>();
                db.Topics.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Xoá thành công!", JsonRequestBehavior.AllowGet });
            }
        }
        public ActionResult TopicManage()
        {
            ViewBag.DeleteIcon = "<i class='fas fa-trash - alt'></i>";
            return View();
        }




    }
}