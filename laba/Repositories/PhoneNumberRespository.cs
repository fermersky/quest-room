using laba.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace laba.Repositories
{
    public class PhoneNumberRespository : CustomRespository<PhoneNumber>
    {
        public PhoneNumberRespository(){}

        public PhoneNumberRespository(DbContext context, DbSet<PhoneNumber> collection) : base(context, collection){}

        protected override DbSet<PhoneNumber> collection { get; set; }
    }
}