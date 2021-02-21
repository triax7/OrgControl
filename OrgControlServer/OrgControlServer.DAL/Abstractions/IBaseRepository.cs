using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OrgControlServer.DAL.Abstractions
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Add(T item);
        void Delete(T item);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetById(string id);
    }
}
