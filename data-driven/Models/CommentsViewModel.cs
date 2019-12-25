using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace data_driven.Models
{
    public class CommentsViewModel
    {
        public Good Good { get; set; }
        public List<UserComment> Comments { get; set; }
    }
}