using DouMerch.Attributes;
using DouMerch.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DouMerch.Controllers
{
    [SessionControl]
    public class ProductDetailController : Controller
    {

        [HttpGet]
        public ActionResult EditProduct(long productId)
        {
            var db = new Context();

            var data = db.Products.Where(w => w.Id == productId).FirstOrDefault();

            if (data == null)
            {
                ViewData["Warning"] = "Product not found.";

                return View();
            }
            return View("_EditProduct", data);
        }

        [HttpGet]
        public ActionResult ProductDetail(long productId)
        {
            var db = new Context();

            var data = db.Products.Where(w => w.Id == productId).FirstOrDefault();

            if(data == null)
            {
                ViewData["Warning"] = "Product not found.";

                return View();
            }
            return View(data);
        }
    }
}