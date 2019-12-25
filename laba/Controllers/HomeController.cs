using laba.Models;
using laba.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace laba.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<QuestRoom> repository;
        public HomeController(IRepository<QuestRoom> repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var room = this.repository.GetById(id);
            if (room != null)
                return View(room);
            else
                return new HttpNotFoundResult("Quest room doesn't exist");
        }
    }
}