using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_name.Models;

namespace Project_name.Controllers
{
    public class HomeController : Controller
    {
        TCLEntities db = new TCLEntities();
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult Login()
        {
            return View();
        }

        
        public ActionResult Register()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Register(std res)
        {    if(res.password==res.re_password)
            {
                db.stds.Add(res);
                db.SaveChanges();
                Response.Write("<script>alert('Your data Save my webside')</script>");
                return RedirectToAction("ViewData","Home");
               
            }
            else
            {
                Response.Write("<script>alert('Your password and Re password not match and try....!')</script>");
                return View();
            }
            
        }
        public ActionResult Update(int id=0)
        {
            if(id != 0)
            {
                var data = db.stds.Where(x => x.id == id).First();

                return View(data);
            }
            else
            {
                return RedirectToAction("Register","Home");
            }

           
        }

        [HttpPost]
        public ActionResult Update(std res)
        {
            if (res.password == res.re_password)
            {
                db.Entry(res).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewData", "Home");
            }
            else
            {

                return RedirectToAction("ViewData", "Home");
            }
        }

        public ActionResult ViewData()
        {
            
            var result = db.stds.ToList();
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return View("Register");
            }

            }
        public ActionResult Delete(int id)
        {
            var data = db.stds.Where(x=> x.id == id).First();
            db.stds.Remove(data);
            db.SaveChanges();
            return RedirectToAction("ViewData", "Home");
            //Use TCL as db
            //Select top 1 * from stds as x where(x.id=id)
        }
    }
}