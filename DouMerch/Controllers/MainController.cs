using DouMerch.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DouMerch.Db;
using DouMerch.Models;
using System.Linq;

namespace DouMerch.Controllers
{
    [SessionControl]
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            var db = new Context();
            MainModel mainModel = new MainModel();
            mainModel.Categories = db.Category.ToList();
            mainModel.Products = db.Products.ToList();

            return View(mainModel);
        }
    }
}