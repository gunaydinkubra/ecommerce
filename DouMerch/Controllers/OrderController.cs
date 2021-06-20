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
    public class OrderController : Controller
    {

        [HttpGet]
        public ActionResult Order(long? userId)
        {
            var db = new Context();
            List<OrderModel> data = null;
            if (userId.HasValue && userId != 0)
                data = db.Orders.Where(w => w.UserId == userId).ToList();
            else
                data = db.Orders.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Order(OrderModel order)
        {
            var db = new Context();

            var userOrder = db.Orders.Where(w => w.UserId == order.UserId && w.ProductId == order.ProductId).FirstOrDefault();
            if (userOrder != null)
            {
                userOrder.ItemCount = userOrder.ItemCount + order.ItemCount;
                db.Orders.Attach(userOrder);
                db.Entry(userOrder).State = EntityState.Modified;
                db.SaveChanges();
                ModelState.Clear();
            }
            else
            {
                db.Orders.Add(new OrderModel
                {
                    UserId = order.UserId,
                    ItemCount = order.ItemCount,
                    ProductId = order.ProductId,

                });
                db.SaveChanges();
            }


            ViewData["Success"] = $"Successfull! Your Order is created. ";

            return View();
        }
    }
}