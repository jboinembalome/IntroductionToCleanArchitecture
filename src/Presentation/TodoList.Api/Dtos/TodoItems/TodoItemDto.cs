namespace TodoList.Api.Dtos.TodoItems;

public sealed record TodoItemDto(int Id, string Title, string? Description, DateTime? DueDate, bool IsCompleted);
