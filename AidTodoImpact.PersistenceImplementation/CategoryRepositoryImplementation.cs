using AidTodoImpact.PersistenceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AidTodoImpact.PersistenceImplementation {
    public class CategoryRepositoryImplementation : BaseRepositoryImplementation<CategoryEntity>, ICategoryRepository {
        
        public CategoryRepositoryImplementation(AidTodoImpactDbContext context) : base(context) {}

        public IEnumerable<CategoryEntity> SelectPopularCategories(int count) {
            return Context.Categories.OrderByDescending(c => c.Todos.Count).Take(count);
        }
    }
}
