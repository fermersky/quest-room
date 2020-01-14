using laba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace laba.Repositories
{
    public class QuestRoomRepository : CustomRespository<QuestRoom>
    {
        public QuestRoomRepository()
        {
            this.localList = this.context.QuestRooms;
        }
    }
}