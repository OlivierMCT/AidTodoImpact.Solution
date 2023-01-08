using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidTodoImpact.ServiceContracts {
    public interface IAidTodoImpactService {
        public Task<IEnumerable<TodoModel>> GetTodosAsync(string? keyword);
        public Task<TodoModel> GetTodoAsync(int id, bool includeCategories = false);
        public Task<TodoModel> CreateTodoAsync(TodoCreateModel todoInfo);
        public Task<TodoModel> UpdateTodoAsync(TodoUpdateModel todoInfo);
        public Task<TodoModel> ToggleTodoAsync(int id);
        public Task RemoveTodoAsync(int id);
        public Task<bool> TodoExistsAsync(int id);

        public Task<IEnumerable<CategoryModel>> GetCategoriesAsync();
        public Task<IEnumerable<CategoryModel>> GetPopularCategoriesAsync(int count);
        public Task<CategoryModel> GetCategoryAsync(int id, bool includeTodos = false);
        public Task<CategoryModel> CreateCategoryAsync(CategoryCreateModel categoryInfo);
        public Task<CategoryModel> UpdateCategoryAsync(CategoryUpdateModel categoryInfo);
        public Task RemoveCategoryAsync(int id);
        public Task<bool> CategoryExistsAsync(int id);

        public Task AddCategoryToTodoAsync(int todoId, int categoryId);
        public Task RemoveCategoryFromTodoAsync(int todoId, int categoryId);
    }
}
