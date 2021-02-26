using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace OrgControlServer.DAL.Abstractions
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationContext _context;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual void Add(T item)
        {
            _context.Add(item);
        }

        public void Remove(T item)
        {
            _context.Remove(item);
        }

        public void RemoveById(string id)
        {
            _context.Remove(GetById(id));
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            _context.RemoveRange(items);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public virtual T GetById(string id)
        {
            return _context.Set<T>().SingleOrDefault(entity => entity.Id == id);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }
    }
}
