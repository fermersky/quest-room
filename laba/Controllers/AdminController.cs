using laba.Models;
using laba.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace laba.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository<QuestRoom> repository;
        public AdminController(IRepository<QuestRoom> repository)
        {
            this.repository = repository;
        }
        public ActionResult Index()
        {
            var rooms = this.repository.GetAll();
            return View(rooms);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(QuestRoom room)
        {
            return View();
        }
    }
}