using TodoList.Application.Dtos.TodoItems;
using TodoList.Application.Interfaces.Persistence.Repositories;

namespace TodoList.Application.UseCases.TodoItems;

public interface IGetTodoItemByIdUseCase
{
    Task<TodoItemDto?> Execute(int id, CancellationToken cancellationToken = default);
}

internal class GetTodoItemByIdUseCase : IGetTodoItemByIdUseCase
{
    private readonly ITodoItemRepository _todoItemRepository;

    public GetTodoItemByIdUseCase(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task<TodoItemDto?> Execute(int id, CancellationToken cancellationToken = default)
    {
        var todoItem = await _todoItemRepository.GetByIdAsync(id, cancellationToken);

        if (todoItem == null) return null;

        var dto = new TodoItemDto
        {
            Id = todoItem.Id,
            Title = todoItem.Title,
            Description = todoItem.Description,
            DueDate = todoItem.DueDate,
            IsCompleted = todoItem.IsCompleted,
        };

        return dto;
    }
}
