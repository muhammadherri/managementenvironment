using managemen1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;

namespace managemen1.Controllers
{
    public class UserController : Controller
    {

        myContext db = new myContext();

        // GET: User
        public ActionResult Index()
        {
            if (Session["UserLoginId"] == null)
            {
                return RedirectToAction("Login");
            }
            return View(new List<Models.userser>());
        }

        public ActionResult LoadDataUser()
        {
            var model = db.Database.SqlQuery<userserViewModel>("call display_userser");
            //var warList = db.warga1.ToList<warga1>();            
            return Json(new { data = model }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserLogin user, HttpPostedFileBase imageFile)
        {
            string path = UploadImageFile(imageFile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded";
            }
            else
            {
                UserLogin pro = new UserLogin();
                pro.UserName = user.UserName;
                pro.UserPassword = user.UserPassword;
                pro.UserContact = user.UserContact;
                pro.UserImage = path;
                db.UserLogins.Add(pro);
                db.SaveChanges();
                Response.Redirect("Login");
            }
            return View();
        }


        public ActionResult SignOut()
        {
            Session.RemoveAll();
            Session.Abandon();

            return RedirectToAction("Index");

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin user)
        {
            UserLogin us = db.UserLogins.Where(x => x.UserName == user.UserName && x.UserPassword == user.UserPassword).FirstOrDefault();
            if (us != null)
            {
                Session["UserLoginId"] = us.UserLoginId.ToString();
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.error = "Invalid username and passwword";
            }
            return View();
        }

        public ActionResult Create()
        {
            List<UsersSetting> li = db.UsersSettings.ToList();
            ViewBag.userlist = new SelectList(li, "UserSetId", "UserSet");

            if (Session["UserLoginId"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(userser user, HttpPostedFileBase imageFile)
        {

            List<UsersSetting> li = db.UsersSettings.ToList();
            ViewBag.userlist = new SelectList(li, "UserSetId", "UserSet");

            string path = UploadImageFile(imageFile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded";
            }
            else
            {
                userser pro = new userser();
                pro.UserName = user.UserName;
                pro.UserEmail = user.UserEmail;
                pro.UserNoTelp = user.UserNoTelp;
                pro.UserImage = path;
                pro.User_fk_Set = user.User_fk_Set;
                db.usersers.Add(pro);
                db.SaveChanges();
                Response.Redirect("Index");
            }
            return View();
        }

        public string UploadImageFile(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string exstension = Path.GetExtension(file.FileName);
                if (exstension.ToLower().Equals(".jpg") || exstension.ToLower().Equals(".jpeg") || exstension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/Upload/"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/Upload/" + random + Path.GetFileName(file.FileName);
                    }

                    catch (Exception ex)
                    {
                        path = "-1";
                    }

                }
                else
                {
                    Response.Write("<script>alert('Only jpg,jpeg and png format are accepted');<script>");
                }
            }
            else
            {
                Response.Write("<script>alert('please select a file');<script>");
                path = "-1";
            }

            return path;

        }
    }
}