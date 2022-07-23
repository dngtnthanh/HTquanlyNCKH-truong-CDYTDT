using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTquanlyNCKH.Models;
using System.Data.Entity;
using System.IO;

namespace HTquanlyNCKH.Controllers
{
    public class TopicController : Controller
    {
        // GET: Topic
        public ActionResult Index()
        {
            return View();
        }
        //Xử lý CRUD và tìm kiếm phân loại đề tài vd: cấp trường, cấp bộ, cấp quốc tế.
        public ActionResult ClassifiGetData()   // Trả chuỗi Json load danh sách phân loại đề tài
        {
            using (DBModel db = new DBModel())
            {
                
                List<Classification> classifiList = db.Classifications.ToList<Classification>();
                return Json(new { data = classifiList },
                JsonRequestBehavior.AllowGet);
            }
        }        
        [HttpGet]
        public ActionResult ClassifiStoreOrEdit(int id = 0)     //Hiển thị thông tin phân loại đề tài
        {
            if (id == 0)
            {
                return View(new Classification());
            }
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Classifications.Where(x => x.classifiID == id).FirstOrDefault<Classification>());
                }
            }
        }        
        [HttpPost]
        public ActionResult ClassifiStoreOrEdit(Classification classificationob)    //Xác nhận thêm mới hoặc sửa chữa phân loại đề tài
        {
            using (DBModel db = new DBModel())
            {
                if (classificationob.classifiID == 0)       //Nếu id truyền vào là 0 thì thực hiện thêm mới
                {                    
                    db.Classifications.Add(classificationob);
                    classificationob.clsCreateDate = DateTime.Now;  //Lưu lại thời gian khởi tạo
                    db.SaveChanges();
                    return Json(new { success = true, message = "Lưu lại thành công!", JsonRequestBehavior.AllowGet });
                }
                else    //Ngược lại id truyền vào là một giá trị != 0 thì sửa chữa dữ liệu tại id đó
                {
                    classificationob.clsModifierDate = DateTime.Now;        //Lưu thời gian sửa chữa
                    db.Entry(classificationob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
                }
            }
        }
        [HttpPost]
        public ActionResult ClassifiDelete(int id)      //Xoá phân loại đề tài
        {
            using (DBModel db = new DBModel())
            {
                Classification emp = db.Classifications.Where(x => x.classifiID == id).FirstOrDefault<Classification>();
                var tpc = db.Topics.Where(n => n.classifiID == id);   //Kiểm tra xem có tồn tại id của classifi trong bảng Topic
                
                if (tpc.Count() < 1)      //Kiểm tra toàn vẹn dữ liệu
                {
                    db.Classifications.Remove(emp);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Xoá thành công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    string mess = "";
                    foreach (var item in tpc)
                    {
                        mess += "\n [Mã đề tài: " + item.topicID + ". Tên đề tài: " + item.tpcName + ". Xếp loại: " + emp.clsName + "]";
                    }

                    return Json(new { success = false, message = "Xoá không thành công! Còn " + tpc.Count() + " hàng dữ liệu trong bảng đề tài"
                         + mess , JsonRequestBehavior.AllowGet });
                }
            }
        }
        public ActionResult ClassifiManage()        //Hiển thị trang mặc định
        {
            ViewBag.DeleteIcon = "<i class='fas fa-trash - alt'></i>";
            return View();
        }
        //Quản lý lĩnh vực đề tài
        public ActionResult FieldGetData()
        {
            using (DBModel db = new DBModel())
            {
                List<Field> fieldList = db.Fields.ToList<Field>();
                return Json(new { data = fieldList },
                JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult FieldStoreOrEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new Field());
            }
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Fields.Where(x => x.fieldID == id).FirstOrDefault<Field>());
                }
            }
        }
        [HttpPost]
        public ActionResult FieldStoreOrEdit(Field fieldob)
        {
            using (DBModel db = new DBModel())
            {
                if (fieldob.fieldID == 0)
                {
                    db.Fields.Add(fieldob);
                    fieldob.fieCreateDate = DateTime.Now;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Lưu lại thành công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    fieldob.fieModifierDate = DateTime.Now;
                    db.Entry(fieldob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
                }
            }            
        }
        [HttpPost]
        public ActionResult FieldDelete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Field emp = db.Fields.Where(x => x.fieldID == id).FirstOrDefault<Field>();
                var fie = db.Topics.Where(n => n.fieldID == id); //Kiểm tra xem có tồn tại id của bảng Field trong bảng Topic
                var field = db.Scientists.Where(n => n.fieldID == id); //Kiểm tra xem có tồn tại lĩnh vực tức là chuyên ngành bên bảng nhà khoa học có tồn tại không
                if(id != 29) 
                {
                    if (fie.Count() < 1 && field.Count() < 1)
                    {
                        db.Fields.Remove(emp);
                        db.SaveChanges();
                        return Json(new { success = true, message = "Xoá thành công!", JsonRequestBehavior.AllowGet });
                    }
                    else
                    {
                        string mess = "";
                        foreach (var item in fie)
                        {
                            mess += "\n [Mã đề tài: " + item.topicID + ". Tên đề tài: " + item.tpcName + ". Lĩnh vực: " + emp.fieName + "]";
                        }
                        foreach (var item in field)
                        {
                            mess += "\n [Mã nhà khoa học: " + item.scientistID + ". Tên nhà khoa học: " + item.sctFirstName + " " + item.sctLastName + ". Chuyên nghành: " + emp.fieName + "]";
                        }
                        return Json(new
                        {
                            success = false,
                            message = "Xoá không thành công! Còn " + fie.Count() + " hàng dữ liệu trong bảng đề tài" + " và " + field.Count() + " dữ liệu trong danh sách nhà khoa học"
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
        public ActionResult FieldManage()
        {
            ViewBag.DeleteIcon = "<i class='fas fa-trash - alt'></i>";
            return View();
        }
        public ActionResult StatusGetData()
        {
            using (DBModel db = new DBModel())
            {
                List<Status> statusList = db.Status.ToList<Status>();
                return Json(new { data = statusList },
                    JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult StatusStoreOrEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new Status());
            }
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Status.Where(x => x.statusID == id).FirstOrDefault<Status>());
                }
            }
        }
        [HttpPost]
        public ActionResult StatusStoreOrEdit(Status statusob)
        {
            using (DBModel db = new DBModel())
            {
                if(statusob.statusID == 0)
                {
                    db.Status.Add(statusob);
                    statusob.stsCreateDate = DateTime.Now;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Lưu lại thành công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    statusob.stsModifierDate = DateTime.Now;
                    db.Entry(statusob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
                }
            }
        }
        [HttpPost]
        public ActionResult StatusDelete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Status emp = db.Status.Where(x => x.statusID == id).FirstOrDefault<Status>();
                var sts = db.Topics.Where(n => n.statusID == id); //Kiểm tra xem có tồn tại id của bảng status trong bảng Topic
                if (id != 8)
                {
                    if (sts.Count() < 1)
                    {
                        db.Status.Remove(emp);
                        db.SaveChanges();
                        return Json(new { success = true, message = "Xoá thành công!", JsonRequestBehavior.AllowGet });
                    }
                    else
                    {
                        string mess = "";
                        foreach (var item in sts)
                        {
                            mess += "\n [Mã đề tài: " + item.topicID + ". Tên đề tài: " + item.tpcName + ". Trạng thái: " + emp.stsName + "]";
                        }
                        return Json(new
                        {
                            success = false,
                            message = "Xoá không thành công! Còn " + sts.Count() + " hàng dữ liệu trong bảng đề tài"
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
        public ActionResult StatusManage()
        {
            ViewBag.DeleteIcon = "<i class='fas fa-trash - alt'></i>";
            return View();
        }
        //=================================================
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
                    List<Field> _fie = db.Fields.OrderByDescending(n => n.fieldID).ToList<Field>();
                    ViewBag.fie = _fie;                    
                    List<Classification> _cls = db.Classifications.OrderByDescending(n => n.classifiID).ToList<Classification>();
                    ViewBag.cls = _cls;
                    List<Status> _sts = db.Status.OrderByDescending(n => n.statusID).ToList<Status>();
                    ViewBag.sts = _sts;
                    List<Scientist> _sct = db.Scientists.OrderByDescending(n => n.scientistID).ToList<Scientist>();
                    ViewBag.sct = _sct;
                    ViewBag.ngaybatdau = null;
                    ViewBag.ngayketthuc = null;
                    ViewBag.ngaynghiemthu = null;                    
                    Topic _tpc = new Topic();

                    var ScientistList = from sct in db.Scientists          //Lấy bảng nhà khoa học
                                    select new ScientistFull()             
                                    {                                       
                                        scientistID = sct.scientistID,              //Mã số nhà khoa học
                                        fullName = sct.sctFirstName + " " + sct.sctLastName + " - KH" + sct.scientistID,  //Tên + mã số nhà khoa học                                        
                                    };

                    _tpc.ScientistsCollection = ScientistList.ToList();
                    return View(_tpc);
                }                    
            }
            else    //  GET  TopicStoreOrEdit   id !=0
            {
                using (DBModel db = new DBModel())
                {
                    Topic topicob = new Topic();
                    topicob = db.Topics.Where(n => n.topicID == id).FirstOrDefault();    
                    topicob.ScientistIDArray = topicob.scientistIDs.Split(',').ToArray();
                    var ScientistList = from sct in db.Scientists   //Lấy bảng nhà khoa học
                                        select new ScientistFull()      
                                        {
                                            scientistID = sct.scientistID,   //Mã số nhà khoa học
                                            fullName = sct.sctFirstName + " " + sct.sctLastName + " - KH" + sct.scientistID,  //Tên + mã số nhà khoa học
                                        };
                    topicob.ScientistsCollection = ScientistList.ToList();

                    //ViewBag.ScientistsCollection = topicob.ScientistsCollection;
                    List<Field> fie = db.Fields.OrderByDescending(n => n.fieldID).ToList<Field>();
                    ViewBag.fie = fie;
                    List<Classification> cls = db.Classifications.OrderByDescending(n => n.classifiID).ToList<Classification>();
                    ViewBag.cls = cls;
                    List<Status> sts = db.Status.OrderByDescending(n => n.statusID).ToList<Status>();
                    ViewBag.sts = sts;
                    List<Scientist> _sct = db.Scientists.OrderByDescending(n => n.scientistID).ToList<Scientist>();
                    ViewBag.sct = _sct;                                       
                    if (topicob.tpcStartDate != null)
                    {
                        ViewBag.ngaybatdau = Convert.ToDateTime(topicob.tpcStartDate).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        ViewBag.ngaybatdau = null;
                    }
                    if (topicob.tpcDateOfAcceptance != null)
                    {
                        ViewBag.ngaynghiemthu = Convert.ToDateTime(topicob.tpcDateOfAcceptance).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        ViewBag.ngaynghiemthu = null;
                    }
                    if (topicob.tpcEndDate != null)
                    {
                        ViewBag.ngayketthuc = Convert.ToDateTime(topicob.tpcEndDate).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        ViewBag.ngayketthuc = null;
                    }
                    var nkh = _sct.Single(n => n.scientistID == topicob.scientistID);
                    ViewBag.tenNhaKhoaHoc = nkh.sctFirstName + " " + nkh.sctLastName + " - KH" +  nkh.scientistID;   //Lấy tên + mã nhà khoa học mặc định
                    var fieName = fie.Single(n => n.fieldID == topicob.fieldID);    //Lấy tên lĩnh vực hiển thị mặc định
                    ViewBag.fieldName = fieName.fieName + " " + fieName.fieldID;
                    var classfiName = cls.Single(n => n.classifiID == topicob.classifiID);  //Lấy tên xếp loại mặc định
                    ViewBag.classifiName = classfiName.clsName;
                    var statusName = sts.Single(n => n.statusID == topicob.statusID);      //Lấy tên trạng thái mặc định
                    ViewBag.statusName = statusName.stsName;
                    var tpc = db.Topics.Where(x => x.topicID == id).FirstOrDefault<Topic>();
                    ViewBag.tpcStartDate = tpc.tpcStartDate;
                    return View(topicob);
                }
            }
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult TopicStoreOrEdit(Topic topicob, FormCollection collection)
        {

            using (DBModel db = new DBModel())
            {
                if (topicob.topicID == 0)
                {
                    topicob.tpcCreateData = DateTime.Now;
                    if (collection.Get("ngay-bat-dau") != "")
                    {
                        topicob.tpcStartDate = Convert.ToDateTime(collection.Get("ngay-bat-dau"));
                    }
                    else
                    {
                        topicob.tpcStartDate = null;
                    }
                    if (collection.Get("ngay-nghiem-thu") != "")
                    {
                        topicob.tpcDateOfAcceptance = Convert.ToDateTime(collection.Get("ngay-nghiem-thu"));
                    }
                    else
                    {
                        topicob.tpcDateOfAcceptance = null;
                    }
                    if (collection.Get("ngay-ket-thuc") != "")
                    {
                        topicob.tpcEndDate = Convert.ToDateTime(collection.Get("ngay-ket-thuc"));
                    }
                    else
                    {
                        topicob.tpcEndDate = null;
                    }                   
                    if (ModelState.IsValid)
                    {
                        if (Request.Files.Count > 0)
                        {
                            HttpPostedFileBase file = Request.Files[0];
                            if (file.ContentLength > 0)
                            {
                                var fileName = db.Topics.Max(n => n.topicID) + Path.GetExtension(file.FileName);
                                topicob.tpcProofFile = Path.Combine(
                                Server.MapPath("~/Uploads/document/topic"), fileName);
                                file.SaveAs(topicob.tpcProofFile);
                                topicob.tpcProofFile = fileName;
                            }
                           
                        }
                    }
                    topicob.classifiID = int.Parse(collection.Get("xepLoai"));
                    topicob.scientistID = int.Parse(collection.Get("nhakhoahoc"));
                    topicob.fieldID = int.Parse(collection.Get("linhVuc"));
                    topicob.statusID = int.Parse(collection.Get("trangThai"));
                    if (topicob.ScientistIDArray != null)
                    {
                        topicob.scientistIDs = string.Join(",", topicob.ScientistIDArray);
                    }
                    else
                    {
                        topicob.scientistIDs = "";
                    }
                    db.Topics.Add(topicob);
                    db.SaveChanges();
                    return RedirectToAction("TopicManage", "Topic");
                }
                else    //POST TopicStoreOrEdit  id != 0
                {
                    if (ModelState.IsValid)
                    {
                        if (Request.Files.Count > 0)
                        {
                            HttpPostedFileBase file = Request.Files[0];
                            if (file.ContentLength > 0)
                            {
                                var fileName = db.Topics.Max(n => n.topicID) + Path.GetExtension(file.FileName);
                                topicob.tpcProofFile = Path.Combine(
                                Server.MapPath("~/Uploads/document/topic"), fileName);
                                file.SaveAs(topicob.tpcProofFile);
                                topicob.tpcProofFile = fileName;
                            }
                        }
                    }
                    topicob.tpcModifierData = DateTime.Now;
                    if(collection.Get("ngay-bat-dau") != "")
                    {
                        topicob.tpcStartDate = Convert.ToDateTime(collection.Get("ngay-bat-dau"));
                    }
                    else
                    {
                        topicob.tpcStartDate = null;
                    }
                    if (collection.Get("ngay-nghiem-thu") != "")
                    {
                        topicob.tpcDateOfAcceptance = Convert.ToDateTime(collection.Get("ngay-nghiem-thu"));
                    }
                    else
                    {
                        topicob.tpcDateOfAcceptance = null;
                    }
                    if (collection.Get("ngay-ket-thuc") != "")
                    {
                        topicob.tpcEndDate = Convert.ToDateTime(collection.Get("ngay-ket-thuc"));
                    }
                    else
                    {
                        topicob.tpcEndDate = null;
                    }                  
                    topicob.classifiID = int.Parse(collection.Get("xepLoai"));
                    topicob.scientistID = int.Parse(collection.Get("nhakhoahoc"));
                    topicob.fieldID = int.Parse(collection.Get("linhVuc"));
                    topicob.statusID = int.Parse(collection.Get("trangThai"));
                    if(topicob.ScientistIDArray != null)
                    {
                        topicob.scientistIDs = string.Join(",", topicob.ScientistIDArray);
                    }
                    else
                    {
                        topicob.scientistIDs = "";
                    }
                    db.Entry(topicob).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("TopicManage", "Topic");
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
            ViewBag.ViewIcon = "<i class='fas fa-eye - alt'></i>";
            return View();
        }    
        [HttpGet]
        public ActionResult TopicInfor(int? id)     //Hiện Popup thông tin đề tài (truyền vào mã số topicID nhà khoa học)
        {
            using (DBModel db = new DBModel())
            {
                var TopicList = from tpc in db.Topics                                        //Lấy bảng lớn Topic là đề tài nghiên cứu
                                join sct in db.Scientists on tpc.scientistID equals sct.scientistID     //Nối đến bảng nhà khoa học
                                join cls in db.Classifications on tpc.classifiID equals cls.classifiID  //Nối đến bảng xếp loại đề tài
                                join sts in db.Status on tpc.statusID equals sts.statusID               //Nối đến bảng trạng thái
                                join fie in db.Fields on tpc.fieldID equals fie.fieldID                 //Nối đến bảng lĩnh vực
                                where (tpc.topicID == id)
                                select new TopicFull()     // [W-A-R-N-I-N-G] những chỗ có liên kết các trường là khoá ngoại ở trên không được để NULL, cho nên nếu các hàng có hậu tố Name bên dưới RỖNG sẽ sinh lỗi không load lên được cả hàng đó
                                {
                                    topicID = tpc.topicID,                                  //Mã số đề tài
                                    scientistID = sct.scientistID,                          //Mã số nhà khoa học
                                    scientistName = sct.sctFirstName + " " + sct.sctLastName,     //Tên đầy đủ nhà khoa học
                                    classifiName = cls.clsName,                             //Tên xếp loại
                                    statusName = sts.stsName,                               //Trạng thái
                                    fieldName = fie.fieName,                                //Lĩnh vực

                                    tpcYear = tpc.tpcYear,                                  //Năm thực hiện
                                    tpcName = tpc.tpcName,                                  //Tên đề tài
                                    tpcSummary = tpc.tpcSummary,                            //Tóm tắt sơ lượt
                                    tpcCode = tpc.tpcCode,                                  //Mã số
                                    tpcStartDate = tpc.tpcStartDate,                        //Ngày bắt đầu thực hiện
                                    tpcEndDate = tpc.tpcEndDate,                            //Ngày kết thúc
                                    tpcDateOfAcceptance = tpc.tpcDateOfAcceptance,          //Ngày nghiệm thu
                                    tpcProofFile = tpc.tpcProofFile,                        //Tệp minh chứng
                                    tpcReviewBoard = tpc.tpcReviewBoard,                    //Hội đồng nghiệm thu
                                    tpcCreateData = tpc.tpcCreateData,                      //Thời gian khởi tạo
                                    tpcModifierData = tpc.tpcModifierData,                  //Thời gian thay đổi
                                    tpcCreateUser = tpc.tpcCreateUser,                      //Người khởi tạo
                                    tpcModifierUser = tpc.tpcModifierUser,                  //Người thay đổi
                                    tpcDeleteData = tpc.tpcDeleteData,                      //Thời gian xoá
                                    tpcDeleteUser = tpc.tpcDeleteUser,                      //Người xoá
                                    tpcImage = tpc.tpcImage,                                //Ảnh bìa
                                };
                var topicob = db.Topics.Where(n => n.topicID == id).FirstOrDefault<Topic>();                    
                    if (topicob.tpcStartDate != null)
                    {
                        ViewBag.ngaybatdau = Convert.ToDateTime(topicob.tpcStartDate).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        ViewBag.ngaybatdau = null;
                    }
                    if (topicob.tpcDateOfAcceptance != null)
                    {
                        ViewBag.ngaynghiemthu = Convert.ToDateTime(topicob.tpcDateOfAcceptance).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        ViewBag.ngaynghiemthu = null;
                    }
                    if (topicob.tpcEndDate != null)
                    {
                        ViewBag.ngayketthuc = Convert.ToDateTime(topicob.tpcEndDate).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        ViewBag.ngayketthuc = null;
                    }
                return View(TopicList.Single(n => n.topicID == id));                        //Trả về đề tài có mã số tương ứng ID truyền vào
            }
        }
    }
}