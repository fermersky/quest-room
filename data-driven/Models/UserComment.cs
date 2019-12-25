using System;

namespace data_driven.Models
{
    public class UserComment
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string CommentTitle { get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; }
    }
}