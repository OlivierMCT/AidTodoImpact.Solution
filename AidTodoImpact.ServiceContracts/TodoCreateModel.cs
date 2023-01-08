using AidImpact.Framework.Validators;
using AidTodoImpact.Core;
using System.ComponentModel.DataAnnotations;

namespace AidTodoImpact.ServiceContracts {
    public class TodoCreateModel {
        [Required(AllowEmptyStrings = false)]
        public string? Title { get; set; }
        [Required] 
        public DateTime? DueDate { get; set; }
        [Required] 
        public TodoPriority? Priority { get; set; }
        [Range(-90, 90), RequiredWith(nameof(Longitude))]
        public double? Latitude { get; set; }
        [Range(-180, 180), RequiredWith(nameof(Latitude))]
        public double? Longitude { get; set; }
    }
}