namespace TodoList.Core.Application.Dtos.TodoItems
{
    public record TodoItemDto: CreateTodoItemDto
    {
        public int Id { get; init; }
        public bool IsCompleted { get; init; }

    }
}
