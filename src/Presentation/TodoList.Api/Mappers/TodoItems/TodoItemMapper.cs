using TodoList.Api.Dtos.TodoItems;
using TodoList.Domain.Entities;

namespace TodoList.Api.Mappers.TodoItems;

public static class TodoItemMapper
{
    public static TodoItemDto ToTodoItemDto(this TodoItem todoItem) =>
        new(todoItem.Id, todoItem.Title, todoItem.Description, todoItem.DueDate, todoItem.IsCompleted);

    public static TodoItem ToTodoItem(this CreateTodoItemDto createTodoItemDto) =>
        new()
        {
            Title = createTodoItemDto.Title,
            Description = createTodoItemDto.Description,
            DueDate = createTodoItemDto.DueDate,
            IsCompleted = false
        };
}
