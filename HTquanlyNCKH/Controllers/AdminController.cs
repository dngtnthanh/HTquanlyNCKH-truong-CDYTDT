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
            //if (Session["Permission"].ToString() != "1")//Kiểm tra nếu chưa đăng nhập, thì yêu cầu đăng nhập
            //{
            //    return RedirectToAction("index", "Login");
            //}
            using (DBModel db = new DBModel())
            {
                var tpc = db.Topics.OrderBy(n => n.topicID);
                ViewBag.DeTai = tpc.Count();            //Thống kê số lượng đề tài

                var sct = db.Scientists.OrderBy(n => n.scientistID);
                ViewBag.NhaKhoaHoc = sct.Count();       //Thống kê số lượng nhà khoa học

                var art = db.Articles.OrderBy(n => n.articlesID);
                ViewBag.BaiBao = art.Count();           //Thống kê số lượng bài báo quốc tế

                ViewBag.dangdexuat = db.Topics.Where(n => n.statusID == 4).Count();
                ViewBag.dangthuchien = db.Topics.Where(n => n.statusID == 7).Count();
                ViewBag.danghiemthu = db.Topics.Where(n => n.statusID == 5).Count();
                ViewBag.khac = db.Topics.Where(n => n.statusID == 8).Count();
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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Slider sliderob)
        {
            using (DBModel db = new DBModel())
            {
                if (ModelState.IsValid)
                {
                    if (Request.Files.Count > 0)
                    {
                        HttpPostedFileBase file = Request.Files[0];
                        if (file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            sliderob.sldImage = Path.Combine(
                                Server.MapPath("~/App_Data/Uploads/image/slider"), fileName);                            
                            file.SaveAs(sliderob.sldImage);
                            sliderob.sldImage = fileName;
                        }
                        db.Sliders.Add(sliderob);
                        db.SaveChanges();
                        return View();
                    }
                }

                return View(sliderob);
            }
                
        }
        [HttpPost]
        public ActionResult SliderStoreOrEdit(Slider sliderob) //Thêm mới hoặc sửa chữa ảnh bìa
        {
            using (DBModel db = new DBModel())
            {
                if (sliderob.sliderID == 0)
                {
                    if (ModelState.IsValid)
                    {
                        if (Request.Files.Count > 0)
                        {
                            HttpPostedFileBase file = Request.Files[0];
                            if (file.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(file.FileName);
                                sliderob.sldImage = Path.Combine(
                                    Server.MapPath("~/Uploads/image/slider"), fileName);
                                file.SaveAs(sliderob.sldImage);
                                sliderob.sldImage = fileName;
                            }
                            db.Sliders.Add(sliderob);
                            db.SaveChanges();
                            return RedirectToAction("SliderManage");
                        }
                    }
                    return RedirectToAction("SliderManage");
                    //return Json(new { success = true, message = "Lưu lại thành công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        if (Request.Files.Count > 0)
                        {
                            HttpPostedFileBase file = Request.Files[0];
                            if (file.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(file.FileName);
                                sliderob.sldImage = Path.Combine(
                                    Server.MapPath("~/Uploads/image/slider"), fileName);
                                file.SaveAs(sliderob.sldImage);
                                sliderob.sldImage = fileName;
                            }        
                        }
                    }               
                    sliderob.sldModifierDate = DateTime.Now;
                    db.Entry(sliderob).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("SliderManage");
                    //return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
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