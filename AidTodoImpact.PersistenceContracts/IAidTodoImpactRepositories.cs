using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidTodoImpact.PersistenceContracts {
    public interface IAidTodoImpactRepositories : IDisposable {
        ITodoRepository Todos { get; }
        ICategoryRepository Categories { get; }
        int SaveChanges();
    }
}
