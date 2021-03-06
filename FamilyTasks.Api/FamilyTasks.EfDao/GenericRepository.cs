﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FamilyTasks.Dao.Repositories;

namespace FamilyTasks.EfDao
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        protected readonly EfContext Db;
        private readonly DbSet<T> _table;

        public GenericRepository(EfContext db)
        {
            Db = db;
            _table = db.Set<T>();
        }

        public IEnumerable<T> SelectAll()
        {
            return _table.ToList();
        }

        public T SelectById(object id)
        {
            return _table.Find(id);
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            Db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
        }

        public void Save()
        {
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
