using laba.Models;
using laba.Repositories;
using laba.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace laba.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork db;
        public HomeController(IUnitOfWork db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            var model = db.QuestRooms.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var room = db.QuestRooms.GetById(id);
            if (room != null)
                return View(room);
            else
                return new HttpNotFoundResult("Quest room doesn't exist");
        }
    }
}