using System;
using System.Collections.Generic;
using System.Linq;
using BILLSToPAY.Domain.Interfaces.Repositories;
using BILLSToPAY.Domain.Shared.Models;
using BILLSToPAY.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BILLSToPAY.Infra.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : Entity
    {
        protected readonly BillToPayContext Context;
        protected readonly DbSet<T> DbSet;

        public RepositoryBase(BillToPayContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public void Add(T obj)
        {
            if (obj.Id.Equals(Guid.Empty))
            {
                obj.WithId();
            }
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        protected IQueryable<T> GetAll()
        {
            return DbSet.AsQueryable();
        }


        public abstract (int totalItems, IList<T> entities) Get(Filter filter);

        public T GetById(Guid id)
        {
            var query = DbSet.AsQueryable();
            var type = typeof(T);
            foreach (var property in type.GetProperties())
            {
                if (property.PropertyType.BaseType == typeof(Entity))
                {
                    query = query.Include(property.Name);
                }
            }
            return query.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(Guid id)
        {
            var item = DbSet.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                DbSet.Remove(item);
            }
        }

        public void Update(T obj)
        {
            DbSet.Update(obj);
        }
    }
}
