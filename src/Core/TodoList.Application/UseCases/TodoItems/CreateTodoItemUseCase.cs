using TodoList.Application.Interfaces.Persistence.Repositories;
using TodoList.Domain.Entities;

namespace TodoList.Application.UseCases.TodoItems;

public interface ICreateTodoItemUseCase
{
    Task<TodoItem> Execute(TodoItem todoItem, CancellationToken cancellationToken = default);
}

internal sealed class CreateTodoItemUseCase(ITodoItemRepository todoItemRepository) : ICreateTodoItemUseCase
{
    public async Task<TodoItem> Execute(TodoItem todoItem, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(todoItem);

        // Business logic for creating an item
        return await todoItemRepository.AddAsync(todoItem, cancellationToken);
    }
}
