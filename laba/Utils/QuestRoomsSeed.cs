using laba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace laba.Utils
{
    public class QuestRoomsSeed
    {
        public static List<QuestRoom> GetSeed()
        {
            var result = new List<QuestRoom>();

            result.Add(new QuestRoom()
            {
                Id = 1,
                Title = "Room of Fear",
                Description = "Very very very screaming room ever",
                DurationTime = "2",
                MinPlayersCount = 2,
                MaxPlayersCount = 6,
                PhoneNumbers = new List<string>() { "0935657387", "0682239845" },
                FearLevel = 2,
                Difficulty = 5,
                LogoPath = "qr1.jpg",
            });

            result.Add(new QuestRoom()
            {
                Id = 2,
                Title = "Fear of goddess",
                Description = "No more sorrow, you saved me",
                DurationTime = "3",
                MinPlayersCount = 6,
                MaxPlayersCount = 12,
                PhoneNumbers = new List<string>() { "0935657387", "0682239845" },
                FearLevel = 4,
                Difficulty = 7,
                LogoPath = "qr2.jpg",
            });

            return result;
        }
    }
}