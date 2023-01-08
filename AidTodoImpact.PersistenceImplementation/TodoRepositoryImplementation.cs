using AidTodoImpact.PersistenceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidTodoImpact.PersistenceImplementation {
    public class TodoRepositoryImplementation : BaseRepositoryImplementation<TodoEntity>, ITodoRepository {

        public TodoRepositoryImplementation(AidTodoImpactDbContext context) : base(context) {}

    }
}
