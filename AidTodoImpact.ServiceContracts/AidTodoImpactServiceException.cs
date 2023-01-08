using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AidTodoImpact.ServiceContracts {
    public class AidTodoImpactServiceException : Exception {
        public AidTodoImpactServiceException() {
        }

        public AidTodoImpactServiceException(string? message) : base(message) {
        }

        public AidTodoImpactServiceException(string? message, Exception? innerException) : base(message, innerException) {
        }

        protected AidTodoImpactServiceException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}
