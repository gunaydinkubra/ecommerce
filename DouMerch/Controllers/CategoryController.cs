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
    public class CategoryController : Controller
    {
        // GET: Category

        [HttpGet]
        public ActionResult Category()
        {
            var db = new Context();
            var data = db.Category.ToList();

            return View(data);
        }

        [HttpPost]
        public ActionResult SaveOrUpdate(CategoryModel category)
        {

            var db = new Context();

            var getCategory = db.Category.Where(w => w.Id == category.Id).FirstOrDefault();

            if (getCategory != null)
            {
                getCategory.Imageurl = category.Imageurl;
                getCategory.Name = category.Name;
                getCategory.Description = category.Description;


                db.Category.Attach(getCategory);
                db.Entry(getCategory).State = EntityState.Modified;
                db.SaveChanges();
                ModelState.Clear();
                ViewData["Success"] = $"Successfull! Your Category is updated. ";

                return View();
            }

            db.Category.Add(new CategoryModel
            {
                Imageurl = category.Imageurl,
                Name = category.Name,
                Description = category.Description,
                CreatedDate = DateTime.Now
            });
            db.SaveChanges();
            ViewData["Success"] = $"Successfull! Your Category is added. ";

            return View();
        }

        [HttpDelete]
        public ActionResult Delete(long categoryId)
        {

            var db = new Context();

            var getCategory = db.Category.Where(w => w.Id == categoryId).FirstOrDefault();

            if (getCategory == null)
            {
                ViewData["Warning"] = "Category not found.";

                return View();
            }

            db.Category.Remove(getCategory);
            ViewData["Success"] = $"Successfull! Your Category is deleted. ";
            return View();
        }
    }
}