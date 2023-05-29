using TodoList.Application.Interfaces.Persistence.Repositories;
using TodoList.Domain.Entities;

namespace TodoList.Application.UseCases.TodoItems;

public interface IGetTodoItemByIdUseCase
{
    Task<TodoItem?> Execute(int id, CancellationToken cancellationToken = default);
}

internal class GetTodoItemByIdUseCase : IGetTodoItemByIdUseCase
{
    private readonly ITodoItemRepository _todoItemRepository;

    public GetTodoItemByIdUseCase(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task<TodoItem?> Execute(int id, CancellationToken cancellationToken = default)
    {
        var todoItem = await _todoItemRepository.GetByIdAsync(id, cancellationToken);
        return todoItem;
    }
}
