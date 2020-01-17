using laba.Models;
using laba.Repositories;
using laba.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using laba.Utils;

namespace laba.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUnitOfWork db;
        public AdminController(IUnitOfWork db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var rooms = db.QuestRooms.GetAll();
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
            if (ModelState.IsValid && viewModel.File.ContentLength > 0)
            {
                string fileName = Path.GetFileName(viewModel.File.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                viewModel.File.SaveAs(path);
                viewModel.Room.LogoPath = fileName;

                var numbersList = viewModel.Room.PhoneNumbers.ToList();

                numbersList.ForEach(number => db.PhoneNumbers.Add(number));

                db.QuestRooms.Add(viewModel.Room);
                db.Save();

                return RedirectToRoute(new { controller = "home", action = "details", id = viewModel.Room.ID });
            }

            return View(viewModel.Room);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var room = db.QuestRooms.GetById(id);

            if (room == null)
                return HttpNotFound();

            var vm = new AddRoomViewModel() { Room = room };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(AddRoomViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //var phoneNumbers = viewModel.PhoneNumbers.Select(phone => new PhoneNumber() { Number = phone.Number, QuestRoomId = viewModel.Room.ID }).ToList();

                //phoneNumbers.ForEach(number => db.PhoneNumbers.Delete(number));
                //phoneNumbers.ForEach(number => db.PhoneNumbers.Add(number));

                var numbersList = viewModel.Room.PhoneNumbers.ToList();
                var questRoomId = viewModel.Room.ID;

                numbersList.ForEach(number => number.QuestRoomId = questRoomId);
                numbersList.ForEach(number => db.PhoneNumbers.Update(number));

                db.QuestRooms.Update(viewModel.Room);
                db.Save();

                return View("index", db.QuestRooms.GetAll());
            }
            return View(viewModel);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var fileName = db.QuestRooms.GetById(id).LogoPath;
            string fullPath = Request.MapPath("~/Content/Images/" + fileName);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            db.QuestRooms.Delete(id);
            db.Save();
        }
    }
}