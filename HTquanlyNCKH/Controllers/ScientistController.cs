using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HTquanlyNCKH.Models;
using System.IO;

namespace HTquanlyNCKH.Controllers
{
    public class ScientistController : Controller
    {
        // GET: Scientist
        public ActionResult Index()
        {
            return View();
        }
        //Quản lý trình độ nhà khoa học
        public ActionResult DegreeGetData()
        {
            
            using (DBModel db = new DBModel())
            {
                List<Degree> degreesList = db.Degrees.ToList<Degree>();
                return Json(new { data = degreesList },
                    JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult DegreeStoreOrEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new Degree());
            }
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Degrees.Where(x => x.degreeID == id).FirstOrDefault<Degree>());
                }
            }
        }
        [HttpPost]
        public ActionResult DegreeStoreOrEdit(Degree degreeob)
        {
            using (DBModel db = new DBModel())
            {
                if (degreeob.degreeID == 0)
                {
                    db.Degrees.Add(degreeob);
                    degreeob.degCreateDate = DateTime.Now;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Lưu lại thành công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    degreeob.degModifierDate = DateTime.Now;
                    db.Entry(degreeob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
                }
            }
        }
        [HttpPost]
        public ActionResult DegreeDelete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Degree emp = db.Degrees.Where(x => x.degreeID == id).FirstOrDefault<Degree>();
                var deg = db.Scientists.Where(n => n.degreeID == id);
                if (id != 9)
                {
                    if (deg.Count() < 1)
                    {
                        db.Degrees.Remove(emp);
                        db.SaveChanges();
                        return Json(new { success = true, mesage = "Xoá thành công!", JsonRequestBehavior.AllowGet });
                    }
                    else
                    {
                        string mess = "";
                        foreach (var item in deg)
                        {
                            mess += "\n [Mã nhà khoa học: " + item.scientistID + ". Tên nhà khoa học: " + item.sctFirstName + item.sctLastName + ". Trình độ: " + emp.degName + "]";
                        }

                        return Json(new
                        {
                            success = false,
                            message = "Xoá không thành công! Còn " + deg.Count() + " hàng dữ liệu trong danh sách nhà khoa học"
                             + mess,
                            JsonRequestBehavior.AllowGet
                        });
                    }
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        message = "Không thể xoá dữ liệu này",
                        JsonRequestBehavior.AllowGet
                    });
                }
                
            }
        }

        public ActionResult DegreeManage()
        {
            ViewBag.DeleteIcon = "<i class='fas fa-trash - alt'></i>";
            return View();
        }

        //Thực thể ngoại ngữ của nhà nghiên cứu, nhà khoa học
        public ActionResult ForeignGetData()
        {
            using (DBModel db = new DBModel())
            {
                List<Foreign> foreignsList = db.Foreigns.ToList<Foreign>();
                return Json(new { data = foreignsList },
                    JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult ForeignStoreOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Foreign());
            }
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Foreigns.Where(x => x.foreignID == id).FirstOrDefault<Foreign>());
                }
            }
        }
        [HttpPost]
        public ActionResult ForeignStoreOrEdit(Foreign foreignob)
        {
            using (DBModel db = new DBModel())
            {
                if (foreignob.foreignID == 0)
                {
                    db.Foreigns.Add(foreignob);
                    foreignob.fgnCreateDate = DateTime.Now;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Lưu lại thành công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    foreignob.fgnModifierDate = DateTime.Now;
                    db.Entry(foreignob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
                }
            }
        }
        [HttpPost]
        public ActionResult ForeignDelete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Foreign emp = db.Foreigns.Where(x => x.foreignID == id).FirstOrDefault<Foreign>();
                var fre = db.Scientists.Where(n => n.foreignID == id);
                if (id != 13)
                {
                    if (fre.Count() < 1)
                    {
                        db.Foreigns.Remove(emp);
                        db.SaveChanges();
                        return Json(new { success = true, mesage = "Xoá thành công!", JsonRequestBehavior.AllowGet });
                    }
                    else
                    {
                        string mess = "";
                        foreach (var item in fre)
                        {
                            mess += "\n [Mã nhà khoa học: " + item.scientistID + ". Tên nhà khoa học: " + item.sctFirstName + item.sctLastName + ". Ngoại ngữ: " + emp.fgnName + "]";
                        }

                        return Json(new
                        {
                            success = false,
                            message = "Xoá không thành công! Còn " + fre.Count() + " hàng dữ liệu trong danh sách nhà khoa học"
                             + mess,
                            JsonRequestBehavior.AllowGet
                        });
                    }
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        message = "Xoá không thành công. Không thể xoá dữ liệu này",
                        JsonRequestBehavior.AllowGet
                    });
                }
                
            }
        }
        public ActionResult ForeignManage()
        {
            ViewBag.DeleteIcon = "<i class='fas fa-trash - alt'></i>";
            return View();
        }
        //Quản lý nơi sinh vd: Đồng Tháp, Vĩnh Long,...
        public ActionResult PlaceGetData()
        {
            using (DBModel db = new DBModel())
            {
                List<Place> degreesList = db.Places.ToList<Place>();
                return Json(new { data = degreesList },
                    JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult PlaceStoreOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Place());
            }
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Places.Where(x => x.placeID == id).FirstOrDefault<Place>());
                }
            }
        }
        [HttpPost]
        public ActionResult PlaceStoreOrEdit(Place placeob)
        {
            using (DBModel db = new DBModel())
            {
                if (placeob.placeID == 0)
                {
                    placeob.plaCreateDate = DateTime.Now;
                    db.Places.Add(placeob);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Lưu lại thành công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    placeob.plaModifierDate = DateTime.Now;
                    db.Entry(placeob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
                }
            }
        }
        [HttpPost]
        public ActionResult PlaceDelete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Place emp = db.Places.Where(x => x.placeID == id).FirstOrDefault<Place>();
                var pla = db.Scientists.Where(n => n.PlaceID == id);
                if (id != 67)
                {


                    if (pla.Count() < 1)
                    {
                        db.Places.Remove(emp);
                        db.SaveChanges();
                        return Json(new { success = true, mesage = "Xoá thành công!", JsonRequestBehavior.AllowGet });
                    }
                    else
                    {
                        string mess = "";
                        foreach (var item in pla)
                        {
                            mess += "\n [Mã nhà khoa học: " + item.scientistID + ". Tên nhà khoa học: " + item.sctFirstName + item.sctLastName + ". nơi sinh: " + emp.plaName + "]";
                        }

                        return Json(new
                        {
                            success = false,
                            message = "Xoá không thành công! Còn " + pla.Count() + " hàng dữ liệu trong danh sách nhà khoa học"
                             + mess,
                            JsonRequestBehavior.AllowGet
                        });
                    }
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        message = "Xoá không thành công. Không thể xoá dữ liệu này",
                        JsonRequestBehavior.AllowGet
                    });
                }
            }
        }
        public ActionResult PlaceManage()
        {
            ViewBag.DeleteIcon = "<i class='fas fa-trash - alt'></i>";
            return View();
        }
        //Quản lý đơn vị làm việc
        public ActionResult UnitGetData()
        {
            using (DBModel db = new DBModel())
            {
                List<Unit> unitList = db.Units.ToList<Unit>();
                return Json(new { data = unitList },
                    JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult UnitStoreOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Unit());
            }
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Units.Where(x => x.unitID == id).FirstOrDefault<Unit>());
                }
            }
        }
        [HttpPost]
        public ActionResult UnitStoreOrEdit(Unit unitob)
        {
            using (DBModel db = new DBModel())
            {
                if (unitob.unitID == 0)
                {
                    db.Units.Add(unitob);
                    unitob.untCreateDate = DateTime.Now;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Lưu lại thành công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    unitob.untModifierDate = DateTime.Now;
                    db.Entry(unitob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
                }
            }
        }
        [HttpPost]
        public ActionResult UnitDelete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Unit emp = db.Units.Where(x => x.unitID == id).FirstOrDefault<Unit>();
                var uni = db.Scientists.Where(n => n.unitID == id);
                if (id != 4)
                {
                    if (uni.Count() < 1)
                    {
                        db.Units.Remove(emp);
                        db.SaveChanges();
                        return Json(new { success = true, mesage = "Xoá thành công!", JsonRequestBehavior.AllowGet });
                    }
                    else
                    {
                        string mess = "";
                        foreach (var item in uni)
                        {
                            mess += "\n [Mã nhà khoa học: " + item.scientistID + ". Tên nhà khoa học: " + item.sctFirstName + item.sctLastName + ". Phòng ban: " + emp.untName + "]";
                        }

                        return Json(new
                        {
                            success = false,
                            message = "Xoá không thành công! Còn " + uni.Count() + " hàng dữ liệu trong danh sách nhà khoa học"
                             + mess,
                            JsonRequestBehavior.AllowGet
                        });
                    }
                }
                else
                {

                    return Json(new
                    {
                        success = false,
                        message = "Xoá không thành công, không thể xoá dữ liệu này"
                        ,JsonRequestBehavior.AllowGet
                    });
                }
                
            }
        }
        public ActionResult UnitManage()
        {
            ViewBag.DeleteIcon = "<i class='fas fa-trash - alt'></i>";
            return View();
        }
        //Quản lý nhà khoa học
        public ActionResult ScientistGetData()
        {
            using (DBModel db = new DBModel())
            {
                List<Scientist> scientistList = db.Scientists.ToList<Scientist>();
                return Json(new { data = scientistList },
                    JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult ScientistStoreOrEdit(int id = 0)
        {
            if (id == 0)
            {               
                using (DBModel db = new DBModel())
                {
                    //Lấy danh sách nơi sinh (tỉnh)
                    List<Place> places = db.Places.OrderBy(n => n.plaName).ToList<Place>();
                    ViewBag.plaList = places;

                    //Lấy danh sách trình độ nhà khoa học
                    List<Degree> degrees = db.Degrees.OrderByDescending(n => n.degreeID).ToList<Degree>();
                    ViewBag.degList = degrees;

                    //Lấy danh sách phòng ban
                    List<Unit> units = db.Units.OrderByDescending(n => n.unitID).ToList<Unit>();
                    ViewBag.unitList = units;

                    //Lấy danh sách chuyên ngành nghiên cứu
                    List<Field> fields = db.Fields.OrderByDescending(n => n.fieldID).ToList<Field>();
                    ViewBag.fieldList = fields;

                    //Lấy danh sách ngoại ngữ nhà khoa học
                    List<Foreign> foreigns = db.Foreigns.OrderByDescending(n => n.foreignID).ToList<Foreign>();
                    ViewBag.foreignList = foreigns;

                    ViewBag.ngaysinh = null;
                }                
                return View(new Scientist());
            }
            else  // Post != 0
            {
                using (DBModel db = new DBModel())
                {
                    //Lấy danh sách nơi sinh (tỉnh)
                    List<Place> places = db.Places.OrderByDescending(n => n.placeID).ToList<Place>();
                    ViewBag.plaList = places;

                    //Lấy danh sách trình độ nhà khoa học
                    List<Degree> degrees = db.Degrees.OrderByDescending(n => n.degreeID).ToList<Degree>();
                    ViewBag.degList = degrees;

                    //Lấy danh sách phòng ban
                    List<Unit> units = db.Units.OrderByDescending(n => n.unitID).ToList<Unit>();
                    ViewBag.unitList = units;

                    //Lấy danh sách chuyên ngành nghiên cứu
                    List<Field> fields = db.Fields.OrderByDescending(n => n.fieldID).ToList<Field>();
                    ViewBag.fieldList = fields;

                    //Lấy danh sách ngoại ngữ nhà khoa học
                    List<Foreign> foreigns = db.Foreigns.OrderByDescending(n => n.foreignID).ToList<Foreign>();
                    ViewBag.foreignList = foreigns;                    

                    var sct = db.Scientists.SingleOrDefault(n => n.scientistID == id);
                    ViewBag.placeName = places.Single(n => n.placeID == sct.PlaceID).plaName; 

                    ViewBag.degreeName = degrees.Single(n => n.degreeID == sct.degreeID).degName;

                    ViewBag.unitName = units.Single(n => n.unitID == sct.unitID).untName;

                    ViewBag.fieldName = fields.Single(n => n.fieldID == sct.fieldID).fieName;

                    ViewBag.foreignName = foreigns.Single(n => n.foreignID == sct.foreignID).fgnName;

                    ViewBag.sctWorkingProcess = sct.sctWorkingProcess;                  
                    if (sct.sctBirthday == null)
                    {
                        ViewBag.ngaysinh = null;
                    }
                    else
                    {
                        ViewBag.ngaysinh = Convert.ToDateTime(sct.sctBirthday).ToString("yyyy-MM-dd");
                    }
                    ViewBag.plaList = db.Places.OrderBy(n => n.placeID).ToList();   //comboBox nơi sinh

                    return View(db.Scientists.Where(x => x.scientistID == id).FirstOrDefault<Scientist>());
                }
            }
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ScientistStoreOrEdit(Scientist scientistob, FormCollection collection)
        {
            using (DBModel db = new DBModel())
            {
                if (scientistob.scientistID == 0)
                {
                    if (ModelState.IsValid)
                    {
                        if (Request.Files.Count > 0)
                        {
                            HttpPostedFileBase file = Request.Files[0];
                            if (file.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(file.FileName);
                                scientistob.sctImage = Path.Combine(
                                Server.MapPath("~/Uploads/image/avatar"), fileName);
                                file.SaveAs(scientistob.sctImage);
                                scientistob.sctImage = fileName;
                            }
                            else
                            {
                                scientistob.sctImage = "unname.png";
                            }
                        }
                    }
                    if (collection.Get("ngay-sinh") != "")
                    {
                        scientistob.sctBirthday = Convert.ToDateTime(collection.Get("ngay-sinh"));
                    }
                    else
                    {
                        scientistob.sctBirthday = null;
                    }
                    try
                    {                                               
                        //Thêm mới Post
                       scientistob.sctSex = collection.Get("gioi-tinh");
                       db.Scientists.Add(scientistob);
                       db.SaveChanges();
                    }
                    catch (Exception e)
                    {

                        ViewBag.loi = e;
                    }
                    return RedirectToAction("ScientistManage");
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
                                scientistob.sctImage = Path.Combine(
                                Server.MapPath("~/Uploads/image/avatar"), fileName);
                                file.SaveAs(scientistob.sctImage);
                                scientistob.sctImage = fileName;
                            }
                        }
                    }                   
                    if (collection.Get("ngay-sinh") != "")
                    {
                        scientistob.sctBirthday = Convert.ToDateTime(collection.Get("ngay-sinh"));
                    }
                    else
                    {
                        scientistob.sctBirthday = null;
                    }
                    //Sửa Post
                    scientistob.sctSex = collection.Get("gioi-tinh");
                    scientistob.sctModifierDate = DateTime.Now;
                    db.Entry(scientistob).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ScientistManage");
                    //return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
                }
            }
        }
        [HttpPost]
        public ActionResult ScientistDelete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Scientist emp = db.Scientists.Where(x => x.scientistID == id).FirstOrDefault<Scientist>();
                db.Scientists.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, mesage = "Xoá thành công!", JsonRequestBehavior.AllowGet });
            }
        }
        public ActionResult ScientistManage()
        {
            ViewBag.DeleteIcon = "<i class='fas fa-trash - alt'></i>";
            ViewBag.ViewIcon = "<i class='fas fa-eye - alt'></i>";
            
            return View();
        }
        public ActionResult ScientistInfor(int? id)     //Hiện Popup thông tin nhà khoa học (truyền vào mã số scientistID nhà khoa học
        {
            using (DBModel db = new DBModel())
            {                
                var ScientistList = from sct in db.Scientists                                        //Lấy bảng nhà khoa học
                                    join pla in db.Places on sct.PlaceID equals pla.placeID          //Nối bảng địa chỉ (tỉnh)
                                    join deg in db.Degrees on sct.degreeID equals deg.degreeID       //Nối bảng học vị
                                    join unt in db.Units on sct.unitID equals unt.unitID             //Nối bảng phòng ban
                                    join fie in db.Fields on sct.fieldID equals fie.fieldID          //Nối bảng chuyên nghành
                                    join frg in db.Foreigns on sct.foreignID equals frg.foreignID //Nối bảng ngoại ngữ
                                    select new ScientistFull()      // [W-A-R-N-I-N-G] những chỗ có liên kết các trường dữ liệu là khoá ngoại ở trên không được để NULL. Tương ứng, nếu các hàng có hậu tố Name bên dưới RỖNG sẽ sinh lỗi không load lên được cả hàng đó
                                    {
                                        scientistID = sct.scientistID,              //Mã số nhà khoa học
                                        sctFirstName = sct.sctFirstName,            //Họ và tên đệm
                                        sctLastName = sct.sctLastName,              //Tên
                                        sctSex = sct.sctSex,                        //Giới tính
                                        sctBirthday = sct.sctBirthday,              //Ngày sinh                                                                            
                                        PlaceName = pla.plaName,                    //Địa chỉ (tỉnh)
                                        sctImage = sct.sctImage,                    //Ảnh chân dung
                                        degreeName = deg.degName,                   //Học vị vd: đại học, thạc sĩ
                                        unitName = unt.untName,                     //Phòng ban
                                        fieldName = fie.fieName,                    //Chuyên ngành
                                        sctWorkingProcess = sct.sctWorkingProcess,  //Quá trình công tác
                                        sctResult = sct.sctResult,                  //Kết quả nghiên cứu
                                        sctForeignName = frg.fgnName,               //Trình độ ngoại ngữ
                                        sctAddress = sct.sctAddress,                //Địa chỉ thường trú
                                        sctPhone = sct.sctPhone,                    //Số điện thoại
                                        sctEmail = sct.sctEmail,                    //Email
                                        sctCreateDate = sct.sctCreateDate,          //Thời gian khởi tạo
                                        sctModifierDate = sct.sctModifierDate,      //Thời gian thay đổi
                                        sctCreateUser = sct.sctCreateUser,          //Người khởi tạo
                                        sctModifierUser = sct.sctModifierUser,      //Người thay đổi

                                    };
                var _sct = db.Scientists.Single(n => n.scientistID == id);
                if (_sct.sctBirthday == null)
                {
                    ViewBag.ngaysinh = null;
                }
                else
                {
                    ViewBag.ngaysinh = Convert.ToDateTime(_sct.sctBirthday).ToString("dd-MM-yyyy");
                }
                
                return View(ScientistList.SingleOrDefault(n => n.scientistID == id));        //Trả về thông tin nhà khoa học tương ứng mã số ID truyền vào
            }
        }
    }
}