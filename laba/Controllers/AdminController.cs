using laba.Models;
using laba.Repositories;
using laba.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace laba.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository<QuestRoom> repository;
        public AdminController(IRepository<QuestRoom> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
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
        public ActionResult Add(AddRoomViewModel viewModel)
        {
            if (viewModel.File.ContentLength > 0)
            {
                string fileName = Path.GetFileName(viewModel.File.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                viewModel.File.SaveAs(path);

                viewModel.Room.LogoPath = fileName;
                repository.Add(viewModel.Room);
                return RedirectToRoute(new { controller = "home", action = "details", id = viewModel.Room.Id });
            }

            return View();
        }
    }
}