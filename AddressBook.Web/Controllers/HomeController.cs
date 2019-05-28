using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddressBook.Database;
using AddressBook.Entities;
using AddressBook.Service;

namespace AddressBook.Web.Controllers
{
    public class HomeController : Controller
    {
        int userId = 1;

        public HomeController()
        {
           User.Identity.
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
           
            PhoneDirectoryService phoneDirectoryService = new PhoneDirectoryService();
            var result= phoneDirectoryService.Add(obPhonedirectory);
            if (result)
            {
                TempData["message"] = "Phonedirectory is created successfully !!!";
            }
            else
            {
                TempData["message"] = "Some error occured !!!";
            }
            return RedirectToAction("Phonedirectory");

        }
        
    }
}