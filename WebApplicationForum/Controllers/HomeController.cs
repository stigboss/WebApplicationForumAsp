using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationForum.Controllers
{
    public class HomeController : Controller
    {
        public Models.Forum forum = new Models.Forum();
        public ActionResult Index()
        {

            if (Convert.ToDateTime(Session["userDtLife"]).AddHours(2) >= DateTime.Now)
            {
                Session["userId"] = null;
                ViewBag.User = null;
                Response.Redirect("/");
            }

            if (Request.Params["logout"] != null)
            {
                Session["userId"] = null;
                ViewBag.User = null;
                Response.Redirect("/");
            }

            int? userCnt = forum.users.Count();
            if (userCnt==0)
            {
                forum.users.Add(new Models.User()
                {
                    RealName = "Архимаг Петрович",
                    Nickname = "Fire_Petrovi4",
                    PassHash = Utils.Utils.GetSHA_256("passmag"),
                    RegisterDate = DateTime.Now,
                    LastLogin = DateTime.Now

                });

                forum.users.Add(new Models.User()
                {
                    RealName = "Варвар Михалыч",
                    Nickname = "Blood_Michali4",
                    PassHash = Utils.Utils.GetSHA_256("passwar"),
                    RegisterDate = DateTime.Now,
                    LastLogin = DateTime.Now

                });

                forum.users.Add(new Models.User()
                {
                    RealName = "Паладин Алексеич",
                    Nickname = "Light_Aleksei4",
                    PassHash = Utils.Utils.GetSHA_256("passpal"),
                    RegisterDate = DateTime.Now,
                    LastLogin = DateTime.Now

                });
                forum.SaveChanges();
            }

            int ThemesCnt = forum.themes.Count();
            if(ThemesCnt == 0)
            {
                forum.themes.Add(new Models.Theme()
                {
                    Title = "Билды",
                    Description = "Описание билдов",
                    IdAuthor = 4,
                    DtCreated = DateTime.Now
                });

                forum.themes.Add(new Models.Theme()
                {
                    Title = "Беседка",
                    Description = "Общение",
                    IdAuthor = 5,
                    DtCreated = DateTime.Now
                });

                forum.themes.Add(new Models.Theme()
                {
                    Title = "Гайды",
                    Description = "Различные гайды",
                    IdAuthor = 6,
                    DtCreated = DateTime.Now
                });
                forum.SaveChanges();
            }

            int PostsCnt = forum.posts.Count();
            if (PostsCnt == 0)
            {
                forum.posts.Add(new Models.Post()
                {
                    IdTheme = 1,
                    IdUser = 4,
                    IdCite = -1,
                    Content = "Гайд на Фаер Мага",
                    Moment = DateTime.Now
                });

                forum.posts.Add(new Models.Post()
                {
                    IdTheme = 1,
                    IdUser = 5,
                    IdCite = -1,
                    Content = "Гайд на Блад Вара",
                    Moment = DateTime.Now
                });

                forum.posts.Add(new Models.Post()
                {
                    IdTheme = 1,
                    IdUser = 6,
                    IdCite = -1,
                    Content = "Гайд на Холи Пала",
                    Moment = DateTime.Now
                });
                forum.posts.Add(new Models.Post()
                {
                    IdTheme = 2,
                    IdUser = 4,
                    IdCite = -1,
                    Content = "Энтити - фигня",
                    Moment = DateTime.Now
                });

                forum.posts.Add(new Models.Post()
                {
                    IdTheme = 2,
                    IdUser = 5,
                    IdCite = 4,
                    Content = "Согласен",
                    Moment = DateTime.Now
                });

                forum.posts.Add(new Models.Post()
                {
                    IdTheme = 2,
                    IdUser = 6,
                    IdCite = 5,
                    Content = "+",
                    Moment = DateTime.Now
                });
                forum.posts.Add(new Models.Post()
                {
                    IdTheme = 3,
                    IdUser = 4,
                    IdCite = -1,
                    Content = "Пить воду надо вечером",
                    Moment = DateTime.Now
                });

                forum.posts.Add(new Models.Post()
                {
                    IdTheme = 3,
                    IdUser = 5,
                    IdCite = 4,
                    Content = "Точнее перед сном",
                    Moment = DateTime.Now
                });

                forum.posts.Add(new Models.Post()
                {
                    IdTheme = 3,
                    IdUser = 6,
                    IdCite = 4,
                    Content = "Вообще всегда надо",
                    Moment = DateTime.Now
                });
                forum.SaveChanges();
            }
            ViewBag.Users = forum.users;
            ViewBag.Themes = forum.themes;
            ViewBag.Posts = forum.posts;
            // var selectedPosts = from t in forum.themes join p in forum.posts
            ViewBag.query =
                 from u in forum.users
                 join p in forum.posts on u.Id equals p.IdUser
                 select new Models.ViewPostModel{ Name = u.Nickname, Text = p.Content, Moment = p.Moment };
            //List<string> post = {}
            //foreach(var res in ViewBag.query)
            //{
            //    a = res.name.GetType();
            //}
            if (Session["userId"]!=null)
            {
                ViewBag.user = Models.UserService.GetUserByID(Convert.ToInt32(Session["userId"]));
            }
            else
            {
                string log = Request.Params["user_log"];
                string pass = Request.Params["user_pass"];
                if (log != null && pass != null)
                {
                    Models.User user = Models.UserService.GetUserByLogPas(log, pass);
                    if (user != null)
                    {
                        ViewBag.User = user;
                        Session["userId"] = user.Id;
                        Session["userDtLife"] = DateTime.Now;

                    }
                }
            }
           
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}