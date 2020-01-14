using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace laba.Models
{
    public class PhoneNumber : IEntity
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public int QuestRoomId { get; set; }

        public virtual QuestRoom QuestRoom { get; set; }
    }
}