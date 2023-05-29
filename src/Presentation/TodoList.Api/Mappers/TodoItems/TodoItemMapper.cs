using TodoList.Api.Dtos.TodoItems;
using TodoList.Domain.Entities;

namespace TodoList.Api.Mappers.TodoItems
{
    public static class TodoItemMapper
    {
        public static TodoItemDto ToTodoItemDto(this TodoItem todoItem)
        {
            var todoItemDto = new TodoItemDto
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                DueDate = todoItem.DueDate,
                IsCompleted = todoItem.IsCompleted,
            };

            return todoItemDto;
        }

        public static TodoItem ToTodoItem(this CreateTodoItemDto createTodoItemDto)
        {
            var todoItem = new TodoItem
            {
                Title = createTodoItemDto.Title,
                Description = createTodoItemDto.Description,
                DueDate = createTodoItemDto.DueDate,
                IsCompleted = false
            };

            return todoItem;
        }
    }
}
