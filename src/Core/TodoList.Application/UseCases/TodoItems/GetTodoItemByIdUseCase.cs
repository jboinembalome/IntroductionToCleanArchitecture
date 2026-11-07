using TodoList.Application.Interfaces.Persistence.Repositories;
using TodoList.Domain.Entities;

namespace TodoList.Application.UseCases.TodoItems;

public interface IGetTodoItemByIdUseCase
{
    Task<TodoItem?> Execute(int id, CancellationToken cancellationToken = default);
}

internal sealed class GetTodoItemByIdUseCase(ITodoItemRepository todoItemRepository) : IGetTodoItemByIdUseCase
{
    public Task<TodoItem?> Execute(int id, CancellationToken cancellationToken = default) =>
        todoItemRepository.GetByIdAsync(id, cancellationToken);
}
