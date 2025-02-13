using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using JeecUp.DAL;
using JeecUp.Models;

namespace JeecUp.Controllers
{
    public class HomeController : Controller
    {
        DbLayer db = new DbLayer();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration_Form()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult SaveRecord(string Name, string Father, string Mother,string DOB, string Gender,
            string Mobile,string Email, string Password, string Cpwd)
        {
            RegisterModel model = new RegisterModel();
            //model.id;
            model.name = Name;
            model.fathername = Father;
            model.mothername = Mother;
            model.dob = DOB;
            model.gender = Gender;
            model.mobile = Mobile;
            model.email = Email;
            model.password = Password;
            model.confirmpassword = Cpwd;

            var res = db.InsertData_Regform(model);

            return Json(new {Message=res.msg, success=true});
        }


        public ActionResult ShowData()
        {
            var abc =db.GetDatafromProc().ToList();
            return View(abc);
        }

        public ActionResult UpdateData(int id)
        {

            var abc = db.GetDatafromProc().ToList();
            
            return View();
        }

        public void Delete(int id)
        {
            var res = db.DeleteRecord(id);
            Response.Write("<script>alert('Deleted Record'; window.location.href='home/ShowData')</script>");
            //return RedirectToAction("ShowData");
        }

    }
}