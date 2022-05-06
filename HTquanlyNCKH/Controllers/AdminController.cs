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
            using (DBModel db = new DBModel())
            {
                var tpc = db.Topics.OrderBy(n => n.topicID);
                ViewBag.DeTai = tpc.Count();

                var sct = db.Scientists.OrderBy(n => n.scientistID);
                ViewBag.NhaKhoaHoc = sct.Count();

                var art = db.Articles.OrderBy(n => n.articlesID);
                ViewBag.BaiBao = art.Count();
            }
                return View();
        }
        //Quản lý thông tin ảnh bìa
        public ActionResult SliderGetData() //Lấy Json danh sách ảnh bìa
        {
            using (DBModel db = new DBModel())
            {

                List<Slider> sliderList = db.Sliders.ToList<Slider>();
                return Json(new { data = sliderList },
                JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult SliderStoreOrEdit(int id = 0)   //Hiện thông tin thêm mới hoặc sửa chữa ảnh bìa
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
        public ActionResult SliderStoreOrEdit(Slider sliderob, HttpPostedFileBase file) //Thêm mới hoặc sửa chữa ảnh bìa
        {
            using (DBModel db = new DBModel())
            {
                if (sliderob.sliderID == 0)
                {
                    
                        if (file != null && file.ContentLength > 0)
                        {
                            string _FileName = Path.GetFileName(file.FileName);
                            string _path = Path.Combine(Server.MapPath("~/Content/dist/img"), _FileName);
                            sliderob.sldImage = _FileName;
                            file.SaveAs(_path);
                            ViewBag.Message = "File Uploaded Successfully!!";

                        }


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
        public ActionResult SliderDelete(int id)    //Xoá ảnh bìa
        {
            using (DBModel db = new DBModel())
            {
                Slider emp = db.Sliders.Where(x => x.sliderID == id).FirstOrDefault<Slider>();
                db.Sliders.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Xoá thành công!", JsonRequestBehavior.AllowGet });
            }
        }

        public ActionResult SliderManage()  // Index của quản lý ảnh bìa
        {
            ViewBag.DeleteIcon = "<i class='fas fa-trash - alt'></i>";
            return View();
        }



        //Quản lý giới thiệu Intro
        
        public ActionResult IntroGetData()      //Lấy Json danh sách thông tin trang chủ
        {
            using (DBModel db = new DBModel())
            {
                List<Intro> introList = db.Introes.ToList<Intro>();
                return Json(new { data = introList },
                    JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpGet]
        public ActionResult IntroStoreOrEdit(int id = 0)        //Hiện thông tin thêm mới hoặc sửa chữa thông tin trang chủ
        {
            if (id == 0)
            {
                return View(new Intro());
            }
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Introes.Where(x => x.introID == id).FirstOrDefault<Intro>());
                }
            }
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult IntroStoreOrEdit(Intro introob)     //Thêm mới hoặc sửa chữa thông tin trang chủ
        {
           
            using (DBModel db = new DBModel())
            {
                if (introob.introID == 0)
                {
                    db.Introes.Add(introob);
                    introob.itdCreateDate = DateTime.Now;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Lưu lại thành công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    introob.itdModifierDate = DateTime.Now;
                    db.Entry(introob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
                }
            }
        }
        [HttpPost]
        public ActionResult IntroDelete(int id)     //Xoá thông tin trang chủ
        {
            using (DBModel db = new DBModel())
            {
                Intro emp = db.Introes.Where(x => x.introID == id).FirstOrDefault<Intro>();
                db.Introes.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, mesage = "Xoá thành công!", JsonRequestBehavior.AllowGet });
            }
        }
        public ActionResult IntroManage()   //Index quản lý thông tin trang chủ
        {
            ViewBag.DeleteIcon = "<i class='fas fa-trash - alt'></i>";
            return View();
        }

        public ActionResult IntroSupport()      //Hiện popup hỗ trợ hướng dẫn thêm mới giới thiệu trên trang chủ
        {
            return View();
        }

        public ActionResult GetIconSupport()    //Hiện Popup hưỡng dẫn lấy icon
        {
            return View();
        }

        public ActionResult SliderSupport()     //Hiện Popup hướng dẫn quản lý ảnh bìa
        {
            return View();
        }
    }
}