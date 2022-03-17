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

        //public ActionResult listViewClassifi(int? idPage, int? id)
        //{
        //    NCKHDataContext context = new NCKHDataContext();
        //    var cls = from n in context.Classifications.OrderByDescending(n => n.classifiID)
        //              select n;
        //    if (id != null)
        //    {
        //        Classification _cls = context.Classifications.Single(n => n.classifiID == id);
        //        ViewBag.Name = _cls.clsName;
        //        ViewBag.Dest = _cls.clsDesciption;
        //        ViewBag.ID = _cls.classifiID;
        //    }
        //    else
        //    {
        //        int _id = context.Classifications.Max(n => n.classifiID) + 1;
        //        ViewBag.ID = _id;
        //    }
        //    int pagesize = 4;
        //    int pageindex = idPage ?? 1;
        //    return View(cls.ToPagedList(pageindex, pagesize));
        //}

        //[AcceptVerbs(HttpVerbs.Get)]
        //public ActionResult addClassifi(int id)
        //{
        //    NCKHDataContext context = new NCKHDataContext();
        //    Classification cls = context.Classifications.Single(n => n.classifiID == id);
        //    ViewBag.Name = cls.clsName;
        //    ViewBag.Dest = cls.clsDesciption;

        //    return RedirectToAction("listViewClassifi", "Admin", id);
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult addClassifi(FormCollection collection, int? id, int? idPage)
        //{
        //    try
        //    {
        //        NCKHDataContext context = new NCKHDataContext();
        //        int _id = context.Classifications.Max(n => n.classifiID) + 1;
        //        if (_id == id)
        //        {

        //            Classification cls = new Classification();
        //            cls.classifiID = _id;
        //            cls.clsName = collection.Get("Name");
        //            cls.clsDesciption = collection.Get("Dest");
        //            context.Classifications.InsertOnSubmit(cls);
        //            context.SubmitChanges();
        //        }
        //        else 
        //        {
        //            var cls = context.Classifications.Single(n => n.classifiID == id);
        //            cls.clsName = collection.Get("Name");
        //            cls.clsDesciption = collection.Get("Dest");
        //            context.SubmitChanges();
        //        }
        //        return RedirectToAction("listViewClassifi", "Admin", new { idPage });
        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.Error = e;
        //        return View();
        //    }

        //}
        //[AcceptVerbs(HttpVerbs.Get)]
        //public ActionResult modiClassifi(int id)
        //{

        //    NCKHDataContext context = new NCKHDataContext();
        //    Classification cls = context.Classifications.Single(n => n.classifiID == id);            

        //    return View(cls);
        //}
        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult modiClassifi(int id, FormCollection collection)
        //{
        //    Classifi cls = new Classifi();
        //    cls.modiClassifi(id, collection.Get("Name"), collection.Get("Dest"));
        //    return RedirectToAction("listViewClassifi", "Admin");
        //}

        //public ActionResult deleteClassifi(int id)
        //{
        //    Classifi cls = new Classifi();
        //    cls.deleteClassifi(id);
        //    return RedirectToAction("listViewClassifi","Admin");
        //}

        //public ActionResult Test34()
        //{
        //    return RedirectToAction("About", "Home");
        //}

        ////[HttpPost]
        ////public ActionResult CreateClassifi(Classification cls)
        ////{
        ////    NCKHDataContext context = new NCKHDataContext();

        ////    return Json(context.Classifications.InsertOnSubmit(cls), JsonRequestBehavior.AllowGet);


        ////}






        //public ActionResult ClassifiGetData()
        //{
        //    using (NCKHDataContext db = new NCKHDataContext())
        //    {
        //        List<Classification> classifiList = db.Classifications.ToList<Classification>();
        //        return Json(new { data = classifiList },
        //            JsonRequestBehavior.AllowGet);
        //    }
        //}

        //[HttpGet]
        //public ActionResult ClassifiStoreOrEdit(int id = 0)
        //{
        //    if (id == 0)
        //    {
        //        return View(new Classification());
        //    }
        //    else
        //    {
        //        using (NCKHDataContext db = new NCKHDataContext())
        //        {
        //            return View(db.Classifications.Where(x => x.classifiID == id).FirstOrDefault<Classification>());
        //        }
        //    }

        //}
        //[HttpPost]
        //public ActionResult ClassifiStoreOrEdit(Classification classification)
        //{
        //    using (NCKHDataContext db = new NCKHDataContext())
        //    {
        //        if (classification.classifiID == 0)
        //        {
        //            db.Classifications.InsertOnSubmit(classification);
        //            db.SubmitChanges();
        //            return Json(new { success = true, message = "Lưu lại thành công", JsonRequestBehavior.AllowGet });
        //        }
        //        else
        //        {
        //            return View();
        //        }
        //    }
        //}





    }
}