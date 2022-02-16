using managemen1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace managemen1.Controllers
{
    public class AdminController : Controller
    {
        
        myContext db = new myContext();
        public ActionResult Index()
        {
            if (Session["AdminLoginId"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult UserIndex()
        {
            if (Session["AdminLoginId"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }


        [HttpPost]
        public JsonResult deleteuser(int id)
        {
            myContext db = new myContext();
            userser d = db.usersers.Where(m => m.UserId == id).FirstOrDefault<userser>();
            db.usersers.Remove(d);
            db.SaveChanges();
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        public ActionResult WargaIndex()
        {
            if (Session["AdminLoginId"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        public JsonResult deletewarga (int id)
        {
            myContext db = new myContext();
        warga1 d = db.warga1.Where(m => m.WargaId == id).FirstOrDefault<warga1>();
        db.warga1.Remove(d);
        db.SaveChanges();
        return Json("success", JsonRequestBehavior.AllowGet);
        }

        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminLogin adm)
        {
            AdminLogin ad = db.AdminLogins.Where(x => x.AdminUserName == adm.AdminUserName && x.AdminPassword == adm.AdminPassword).FirstOrDefault();
            if (ad != null)
            {
                Session["AdminLoginId"] = ad.AdminLoginId.ToString();
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.error = "Invalid username and passwword";
            }
            return View();
        }



        public ActionResult LoadDataUser()
        {
            var model = db.Database.SqlQuery<userserViewModel>("call display_userser");
            //var warList = db.warga1.ToList<warga1>();            
            return Json(new { data = model }, JsonRequestBehavior.AllowGet);
         


        }
        public ActionResult loadDataWarga()
        {

            var model = db.Database.SqlQuery<displayDataWargaViewModel>("call display_warga1");
            //var warList = db.warga1.ToList<warga1>();            
            return Json(new { data = model }, JsonRequestBehavior.AllowGet);
            //List<warga1> wargaList = new List<warga1>();
            //using (myContext db = new myContext())
            //{
            //    wargaList = db.warga1.ToList<warga1>();
            //    return Json(new { data = wargaList }, JsonRequestBehavior.AllowGet);
            //}
        }

       
        public ActionResult SignOut()
        {
            Session.RemoveAll();
            Session.Abandon();

            return RedirectToAction("Login");

        }

    }
}