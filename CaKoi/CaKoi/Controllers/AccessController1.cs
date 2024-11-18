using Microsoft.AspNetCore.Mvc;
using CaKoi.Controllers;

namespace CaKoi.Controllers
{
    public class AccessController1 : Controller

    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContent.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Indext", "Home");
            }
        }
        [HttpGet]
        public IActionResult Login(TUser user) 
        {
            if (HttpContext.Session.GetString("UserName") == Null)
            {
                var u = db.TUser.Where(X => X.Username.Equals(user.Username) && x.Password.Equals(user.Password)).FirsttOrDefault();
                if(u! = null)
                {
                    HttpContext.Session.SetString("UserName", u.UserName.ToString());
                    return RedirectToAction("Indext", "Home");
                }
            }
            return View();
        }
    }
}
