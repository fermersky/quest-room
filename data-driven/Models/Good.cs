using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace data_driven.Models
{
    public class Good
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

        public List<UserComment> Comments { get; set; }
    }
}