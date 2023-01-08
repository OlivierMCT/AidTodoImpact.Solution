using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AidTodoImpact.PersistenceContracts {
    public interface ICategoryRepository : IBaseRepository<CategoryEntity> {
        IEnumerable<CategoryEntity> SelectPopularCategories(int count);
    }
}
