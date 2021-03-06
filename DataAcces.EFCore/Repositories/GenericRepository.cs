using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Interfaces;

namespace DataAcces.EFCore
    {
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        public void RemoveById(int id)
        {
            T toRemove = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(toRemove);
        }
        public List<T> RowsById(List<int> Ids)
        {
            List<T> tempList = new List<T>();
            foreach (var id in Ids)
            {
                T temp = _context.Set<T>().Find(id);

                if (temp != null)
                    tempList.Add(temp);
            }

            return tempList;
        }
    }
}
