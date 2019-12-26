using laba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace laba.Repositories
{
    public class CustomRespository<T> : IRepository<T> where T : IEntity
    {

        private List<T> localList;
        public int Count => localList.Count;

        // ctors

        public CustomRespository() => this.localList = new List<T>();
        public CustomRespository(List<T> list) => this.localList = list;

        // methods

        public T Add(T item)
        {
            item.Id = localList.Count + 1;
            this.localList.Add(item);
            return item;
        }

        public List<T> GetAll()
        {
            return this.localList.ToList<T>();
        }

        public T GetById(int id)
        {
            return this.localList.FirstOrDefault(q => q.Id == id);
        }
    }
}