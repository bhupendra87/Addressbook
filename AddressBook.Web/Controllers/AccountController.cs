using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AddressBook.Database;
using AddressBook.Entities;
using AddressBook.Service;

namespace AddressBook.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserLogin obUserLogin)
        {
            UserLoginService userLoginService = new UserLoginService();
            bool ret = userLoginService.AddUser(obUserLogin);
            if (ret)
                ViewBag.message = "User is successfully registred !!!";
            else
                ViewBag.message = "Some error occured.Please try again !!!";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin obUserLogin)
        {
            UserLoginService userLoginService = new UserLoginService();
            bool ret = userLoginService.authenticationUser(obUserLogin.UserName, obUserLogin.UserPwd);
            if (ret)
            {
                return RedirectToAction("Index","Home");
            }
            else
                ViewBag.message = "Invalid UserName or Password.Please try again !!!";

            return View();
        }

        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}