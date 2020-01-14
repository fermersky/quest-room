using laba.DAL;
using laba.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace laba.Repositories
{
    public class CustomRespository<T> : IRepository<T> where T : class, IEntity
    {

        protected DbSet<T> localList;
        protected QRContext context;

        public int Count => this.localList.Count();

        // ctors

        public CustomRespository() 
        {
            this.context = new QRContext();
        }

        // methods

        public virtual T Add(T item)
        {
            this.localList.Add(item);
            this.context.SaveChanges();
            return item;
        }

        public virtual List<T> GetAll()
        {
            return this.localList.ToList<T>();
        }

        public virtual T GetById(int id)
        {
            return this.localList.FirstOrDefault(q => q.ID == id);
        }

        public virtual T Update(T item)
        {
            var toUpdate = this.localList.FirstOrDefault(q => q.ID == item.ID);
            context.Entry(toUpdate).CurrentValues.SetValues(item);

            this.context.SaveChanges();

            return item;
        }

        public virtual T Delete(int id)
        {
            var room = this.localList.FirstOrDefault(q => q.ID == id);
            this.localList.Remove(room);
            this.context.SaveChanges();


            return room;
        }
    }
}