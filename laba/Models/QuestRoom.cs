using laba.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace laba.Models
{
    public partial class QuestRoom : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string DurationTime { get; set; }

        public int MinPlayersCount { get; set; }
        public int MaxPlayersCount { get; set; }

        public List<string> PhoneNumbers { get; set; }
        public int FearLevel { get; set; }
        public int Difficulty { get; set; }

        public string LogoPath { get; set; }
    }
}