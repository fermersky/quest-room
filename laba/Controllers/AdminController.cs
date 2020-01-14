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
        public ActionResult Add(AddRoomViewModel viewModel, List<string> phoneNumber)
        {
            if (ModelState.IsValid && viewModel.File.ContentLength > 0)
            {
                string fileName = Path.GetFileName(viewModel.File.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                viewModel.File.SaveAs(path);

                var phoneNumbers = phoneNumber.Select(number => new PhoneNumber() { Number = number, QuestRoomId = viewModel.Room.ID }).ToList();

                viewModel.Room.PhoneNumbers = phoneNumbers;


                viewModel.Room.LogoPath = fileName;
                repository.Add(viewModel.Room);
                return RedirectToRoute(new { controller = "home", action = "details", id = viewModel.Room.ID });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var room = repository.GetById(id);
            var vm = new AddRoomViewModel() { Room = room };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(AddRoomViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                repository.Update(viewModel.Room);
                return View("index", repository.GetAll());
            }
            return View(viewModel);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var fileName = repository.GetById(id).LogoPath;
            string fullPath = Request.MapPath("~/Content/Images/" + fileName);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            repository.Delete(id);
        }
    }
}