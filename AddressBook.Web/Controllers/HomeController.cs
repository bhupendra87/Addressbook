using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddressBook.Database;
using AddressBook.Entities;
using AddressBook.Service;
using AddressBook.Web.Models;
using System.Web.Security;

namespace AddressBook.Web.Controllers
{
    public class HomeController : Controller
    {
        int userId = 1;
        private UserLogin obLogedInUser = null;
        public HomeController()
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                obLogedInUser = Singleton.Instance.obUserLogIn;
            }             
            
        }
      
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Phonedirectory()
        {
           if (TempData["message"] !=null)
            {
                ViewBag.message = TempData["message"];
            }
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            PhoneDirectoryService obPhoneDirService = new PhoneDirectoryService();
            List<Phonedirectory> list = obPhoneDirService.List(userId);
            return PartialView(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Phonedirectory obPhonedirectory)
        {
            string message = "";
            PhoneDirectoryService phoneDirectoryService = new PhoneDirectoryService();
            //int userid = obLogedInUser.UserId;
            obPhonedirectory.UserLogin = obLogedInUser;
            var result= phoneDirectoryService.Add(obPhonedirectory);
            if (result)
            {
                message = "Phonedirectory is created successfully !!!";
            }
            else
            {
                message = "Some error occured !!!";
            }
            return RedirectToAction("List");

        }

        [HttpGet]
        public ActionResult Edit(int phoneDirectoryId)
        {
            EditViewModel model = new EditViewModel();
            PhoneDirectoryService phoneDirectoryService = new PhoneDirectoryService();
            var data = phoneDirectoryService.getDetails(obLogedInUser.UserId,phoneDirectoryId);
            if(data !=null)
            {
                model.id = data.id;
                model.Name = data.Name;
                model.Mobile = data.Mobile;
                model.Email = data.Email;
                model.Website = data.Website;
                model.Address = data.Address;
                model.User_Id = data.UserLogin.UserId;               
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditViewModel Model)
        {
            EditViewModel model = new EditViewModel();
            PhoneDirectoryService phoneDirectoryService = new PhoneDirectoryService();
            Phonedirectory data = phoneDirectoryService.getDetails(obLogedInUser.UserId, Model.id);           
            return PartialView("List");
        }
    }
}