using laba.DAL;
using laba.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace laba.Repositories
{
    public abstract class CustomRespository<T> : IRepository<T> where T : class, IEntity
    {

        protected abstract DbSet<T> collection { get; set; }
        protected DbContext context;

        // ctors

        public CustomRespository(){}

        public CustomRespository(DbContext context, DbSet<T> collection) 
        {
            this.context = context;
            this.collection = collection;
        }

        // methods

        public virtual T Add(T item)
        {
            collection.Add(item);
            return item;
        }

        public virtual List<T> GetAll()
        {
            return collection.ToList<T>();
        }

        public virtual T GetById(int id)
        {
            return collection.FirstOrDefault(q => q.ID == id);
        }

        public virtual T Update(T item)
        {
            context.Set<T>().AddOrUpdate(item);

            return item;
        }

        public virtual T Delete(int id)
        {
            var room = collection.FirstOrDefault(q => q.ID == id);
            if (room != null)
                Delete(room);
            return room;
        }

        public T Delete(T item)
        {
            collection.Remove(item);

            return item;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}