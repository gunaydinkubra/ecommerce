using DouMerch.Db;
using DouMerch.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DouMerch.Controllers
{
    public class HomeController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
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
                name.Value = $"{ user.Name} {user.Surname}";
                Response.Cookies.Add(name);

                HttpCookie name2 = new HttpCookie("UserType");
                name2.Value = $"{(int)user.UserType}";
                Response.Cookies.Add(name2);

                return Redirect("/Main");
                //return View("/Views/Category/CategoryView.cshtml");
            }
            else
            {
                ViewData["Warning"] = $"{data.Email} is not found.";
                return Redirect("/");
            }


        }


    }
}