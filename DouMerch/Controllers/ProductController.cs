using DouMerch.Attributes;
using DouMerch.Db;
using DouMerch.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DouMerch.Controllers
{
    [SessionControl]
    public class ProductController : Controller
    {
        [HttpGet]
        public ActionResult Product(int? categoryId)
        {
            var db = new Context();
            List<ProductModel> data = null;
            if (categoryId.HasValue && categoryId != 0)
                data = db.Products.Where(w => w.CategoryId == categoryId).ToList();
            else
                data = db.Products.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult SaveOrUpdate(ProductModel product)
        {

            var db = new Context();

            var getProduct = db.Products.Where(w => w.Id == product.Id).FirstOrDefault();

            if (getProduct != null)
            {
                getProduct.ImageUrl = product.ImageUrl;
                getProduct.Name = product.Name;
                getProduct.Description = product.Description;
                getProduct.CategoryId = product.CategoryId;
                getProduct.Cost = product.Cost;

                db.Products.Attach(getProduct);
                db.Entry(getProduct).State = EntityState.Modified;
                db.SaveChanges();
                ModelState.Clear();
                ViewData["Success"] = $"Successfull! Your Product is updated. ";

                return View();
            }

            db.Products.Add(new ProductModel
            {
                ImageUrl = product.ImageUrl,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Cost = product.Cost,
                CreatedDate = DateTime.Now
            });
            db.SaveChanges();
            ViewData["Success"] = $"Successfull! Your Product is added. ";

            return View();
        }
    }
}