using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTquanlyNCKH.Models;
using System.Data.Entity;
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

        //[HttpPost]
        //public ActionResult ClassifiDelete(int id)      //Xoá phân loại đề tài
        //{
        //    using (DBModel db = new DBModel())
        //    {
        //        Classification emp = db.Classifications.Where(x => x.classifiID == id).FirstOrDefault<Classification>();

        //        if (db.Topics.SingleOrDefault(n => n.classifiID == id) == null)
        //        {
        //            db.Classifications.Remove(emp);
        //            db.SaveChanges();
        //            return Json(new { success = true, message = "Xoá thành công!", JsonRequestBehavior.AllowGet });
        //        }
        //        else
        //        {
        //            var tpc = db.Topics.Single(n => n.classifiID == id);
        //            return Json(new { success = false, message = "Xoá không thành công! Còn tồn tại dữ liệu trong đề tài mã số: " + tpc.topicID + ", tên: " + tpc.tpcName, JsonRequestBehavior.AllowGet });
        //        }
        //    }
        //}

        [HttpPost]
        public ActionResult ClassifiDelete(int id)      //Xoá phân loại đề tài
        {
            using (DBModel db = new DBModel())
            {
                Classification emp = db.Classifications.Where(x => x.classifiID == id).FirstOrDefault<Classification>();
                var tpc = db.Topics.Where(n => n.classifiID == id);    //Kiểm tra xem có tồn tại id của classifi trong bảng Topic
                if (tpc == null)      //Kiểm tra toàn vẹn dữ liệu
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
                        mess += "\n Mã đề tài: " + item.topicID + " tên đề tài: " + item.tpcName;
                    }

                    return Json(new { success = false, message = "Xoá không thành công! Còn tồn tại dữ liệu trong" +
                        " " + mess , JsonRequestBehavior.AllowGet });
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
                db.Fields.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Xoá thành công!", JsonRequestBehavior.AllowGet });
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
                db.Status.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Xoá thành công!", JsonRequestBehavior.AllowGet });
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
        public ActionResult TopicStoreOrEdit(Topic topicob, FormCollection collection)
        {
            using (DBModel db = new DBModel())
            {
                if (topicob.topicID == 0)
                {
                    db.Topics.Add(topicob);
                    topicob.tpcCreateData = DateTime.Now;
                    topicob.tpcStartDate = Convert.ToDateTime(collection.Get("ngay-bat-dau"));
                    db.SaveChanges();
                    return Json(new { success = true, message = "Lưu lại thành công!", JsonRequestBehavior.AllowGet });
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
            ViewBag.ViewIcon = "<i class='fas fa-eye - alt'></i>";
            return View();
        }


        //Truy xuất API
        public ActionResult ApiGetData()
        {
            using (DBModel db = new DBModel())
            {
                List<Field> fieldList = db.Fields.ToList<Field>();
                return Json(new { data = fieldList },
                JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult ApiStoreOrEdit(int id = 0)
        {
            if (id == 0)
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
        public ActionResult ApiStoreOrEdit(Field fieldob)
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
        public ActionResult ApiDelete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Field emp = db.Fields.Where(x => x.fieldID == id).FirstOrDefault<Field>();
                db.Fields.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Xoá thành công!", JsonRequestBehavior.AllowGet });
            }
        }
        public ActionResult ApiManage()
        {
            ViewBag.DeleteIcon = "<i class='fas fa-trash - alt'></i>";
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
                                    scientistID = sct.scientistID,
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

                return View(TopicList.Single(n => n.topicID == id));                        //Trả về đề tài có mã số tương ứng ID truyền vào
            }

        }
    }
}