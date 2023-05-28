using TodoList.Core.Domain.Entities;

namespace TodoList.Core.Application.Interfaces.Persistence.Repositories;

public interface ITodoItemRepository
{
    Task<TodoItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<TodoItem> AddAsync(TodoItem todoItem, CancellationToken cancellationToken = default);
}
