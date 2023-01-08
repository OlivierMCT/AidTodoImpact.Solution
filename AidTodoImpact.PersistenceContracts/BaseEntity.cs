using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidTodoImpact.PersistenceContracts {
    public class BaseEntity {
        public int Id { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
