using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidTodoImpact.PersistenceContracts {
    public class CategoryEntity : BaseEntity {
        public string Label { get; set; } = null!;
        public string Color { get; set; } = null!;
        public virtual ICollection<TodoEntity> Todos { get; set; } = new HashSet<TodoEntity>();
    }
}
