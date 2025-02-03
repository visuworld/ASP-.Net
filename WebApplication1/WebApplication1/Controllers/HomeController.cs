using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        conn db = new conn();//object db
        demo_dbEntities dbs = new demo_dbEntities();// facebook register object

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult about()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult reg()
        {
            return View();
        }
        //facebook login page
        public ActionResult facebooklogin()
        {
            return View();
        }

        public ActionResult facebookregister()
        {
            return View();
        }
        public ActionResult table()
        {
            var res = db.insertRegistration_tbl.ToList();
            return View(res);
        }
        public ActionResult  DeleteData(int id)
        {
            var res = db.insertRegistration_tbl.Where(x => x.id == id).First(); //record fetch
            db.insertRegistration_tbl.Remove(res); //record remove
            db.SaveChanges();
            var freshlist = db.insertRegistration_tbl.ToList();
            return View("table",freshlist);

            Response.Write("<script>alert('record deleted')</script>");
            
        }



        //Post method
        [HttpPost]
        public ActionResult InsertRegistration(insertRegistration_tbl res)
        {
            db.insertRegistration_tbl.Add(res);
            db.SaveChanges(); // data push on server

            Response.Write("<script>alert('data save')</script>");
            return View("reg");
        }
        //get user login jo isme password save hai usi se  data match krega
        [HttpPost]
        public ActionResult getuserlogin(Webapplicationlogin form)
        {
            var result = db.Webapplicationlogins.Where(x => x.email == form.email && x.password == form.password).FirstOrDefault();

            if (result == null)
            {
                Response.Write("<script>alert('incorrect user name or password')</script>");
            }
            else
            {
                Response.Write("<script>alert('Login successful')</script>");
            }

            return View("Login");
        }
        //faceboook register coding
        public ActionResult register(facebookRegister reg)
        {
            dbs.facebookRegisters.Add(reg);
            dbs.SaveChanges();
            Response.Write("<script>alert('regidtration successfully')</script>");
            return View("facebookregister");
        }
        [HttpPost]
        public ActionResult login(facebookRegister result)

        {
            var res = dbs.facebookRegisters.Where(x => x.Mobile_email == result.Mobile_email && x.password == result.password).FirstOrDefault();
            if (res == null)
            {
                Response.Write("<script>alert('password or user name mismathed')</script>");
            }
            else
            {
                Response.Write("<script>alert('login successfully')</script>");
            }
            return View("facebookregister");
        }

    }
}