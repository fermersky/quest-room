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

        public ActionResult Index(int minFearLevel = 1, int minDifficulty = 1)
        {
            var model = db.QuestRooms
                .GetAll()
                .Where(q => q.FearLevel >= minFearLevel && q.Difficulty >= minDifficulty)
                .ToList();

            ViewBag.MinFearLevel = minFearLevel;
            ViewBag.MinDifficulty = minDifficulty;

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