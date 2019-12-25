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

            // интерфейс IEntity помог избежать ненужной рефлексии. Видел схожую реализацию, там где все сущности
            // унаследованы от одного интерфейса, на реальном коммерческом проекте

            // также добавил ограничения для интерфейса IRepository и репозитория

            //T result = default;
            //try
            //{
            //    foreach (T item in this.localList)
            //    {
            //        var value = item.GetType().GetProperty("Id").GetValue(item);

            //        if (value != null && (int)value == id)
            //            result = item;
            //    }
            //    return result;
            //}
            //catch (Exception)
            //{
            //    return result;
            //}
        }
    }
}