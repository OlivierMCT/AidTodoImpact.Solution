using AidTodoImpact.PersistenceContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidTodoImpact.PersistenceImplementation {
    public abstract class BaseRepositoryImplementation<T> : IBaseRepository<T> where T : BaseEntity {
        public AidTodoImpactDbContext Context { get; init; }

        public BaseRepositoryImplementation(AidTodoImpactDbContext context) {
            Context = context;
        }

        public virtual IEnumerable<T> SelectAll() {
            return Context.Set<T>().ToList();
        }

        public virtual IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> expression) {
            return Context.Set<T>().Where(expression);
        }

        public virtual T? SelectById(int id) {
            return Context.Set<T>().Find(id);
        }

        public virtual bool Exists(int id) {
            return Context.Set<T>().Any(e => e.Id == id);
        }

        public virtual void Add(T entity) {
            Context.Set<T>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities) {
            Context.Set<T>().AddRange(entities);
        }

        public virtual void Remove(T entity) {
            Context.Set<T>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities) {
            Context.Set<T>().RemoveRange(entities);
        }
    }
}
