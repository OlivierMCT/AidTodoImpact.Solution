using AidTodoImpact.PersistenceContracts;
using AidTodoImpact.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidTodoImpact.ServiceImplementation {
    public class AidTodoImpactServiceImplementation : IAidTodoImpactService {
        public IAidTodoImpactRepositories Repository { get; init; }
        public AidTodoImpactServiceImplementation(IAidTodoImpactRepositories repository) {
            Repository = repository;
        }

        public Task<IEnumerable<TodoModel>> GetTodosAsync(string? keyword) {
            return Task.Run(() => {
                IEnumerable<TodoEntity> entities;
                if (string.IsNullOrWhiteSpace(keyword)) {
                    entities = Repository.Todos.SelectAll();
                } else {
                    entities = Repository.Todos.Find(t => t.Title.Contains(keyword));
                }
                return entities.Select(entity => entity.ToModel());
            });
        }

        public Task<TodoModel> GetTodoAsync(int id, bool includeCategories = false) {
            return Task.Run(() => {
                TodoModel? model = null;
                TodoEntity? entity = Repository.Todos.SelectById(id);
                if (entity != null) {
                    var categories = Repository.Categories
                            .Find(c => c.Todos.Select(t => t.Id).Contains(entity.Id))
                            .Select(c => c.ToModel());
                    model = entity.ToModel(categories);
                }
                return model ?? throw new AidTodoImpactServiceException();
            });
        }

        public Task<TodoModel> CreateTodoAsync(TodoCreateModel todoInfo) {
            if (!todoInfo.Validate()) throw new AidTodoImpactServiceException();
            return SaveTodo(todoInfo.ToEntity(), true);
        }

        public Task<TodoModel> UpdateTodoAsync(TodoUpdateModel todoInfo) {
            if (!todoInfo.Validate()) throw new AidTodoImpactServiceException();
            return SaveTodo(todoInfo.ToEntity());
        }

        public Task<TodoModel> ToggleTodoAsync(int id) {
            TodoEntity entity = Repository.Todos.SelectById(id) ?? throw new AidTodoImpactServiceException();
            entity.IsDone = !entity.IsDone;
            return SaveTodo(entity);
        }

        public Task RemoveTodoAsync(int id) {
            return Task.Run(() => {
                TodoEntity entity = Repository.Todos.SelectById(id) ?? throw new AidTodoImpactServiceException();
                Repository.Todos.Remove(entity);
                Repository.SaveChanges();
            });
        }

        public Task<bool> TodoExistsAsync(int id) {
            return Task.Run(() => Repository.Todos.Exists(id));
        }

        private Task<TodoModel> SaveTodo(TodoEntity entity, bool adding = false) {
            return Task.Run(() => {
                if(adding) Repository.Todos.Add(entity);
                Repository.SaveChanges();
                return entity.ToModel();
            });
        }

        public Task<IEnumerable<CategoryModel>> GetCategoriesAsync() {
            return Task.Run(() => {
                IEnumerable<CategoryEntity> entities;
                entities = Repository.Categories.SelectAll();
                return entities.Select(entity => entity.ToModel());
            });
        }

        public Task<IEnumerable<CategoryModel>> GetPopularCategoriesAsync(int count) {
            return Task.Run(() => {
                IEnumerable<CategoryEntity> entities;
                entities = Repository.Categories.SelectPopularCategories(count);
                return entities.Select(entity => entity.ToModel());
            });
        }

        public Task<CategoryModel> GetCategoryAsync(int id, bool includeTodos = false) {
            return Task.Run(() => {
                CategoryModel? model = null;
                CategoryEntity? entity = Repository.Categories.SelectById(id);
                if (entity != null) {
                    var todos = Repository.Todos
                            .Find(t => t.Categories.Select(c => c.Id).Contains(entity.Id))
                            .Select(c => c.ToModel());
                    model = entity.ToModel(todos);
                }
                return model ?? throw new AidTodoImpactServiceException();
            });
        }

        public Task<CategoryModel> CreateCategoryAsync(CategoryCreateModel categoryInfo) {
            if (!categoryInfo.Validate()) throw new AidTodoImpactServiceException();
            return SaveCategory(categoryInfo.ToEntity(), true);
        }

        public Task<CategoryModel> UpdateCategoryAsync(CategoryUpdateModel categoryInfo) {
            if (!categoryInfo.Validate()) throw new AidTodoImpactServiceException();
            return SaveCategory(categoryInfo.ToEntity());
        }

        private Task<CategoryModel> SaveCategory(CategoryEntity entity, bool adding = false) {
            return Task.Run(() => {
                if(adding) Repository.Categories.Add(entity);
                Repository.SaveChanges();
                return entity.ToModel();
            });
        }

        public Task RemoveCategoryAsync(int id) {
            return Task.Run(() => {
                CategoryEntity entity = Repository.Categories.SelectById(id) ?? throw new AidTodoImpactServiceException();
                Repository.Categories.Remove(entity);
                Repository.SaveChanges();
            });
        }

        public Task<bool> CategoryExistsAsync(int id) {
            return Task.Run(() => Repository.Categories.Exists(id));
        }

        public Task AddCategoryToTodoAsync(int todoId, int categoryId) {
            return Task.Run(() => {
                TodoEntity todo = Repository.Todos.SelectById(todoId) ?? throw new AidTodoImpactServiceException();
                CategoryEntity category = Repository.Categories.SelectById(categoryId) ?? throw new AidTodoImpactServiceException();
                todo.Categories.Add(category);
                Repository.SaveChanges();
            });
        }

        public Task RemoveCategoryFromTodoAsync(int todoId, int categoryId) {
            return Task.Run(() => {
                TodoEntity todo = Repository.Todos.SelectById(todoId) ?? throw new AidTodoImpactServiceException();
                CategoryEntity category = Repository.Categories.SelectById(categoryId) ?? throw new AidTodoImpactServiceException();
                todo.Categories.Remove(category);
                Repository.SaveChanges();
            });
        }
    }
}
