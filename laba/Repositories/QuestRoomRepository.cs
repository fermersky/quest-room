﻿using Autofac;
using laba.DAL;
using laba.Models;
using laba.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace laba.Repositories
{
    public class QuestRoomRepository : CustomRespository<QuestRoom>
    {
        public QuestRoomRepository()
        {
        }

        public QuestRoomRepository(DbContext context, DbSet<QuestRoom> collection) : base(context, collection)
        {
        }

        protected override DbSet<QuestRoom> collection { get; set; }

        public override QuestRoom Delete(int id)
        {
            var room = collection.FirstOrDefault(q => q.ID == id);
            var phoneRepo = DependencyResolver.Current.GetService<IUnitOfWork>();

            for (int i = 0; i < room.PhoneNumbers.Count; i++)
            {
                phoneRepo.PhoneNumbers.Delete((room.PhoneNumbers.ToList())[i]);
            }

            phoneRepo.Save();

            return base.Delete(id);
        }
    }
}