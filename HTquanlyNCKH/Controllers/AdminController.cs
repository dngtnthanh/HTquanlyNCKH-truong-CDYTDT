using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTquanlyNCKH.Models;
using System.IO;
using PagedList;
using System.Data.Entity;
namespace HTquanlyNCKH.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SliderGetData()
        {
            using (DBModel db = new DBModel())
            {

                List<Slider> sliderList = db.Sliders.ToList<Slider>();
                return Json(new { data = sliderList },
                JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult SliderStoreOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Slider());
            }
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Sliders.Where(x => x.sliderID == id).FirstOrDefault<Slider>());
                }
            }
        }
        [HttpPost]
        public ActionResult SliderStoreOrEdit(Slider sliderob)
        {
            using (DBModel db = new DBModel())
            {
                if (sliderob.sliderID == 0)
                {
                    db.Sliders.Add(sliderob);
                    sliderob.sldCreateDate = DateTime.Now;  //Lưu lại thời gian khởi tạo
                    db.SaveChanges();
                    return Json(new { success = true, message = "Lưu lại thành công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    sliderob.sldModifierDate = DateTime.Now;
                    db.Entry(sliderob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
                }
            }
        }
        [HttpPost]
        public ActionResult SliderDelete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Slider emp = db.Sliders.Where(x => x.sliderID == id).FirstOrDefault<Slider>();
                db.Sliders.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Xoá thành công!", JsonRequestBehavior.AllowGet });
            }
        }

        public ActionResult SliderManage()
        {
            ViewBag.DeleteIcon = "<i class='fas fa-trash - alt'></i>";
            return View();
        }

    }
}