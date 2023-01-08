using System.Drawing;

namespace AidTodoImpact.ServiceContracts {
    public class CategoryModel {
        public int Id { get; init; }
        public string Label { get; init; } = null!;
        public Color Color { get; init; }
        public IEnumerable<TodoModel>? Todos { get; init; }
    }
}