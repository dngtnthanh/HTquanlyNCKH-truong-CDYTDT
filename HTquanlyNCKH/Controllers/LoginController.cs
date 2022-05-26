using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTquanlyNCKH.Models;
namespace HTquanlyNCKH.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(FormCollection collection)
        {
            using (DBModel db = new DBModel())
            {
                string us = collection.Get("Username");
                string p = Security.MD5(collection.Get("Password"));
                Acount ac = db.Acounts.SingleOrDefault(a => a.Username == us && a.Password == p);
                if (ac != null)
                {
                    Session["Username"] = us;
                    Session["Permission"] = ac.Permission;
                    return RedirectToAction("Index", "admin");
                }
                else
                {
                    ViewBag.ThongBao = "Đăng nhập thất bại";
                }
                return View();
            }
               
        }
    }
}