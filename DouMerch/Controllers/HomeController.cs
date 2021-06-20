using DouMerch.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DouMerch.Controllers
{
    
    //[SessionControl]//Login bilgisi ile bir sayfa açılmak isteniyorsa o sayfanın controller'ına _SessionControl attribute eklenmeli
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }


    }
}