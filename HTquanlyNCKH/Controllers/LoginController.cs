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
                Acount acUser = db.Acounts.SingleOrDefault(a => a.Username.Contains(us));
                Acount acPass = db.Acounts.SingleOrDefault(a => a.Password.Contains(p));
                try
                {
                    if (acUser != null && acPass != null)
                    {
                        Session["Username"] = us;
                        Session["Permission"] = acPass.Permission;
                        return RedirectToAction("Index", "admin");
                    }
                    else
                    {
                        if (acUser == null)
                        {
                            ViewBag.error = "Tên đăng nhập hoặc mật khẩu sai";
                        }
                        else
                        {
                            if (acPass == null)
                            {
                                ViewBag.error = "Mật khẩu sai";
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    ViewBag.error = e;
                }                
                return View();
            }               
        }
    }
}