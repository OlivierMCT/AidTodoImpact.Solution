using AidTodoImpact.PersistenceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AidTodoImpact.PersistenceContracts {
    public interface IBaseRepository<T> where T : BaseEntity {
        public IEnumerable<T> SelectAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        T? SelectById(int id);
        bool Exists(int id);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
