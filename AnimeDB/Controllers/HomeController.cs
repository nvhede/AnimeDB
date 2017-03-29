using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimeDB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() //Homepage
        {
            return View();
        }

        public ActionResult About() //about us
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Search() //search page
        {
            return View();
        }

        public ActionResult Add() //page for adding forms
        {
            return View();
        }

        public ActionResult AddSuccess() //sucess for adding form
        {
            return View();
        }

    }
}