namespace TodoList.Api.Dtos.TodoItems;

// What a client may send: no Id, no IsCompleted, so they cannot be over-posted.
public sealed record CreateTodoItemDto(string Title, string? Description, DateTime? DueDate);
