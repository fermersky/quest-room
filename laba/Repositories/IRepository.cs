﻿using laba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T item);
        T Update(T item);
        T Delete(int id);
        T Delete(T item);
        void Save();
    }
}
