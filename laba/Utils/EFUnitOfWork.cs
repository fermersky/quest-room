using laba.DAL;
using laba.Models;
using laba.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace laba.Utils
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private IRepository<QuestRoom> questRooms;

        public IRepository<QuestRoom> QuestRooms 
        {
            get
            {
                if (questRooms == null)
                    questRooms = new QuestRoomRepository(context, context.QuestRooms);
                return questRooms;
            }
            private set { }
        }

        private IRepository<PhoneNumber> phoneNumbers;

        public IRepository<PhoneNumber> PhoneNumbers
        {
            get
            {
                if (phoneNumbers == null)
                    phoneNumbers = new PhoneNumberRespository(context, context.PhoneNumbers);
                return phoneNumbers;
            }
            private set { }
        }

        public QRContext context { get; set; } = new QRContext();

        public void Save()
        {
            context.SaveChanges();
        }
    }
}