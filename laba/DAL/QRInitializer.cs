using laba.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace laba.DAL
{
    public class QRInitializer : DropCreateDatabaseAlways<QRContext>
    {
        protected override void Seed(QRContext context)
        {
            context.QuestRooms.Add(new QuestRoom()
            {
                ID = 1,
                Title = "Room of Fear",
                Description = "Very very very screaming room ever",
                DurationTime = "2",
                MinPlayersCount = 2,
                MaxPlayersCount = 6,
                PhoneNumbers = new List<PhoneNumber>() { new PhoneNumber() { Number = "0935657387" }, new PhoneNumber() { Number = "0682239845" } },
                FearLevel = 2,
                Difficulty = 5,
                LogoPath = "qr1.jpg",
            });

            context.QuestRooms.Add(new QuestRoom()
            {
                ID = 2,
                Title = "Fear of Goddess",
                Description = "No more sorrow, You've saved me",
                DurationTime = "3",
                MinPlayersCount = 6,
                MaxPlayersCount = 12,
                PhoneNumbers = new List<PhoneNumber>() { new PhoneNumber() { Number = "0935657389" }, new PhoneNumber() { Number = "0635571254" } },
                FearLevel = 7,
                Difficulty = 9,
                LogoPath = "qr2.jpg",
            });

            context.SaveChanges();
        }
    }
}