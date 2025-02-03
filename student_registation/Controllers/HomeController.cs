using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using student_registation.Models;

namespace student_registation.Controllers
{
    public class HomeController : Controller
    {
        PjEntities db = new PjEntities();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Students_Reg()
        {
            //studentReg sc = new studentReg();
            //if (id != 0)
            //{

               
            //    sc = db.studentRegs.Where(x => x.id == id).FirstOrDefault();
            //    return View(sc);
            //}
            //else
            //{ 
            //    var model = new student_registation.Models.studentReg();
               return View();
            

        }
        [HttpPost]
        public ActionResult Students_Reg(studentReg res)
        {

            if (res.Password == res.Re_Password)
            {
                //if (res.id == 0)

                db.studentRegs.Add(res);
                db.SaveChanges();
                Response.Write("<script>alert('Data Saved Successfully !')</Script>");
            }

            //}
            //else
            //{
            //    db.Entry(res).State = EntityState.Modified; // data update
            //    Response.Write("<script>alert('Re-Password not match')</script>");

            //}
            else
            {
                Response.Write("<script>alert('password and repassword not match!')</Script>");

            }
            return RedirectToAction("ShowData", "Home");

        }



        public ActionResult ShowData()
        {
            var model = db.studentRegs.ToList();
            return View(model);
        }

        public ActionResult Student_update(int id = 0)
        {
            if (id != 0)
            {
                var delres = db.studentRegs.Where(X => X.id == id).First();

                return View(delres);
            }
            else
            {

                return RedirectToAction("ShowData","Home");
            }
        }




            

        public ActionResult Delete(int id)
        {
            var delres = db.studentRegs.Where(X => X.id == id).FirstOrDefault();
            db.studentRegs.Remove(delres);
            db.SaveChanges();
            var newdata = db.studentRegs.ToList();
            return View("ShowData",newdata);
        }


       

        [HttpPost]
        public ActionResult PostUpdatePage(studentReg rec)
        {
            db.Entry(rec).State = EntityState.Modified;
            db.SaveChanges();
            Response.Write("<script>alert('data update' !)</script>");

            //var freshlist = db.studentRegs.ToList();
            //return View("ShowData",freshlist);
            return RedirectToAction("ShowData", "Home");
        }

    }
}