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
        public ActionResult ClassifiGetData()
        {
            using (DBModel db = new DBModel())
            {
                
                List<Classification> classifiList = db.Classifications.ToList<Classification>();
                return Json(new { data = classifiList },
                JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpGet]
        public ActionResult ClassifiStoreOrEdit(int id = 0)
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
        public ActionResult ClassifiStoreOrEdit(Classification classificationob)
        {
            using (DBModel db = new DBModel())
            {
                if (classificationob.classifiID == 0)
                {
                    db.Classifications.Add(classificationob);
                    classificationob.clsCreateDate = DateTime.Now;  //Lưu lại thời gian khởi tạo
                    db.SaveChanges();
                    return Json(new { success = true, message = "Lưu lại thành công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    classificationob.clsModifierDate = DateTime.Now;
                    db.Entry(classificationob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
                }
            }
        }
        [HttpPost]
        public ActionResult ClassifiDelete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Classification emp = db.Classifications.Where(x => x.classifiID == id).FirstOrDefault<Classification>();
                db.Classifications.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Xoá thành công!", JsonRequestBehavior.AllowGet });
            }
        }

        public ActionResult ClassifiManage()
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
                    return Json(new { success = true, message = "Lưu lại thànhc công!", JsonRequestBehavior.AllowGet });
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