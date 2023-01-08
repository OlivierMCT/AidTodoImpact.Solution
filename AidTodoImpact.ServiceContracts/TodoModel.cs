using AidTodoImpact.Core;

namespace AidTodoImpact.ServiceContracts {
    public class TodoModel {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
        public bool IsDone { get; init; }
        public DateTime DueDate { get; init; }
        public TodoPriority Priority { get; init; }
        public IEnumerable<CategoryModel>? Categories { get; init; }
        public TodoStatus Status { get; init; }
        public bool IsDeletable { get; init; }
        public TodoCoordinate? Coordinate { get; init; }
    }
}