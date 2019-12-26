using laba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace laba.ViewModels
{
    public class AddRoomViewModel
    {
        public HttpPostedFileBase File { get; set; }
        public QuestRoom Room { get; set; }
    }
}