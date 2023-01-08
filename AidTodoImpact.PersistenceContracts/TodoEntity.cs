using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidTodoImpact.PersistenceContracts {
    public class TodoEntity : BaseEntity {
        public string Title { get; set; } = null!;
        public bool IsDone { get; set; }
        public DateTime DueDate { get; set; }
        public short Priority { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public virtual ICollection<CategoryEntity> Categories { get; set; } = new HashSet<CategoryEntity>();
    }
}
