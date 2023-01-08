using AidTodoImpact.PersistenceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidTodoImpact.PersistenceImplementation {
    public class AidTodoImpactRepositoriesImplementation : IAidTodoImpactRepositories {
        public AidTodoImpactDbContext Context { get; init; }
        public ITodoRepository Todos { get; init; }
        public ICategoryRepository Categories { get; init; }

        public AidTodoImpactRepositoriesImplementation(AidTodoImpactDbContext context) {
            Todos = new TodoRepositoryImplementation(context);
            Categories = new CategoryRepositoryImplementation(context);
            Context = context;
        }

        public int SaveChanges() {
            return Context.SaveChanges();
        }

        public void Dispose() {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
