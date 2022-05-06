using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTquanlyNCKH.Models;
using System.Data.Entity;
namespace HTquanlyNCKH.Controllers
{
    public class ArticlesController : Controller
    {
        // GET: Articles
        public ActionResult Index()
        {
            return View();
        }

        //Quản lý quốc gia của bài báo
        public ActionResult NationGetData()
        {
            using (DBModel db = new DBModel())
            {
                List<Nation> nationList = db.Nations.ToList<Nation>();
                return Json(new { data = nationList },
                    JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult NationStoreOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Nation());
            }
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Nations.Where(x => x.nationID == id).FirstOrDefault<Nation>());
                }
            }
        }
        [HttpPost]
        public ActionResult NationStoreOrEdit(Nation nationob)
        {
            using (DBModel db = new DBModel())
            {
                if (nationob.nationID == 0)
                {
                    db.Nations.Add(nationob);
                    nationob.natCreateDate = DateTime.Now;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Lưu lại thành công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    nationob.natModifierDate = DateTime.Now;
                    db.Entry(nationob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
                }
            }
        }
        [HttpPost]
        public ActionResult NationDelete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Nation emp = db.Nations.Where(x => x.nationID == id).FirstOrDefault<Nation>();
                var nat = db.Articles.Where(n => n.nationID == id);
                if (nat.Count() < 1)
                {
                    db.Nations.Remove(emp);
                    db.SaveChanges();
                    return Json(new { success = true, mesage = "Xoá thành công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    string mess = "";
                    foreach (var item in nat)
                    {
                        mess += "\n [Mã bài báo: " + item.articlesID + ". Tên bài báo: " + item.atlName + ". Quốc gia: " + emp.natName + "]";
                    }

                    return Json(new
                    {
                        success = false,
                        message = "Xoá không thành công! Còn " + nat.Count() + " hàng dữ liệu trong danh sách bài báo quốc tế"
                         + mess,
                        JsonRequestBehavior.AllowGet
                    });
                }
                
            }
        }

        public ActionResult NationManage()
        {
            ViewBag.DeleteIcon = "<i class='fas fa-trash - alt'></i>";
            return View();
        }


        //Quản lý từ khoá
        public ActionResult KeyWordGetData()
        {
            using (DBModel db = new DBModel())
            {
                List<KeyWord> keywordList = db.KeyWords.ToList<KeyWord>();
                return Json(new { data = keywordList },
                    JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult KeyWordStoreOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new KeyWord());
            }
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.KeyWords.Where(x => x.keyID == id).FirstOrDefault<KeyWord>());
                }
            }
        }
        [HttpPost]
        public ActionResult KeyWordStoreOrEdit(KeyWord keywordob)
        {
            using (DBModel db = new DBModel())
            {
                if (keywordob.keyID == 0)
                {
                    db.KeyWords.Add(keywordob);
                    keywordob.keyCreateDate = DateTime.Now;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Lưu lại thành công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    keywordob.keyModifierDate = DateTime.Now;
                    db.Entry(keywordob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
                }
            }
        }
        [HttpPost]
        public ActionResult KeyWordDelete(int id)
        {
            using (DBModel db = new DBModel())
            {
                KeyWord emp = db.KeyWords.Where(x => x.keyID == id).FirstOrDefault<KeyWord>();
                db.KeyWords.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, mesage = "Xoá thành công!", JsonRequestBehavior.AllowGet });
            }
        }

        public ActionResult KeyWordManage()
        {
            ViewBag.DeleteIcon = "<i class='fas fa-trash - alt'></i>";
            return View();
        }

        //Quản lý thể loại bài viết
        public ActionResult ArtTypeGetData()
        {
            using (DBModel db = new DBModel())
            {
                List<ArtType> artTypeList = db.ArtTypes.ToList<ArtType>();
                return Json(new { data = artTypeList },
                    JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult ArtTypeStoreOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new ArtType());
            }
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.ArtTypes.Where(x => x.typeID == id).FirstOrDefault<ArtType>());
                }
            }
        }
        [HttpPost]
        public ActionResult ArtTypeStoreOrEdit(ArtType artTypeob)
        {
            using (DBModel db = new DBModel())
            {
                if (artTypeob.typeID == 0)
                {
                    db.ArtTypes.Add(artTypeob);
                    artTypeob.typCreateDate = DateTime.Now;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Lưu lại thành công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    artTypeob.typModifierDate = DateTime.Now;
                    db.Entry(artTypeob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
                }
            }
        }
        [HttpPost]
        public ActionResult ArtTypeDelete(int id)
        {
            using (DBModel db = new DBModel())
            {
                ArtType emp = db.ArtTypes.Where(x => x.typeID == id).FirstOrDefault<ArtType>();
                db.ArtTypes.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, mesage = "Xoá thành công!", JsonRequestBehavior.AllowGet });
            }
        }

        public ActionResult ArtTypeManage()
        {
            ViewBag.DeleteIcon = "<i class='fas fa-trash - alt'></i>";
            return View();
        }


        //Quản lý hội nghị
        public ActionResult ConferenceGetData()
        {
            using (DBModel db = new DBModel())
            {
                List<Conference> conferenceList = db.Conferences.ToList<Conference>();
                return Json(new { data = conferenceList },
                    JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult ConferenceStoreOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Conference());
            }
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Conferences.Where(x => x.conferenceID == id).FirstOrDefault<Conference>());
                }
            }
        }
        [HttpPost]
        public ActionResult ConferenceStoreOrEdit(Conference conferenceob)
        {
            using (DBModel db = new DBModel())
            {
                if (conferenceob.conferenceID == 0)
                {
                    db.Conferences.Add(conferenceob);
                    conferenceob.cfrCreateDate = DateTime.Now;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Lưu lại thành công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    conferenceob.cfrModifierDate = DateTime.Now;
                    db.Entry(conferenceob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
                }
            }
        }
        [HttpPost]
        public ActionResult ConferenceDelete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Conference emp = db.Conferences.Where(x => x.conferenceID == id).FirstOrDefault<Conference>();
                db.Conferences.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, mesage = "Xoá thành công!", JsonRequestBehavior.AllowGet });
            }
        }

        public ActionResult ConferenceManage()
        {
            ViewBag.DeleteIcon = "<i class='fas fa-trash - alt'></i>";
            return View();
        }

        //Quản lý bài báo quốc tế của nhà khoa học
        public ActionResult ArticlesGetData()
        {
            using (DBModel db = new DBModel())
            {
                List<Article> articlesList = db.Articles.ToList<Article>();
                return Json(new { data = articlesList },
                    JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult ArticlesStoreOrEdit(int id = 0)
        {
            using (DBModel db = new DBModel())
            {
                if (id == 0)
                {
                    List<Nation> nat = db.Nations.OrderByDescending(n => n.nationID).ToList<Nation>();
                    ViewBag.nat = nat;


                    List<Scientist> sct = db.Scientists.OrderByDescending(n => n.scientistID).ToList<Scientist>();
                    ViewBag.sct = sct;

                    List<KeyWord> key = db.KeyWords.OrderByDescending(n => n.keyID).ToList<KeyWord>();
                    ViewBag.key = key;

                    List<ArtType> types = db.ArtTypes.OrderByDescending(n => n.typeID).ToList<ArtType>();
                    ViewBag.types = types;

                    List<Field> fields = db.Fields.OrderByDescending(n => n.fieldID).ToList<Field>();
                    ViewBag.fieldList = fields;
                    return View(new Article());
                }
                else
                {
                    List<Nation> nat = db.Nations.OrderByDescending(n => n.nationID).ToList<Nation>();
                    ViewBag.nat = nat;

                    List<Scientist> sct = db.Scientists.OrderByDescending(n => n.scientistID).ToList<Scientist>();
                    ViewBag.sct = sct;

                    List<KeyWord> key = db.KeyWords.OrderByDescending(n => n.keyID).ToList<KeyWord>();
                    ViewBag.key = key;

                    List<ArtType> types = db.ArtTypes.OrderByDescending(n => n.typeID).ToList<ArtType>();
                    ViewBag.types = types;

                    List<Field> fields = db.Fields.OrderByDescending(n => n.fieldID).ToList<Field>();
                    ViewBag.fieldList = fields;
                    return View(db.Articles.Where(x => x.articlesID == id).FirstOrDefault<Article>());
                    
                }
            }
                
        }
        [HttpPost]
        public ActionResult ArticlesStoreOrEdit(Article articleob)
        {
            using (DBModel db = new DBModel())
            {
                if (articleob.articlesID == 0)
                {
                    articleob.scientistID = 1;
                    db.Articles.Add(articleob);
                    //articleob.cfrCreateDate = DateTime.Now;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Lưu lại thành công!", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    //articleob.cfrModifierDate = DateTime.Now;
                    db.Entry(articleob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
                }
            }
        }
        [HttpPost]
        public ActionResult ArticlesDelete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Article emp = db.Articles.Where(x => x.articlesID == id).FirstOrDefault<Article>();
                db.Articles.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, mesage = "Xoá thành công!", JsonRequestBehavior.AllowGet });
            }
        }

        public ActionResult ArticlesManage()
        {
            ViewBag.DeleteIcon = "<i class='fas fa-trash - alt'></i>";
            return View();
        }
    }
}