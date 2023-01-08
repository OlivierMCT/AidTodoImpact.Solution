using AidImpact.Framework.Validators;
using AidTodoImpact.Core;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace AidTodoImpact.ServiceContracts {
    public class CategoryCreateModel {
        [Required(AllowEmptyStrings = false)]
        public string? Label { get; set; }
        [Required]
        public Color? Color { get; set; }
    }
}