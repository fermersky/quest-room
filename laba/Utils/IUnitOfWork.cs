using laba.DAL;
using laba.Models;
using laba.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba.Utils
{
    public interface IUnitOfWork
    {
        QRContext context { get; }
        IRepository<QuestRoom> QuestRooms { get; }
        IRepository<PhoneNumber> PhoneNumbers { get; }
        void Save();
    }
}
