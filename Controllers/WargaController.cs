using managemen1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace managemen1.Controllers
{
    public class WargaController : Controller
    {
        myContext db = new myContext();
        
        // GET: Warga
        public ActionResult Index()
        {
            if (Session["WargaLoginId"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
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

        public ActionResult Create()
        {
            List<WargaSetting> li = db.WargaSettings.ToList();
            List<WargaSettingAnggota> lii = db.WargaSettingAnggotas.ToList();
            List<WargaSettingRumah> lli = db.WargaSettingRumahs.ToList();
            ViewBag.WargaSettinglist = new SelectList(li, "WargaSetId", "WargaSet");
            ViewBag.WargaSettingAnggotalist = new SelectList(lii, "WargaSetId", "WargaAnggotaKeluarga");
            ViewBag.WargaSettingRumahlist = new SelectList(lli, "WargaSetId", "WargaSetRumah");
            if (Session["WargaLoginId"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(warga1 wrg, HttpPostedFileBase imageFile)
        {

            List<WargaSetting> li = db.WargaSettings.ToList();
            List<WargaSettingAnggota> lii = db.WargaSettingAnggotas.ToList();
            List<WargaSettingRumah> lli = db.WargaSettingRumahs.ToList();
            ViewBag.WargaSettinglist = new SelectList(li, "WargaSetId", "WargaSet");
            ViewBag.WargaSettingAnggotalist = new SelectList(lii, "WargaSetId", "WargaAnggotaKeluarga");
            ViewBag.WargaSettingRumahlist = new SelectList(lli, "WargaSetId", "WargaSetRumah");           

            string path = UploadImageFile(imageFile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded";
            }
            else
            {
                warga1 pro = new warga1();
                pro.WargaName = wrg.WargaName;
                pro.WargaNoTelp = wrg.WargaNoTelp;
                pro.Warga_fk_Set = wrg.Warga_fk_Set;                
                pro.Warga_fk_AnggotaKeluarga = wrg.Warga_fk_AnggotaKeluarga;
                pro.Warga_fk_SetRumah = wrg.Warga_fk_SetRumah;
                pro.WargaImage = path;
                db.warga1.Add(pro);
                db.SaveChanges();
                Response.Redirect("Index");
            }
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(WargaLogin warga, HttpPostedFileBase imageFile)
        {
            string path = UploadImageFile(imageFile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded";
            }
            else
            {
                WargaLogin wr = new WargaLogin();
                wr.WargaNama = warga.WargaNama;
                wr.WargaPassword = warga.WargaPassword;
                wr.WargaImage = path;
                wr.WargaContact = warga.WargaContact;
                db.WargaLogins.Add(wr);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult SignOut()
        {
            Session.RemoveAll();
            Session.Abandon();

            return RedirectToAction("Login");

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(WargaLogin warga)
        {
            WargaLogin wr = db.WargaLogins.Where(x => x.WargaNama == warga.WargaNama && x.WargaPassword == warga.WargaPassword).FirstOrDefault();
            if (wr != null)
            {
                Session["WargaLoginId"] = wr.WargaLoginId.ToString();
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.error = "Invalid username and passwword";
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