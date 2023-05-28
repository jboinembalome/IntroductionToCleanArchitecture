namespace TodoList.Core.Application.Dtos.TodoItems
{
    public record CreateTodoItemDto
    {
        public required string Title { get; init; }
        public string? Description { get; init; }
        public DateTime? DueDate { get; init; }
    }
}
