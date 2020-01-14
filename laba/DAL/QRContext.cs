using laba.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace laba.DAL
{
    public class QRContext : DbContext
    {
        public QRContext() : base("QRContext") 
        {
        
        }
        public DbSet<QuestRoom> QuestRooms { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new QRInitializer());
        }
    }
}