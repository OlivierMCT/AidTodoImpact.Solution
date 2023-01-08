using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace AidTodoImpact.ServiceContracts {
    public class CategoryUpdateModel {
        [Required]
        public int? Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string? Label { get; set; }
        [Required]
        public Color? Color { get; set; }
    }
}