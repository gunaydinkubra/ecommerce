
using DouMerch.Db;
using DouMerch.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DouMerch.Controllers
{
    public class UserController : Controller
    {
        public ActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewUser(UsersModel data)
        {
            if (!string.IsNullOrEmpty(data.Name))
            {
                if (!string.IsNullOrEmpty(data.Surname))
                {
                    if (!string.IsNullOrEmpty(data.Email))
                    {
                        if (!string.IsNullOrEmpty(data.Password))
                        {
                            var db = new Context();
                            var userModel = db.Users.Where(w => w.Email == data.Email).FirstOrDefault();
                            if (userModel != null)
                            {
                                ViewData["Warning"] = $"{data.Email} is available in our system.";
                            }
                            else
                            {
                                data.CreatedDate = DateTime.Now;
                                data.UserType = Enums.UserTypeEnum.Users;
                                db.Users.Add(data);
                                db.SaveChanges();
                                ModelState.Clear();
                                ViewData["Success"] = $"Successfull! Your information is saved. ";

                                return Redirect("/");
                            }

                        }
                        else
                        {
                            ViewData["Warning"] = "You must enter your password";
                        }

                    }
                    else
                    {
                        ViewData["Warning"] = "You must enter your username";
                    }

                }
                else
                {
                    ViewData["Warning"] = "You must enter your surname";
                }

            }
            else
            {
                ViewData["Warning"] = "You must enter your name";
            }


            return View(data);

        }
    }
}