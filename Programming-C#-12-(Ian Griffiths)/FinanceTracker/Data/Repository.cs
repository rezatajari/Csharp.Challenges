using FinanceTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Data
{
    public class Repository<T> where T : class, IEntity
    {
        protected readonly List<T> _item = new();

        public virtual void Add(T item) => _item.Add(item);
        public List<T> GetAll() => _item.ToList();
        public T? GetById(Guid id) => _item.FirstOrDefault(x => x.Id == id);
        public bool Remove(Guid id)
        {
            var item = GetById(id);
            if (item is null) return false;

            return _item.Remove(item);
        }
        public bool Exists(Guid id) => _item.Any(x => x.Id == id);
    }
}
