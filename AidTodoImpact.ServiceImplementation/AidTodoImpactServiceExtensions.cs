using AidTodoImpact.Core;
using AidTodoImpact.PersistenceContracts;
using AidTodoImpact.ServiceContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidTodoImpact.ServiceImplementation {
    public static class AidTodoImpactServiceExtensions {
        public static TodoModel ToModel(this TodoEntity entity, IEnumerable<CategoryModel>? categories = null) {
            return new TodoModel() {
                Categories = categories,
                Coordinate = entity.ToCoordinate(),
                DueDate = entity.DueDate,
                Id = entity.Id,
                IsDeletable = entity.ToDeletable(),
                IsDone = entity.IsDone,
                Priority = entity.ToPriority(),
                Status = entity.ToStatus(),
                Title = entity.Title
            };
        }

        public static TodoEntity ToEntity(this TodoCreateModel model) {
            return new TodoEntity() {
                DueDate = model.DueDate!.Value,
                IsDone = false,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Priority = (short)model.Priority!,
                Title = model.Title!
            };
        }

        public static TodoEntity ToEntity(this TodoUpdateModel model) {
            return new TodoEntity() {
                DueDate = model.DueDate!.Value,
                Id = model.Id!.Value,
                IsDone = model.IsDone!.Value,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Priority = (short)model.Priority!,
                Title = model.Title!
            };
        }

        public static TodoStatus ToStatus(this TodoEntity entity) {
            TodoStatus status = TodoStatus.Closed;
            if (entity.IsDone)
                status = entity.DueDate <= DateTime.Today ? TodoStatus.Late : TodoStatus.OnGoing;
            return status;
        }

        public static TodoPriority ToPriority(this TodoEntity entity) {
            return (TodoPriority)entity.Priority;
        }

        public static bool ToDeletable(this TodoEntity entity) {
            return entity.IsDone && entity.DueDate <= DateTime.Today;
        }

        public static TodoCoordinate? ToCoordinate(this TodoEntity entity) {
            TodoCoordinate? coords = null;
            if (entity.Latitude.HasValue && entity.Longitude.HasValue)
                coords = new() {
                    Latitude = entity.Latitude.Value,
                    Longitude = entity.Longitude.Value
                };
            return coords;
        }

        public static CategoryModel ToModel(this CategoryEntity entity, IEnumerable<TodoModel>? todos = null) {
            return new CategoryModel() {
                Color = entity.ToColor(),
                Id = entity.Id,
                Label = entity.Label,
                Todos = todos
            };
        }

        public static Color ToColor(this CategoryEntity entity) {
            return ColorTranslator.FromHtml(entity.Color);
        }

        public static bool Validate<T>(this T model) where T : class {
            return Validator.TryValidateObject(model, new ValidationContext(model), null, true);
        }

        public static CategoryEntity ToEntity(this CategoryCreateModel model) {
            return new CategoryEntity() {
                Color = ColorTranslator.ToHtml(model.Color!.Value),
                Label = model.Label!
            };
        }

        public static CategoryEntity ToEntity(this CategoryUpdateModel model) {
            return new CategoryEntity() {
                Color = ColorTranslator.ToHtml(model.Color!.Value),
                Label = model.Label!,
                Id = model.Id!.Value
            };
        }
    }
}
