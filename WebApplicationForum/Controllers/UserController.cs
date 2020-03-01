using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationForum.Controllers
{
    public class UserController : Controller
    {
        private Models.Forum forum = new Models.Forum();
        // GET: User
        public ActionResult Index()
        {
            ViewBag.users = forum.users;
            return View();
        }

        public String Add(Models.User user)
        {
            user.RegisterDate = DateTime.Now;
            user.LastLogin = DateTime.Now;
            string passHash = Utils.Utils.GetSHA_256(user.PassHash.ToString());
            user.PassHash = passHash;
            forum.users.Add(user);
            forum.SaveChanges();
            return "<b>Added</b><hr /><a href='/User'>Back</a>";
        }
    }
}