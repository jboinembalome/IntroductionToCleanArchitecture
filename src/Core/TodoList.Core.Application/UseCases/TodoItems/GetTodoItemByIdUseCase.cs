using TodoList.Core.Application.Dtos.TodoItems;
using TodoList.Core.Application.Interfaces.Persistence.Repositories;

namespace TodoList.Core.Application.UseCases.TodoItems;

public interface IGetTodoItemByIdUseCase
{
    Task<TodoItemDto?> Execute(int id, CancellationToken cancellationToken = default);
}

public class GetTodoItemByIdUseCase : IGetTodoItemByIdUseCase
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
