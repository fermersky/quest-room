using data_driven.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace data_driven.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private Good GetGood()
        {
            return new Good() { Id = 1, Title = "IPad mini 2", Category = "Phones", Price = 2000 };
        }

        private List<UserComment> GetComments()
        {
            var comments = new List<UserComment>()
            {
                new UserComment() {UserId = 1, UserName = "Федя", CommentTitle = "Фу!", Rate = 2, 
                    Comment = "Отвратительно ужас кашмар", Date = DateTime.Now},

                new UserComment() {UserId = 2, UserName = "Настюшка48 :3", CommentTitle = "найс", Rate = 4, 
                    Comment = "Спасибо мужу за подрак очень нравитьбся", Date = DateTime.Now},

                new UserComment() {UserId = 3, UserName = "Валера Батон", CommentTitle = "Класснгая подсатвка", Rate = 5, 
                    Comment = "Замечательно", Date = DateTime.Now},
            };

            return comments;
        }

        public ActionResult GetUserComments()
        {
            var viewModel = new CommentsViewModel()
            {
                Good = this.GetGood(),
                Comments = this.GetComments()
            };
            
            return View(viewModel);
        }

        public ActionResult GetUserComments2()
        {
            var tuple = new Tuple<Good, List<UserComment>>(GetGood(), GetComments());

            return View(tuple);
        }

        public ActionResult GetUserComments3()
        {
            dynamic obj = new ExpandoObject();
            obj.Good = GetGood();
            obj.Comments = GetComments();

            return View(obj);
        }

        [ChildActionOnly]
        public PartialViewResult GetGoodView()
        {
            return PartialView(this.GetGood());
        }

        [ChildActionOnly]
        public PartialViewResult GetCommentsView()
        {
            return PartialView(this.GetComments());
        }

        public ActionResult GetUserComments4()
        {
            return View();
        }

        public ActionResult GetUserComments5()
        {
            var good = new Good() { Id = 1, Title = "IPad mini 3", Category = "Phones", Price = 2000, Comments = this.GetComments() };
            return View(good);
        }

        public ActionResult GetUserComments6()
        {
            Session["Good"] = GetGood();
            Session["Comments"] = GetComments();
            return View();
        }
    }
}