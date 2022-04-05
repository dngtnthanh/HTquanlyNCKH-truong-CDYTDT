using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HTquanlyNCKH.Models;
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
                db.Degrees.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, mesage = "Xoá thành công!", JsonRequestBehavior.AllowGet });
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
                db.Foreigns.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, mesage = "Xoá thành công!", JsonRequestBehavior.AllowGet });
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
                    db.Places.Add(placeob);
                    placeob.plaCreateDate = DateTime.Now;
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
                db.Places.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, mesage = "Xoá thành công!", JsonRequestBehavior.AllowGet });
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
                db.Units.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, mesage = "Xoá thành công!", JsonRequestBehavior.AllowGet });
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
                //List<Place> fie = db.Places.OrderByDescending(n => n.).ToList<Place>();
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
                }
                

                return View(new Scientist());
            }
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Scientists.Where(x => x.scientistID == id).FirstOrDefault<Scientist>());
                }
            }
        }
        [HttpPost]
        public ActionResult ScientistStoreOrEdit(Scientist scientistob)
        {
            using (DBModel db = new DBModel())
            {
                if (scientistob.scientistID == 0)
                {
                    db.Scientists.Add(scientistob);
                    scientistob.sctCreateDate = DateTime.Now;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Lưu lại thành công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    scientistob.sctModifierDate = DateTime.Now;
                    db.Entry(scientistob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
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
            return View();
        }
    }
}