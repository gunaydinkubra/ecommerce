using DouMerch.Db;
using DouMerch.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DouMerch.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            FormsAuthentication.SignOut();
            return View();

        }
        [HttpPost]
        public ActionResult Login(LoginModel data)
        {
            var db = new Context();
            var user = db.Users.Where(w => w.Email == data.Email).FirstOrDefault();
            if (user != null && user.Password == data.Password)
            {
                FormsAuthentication.SetAuthCookie(data.Email, true);
                HttpCookie name = new HttpCookie("NameCookie");
                name.Value = Server.UrlEncode($"{ user.Name} {user.Surname}");
                Response.Cookies.Add(name);

                return Redirect("/Category/Category");
                //return View("/Views/Category/CategoryView.cshtml");
            }
            else
            {
                ViewData["Warning"] = $"{data.Email} is not found.";
                return View();
            }


        }


    }
}