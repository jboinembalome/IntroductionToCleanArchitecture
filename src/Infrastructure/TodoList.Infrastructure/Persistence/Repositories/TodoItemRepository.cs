using TodoList.Application.Interfaces.Persistence.Repositories;
using TodoList.Domain.Entities;

namespace TodoList.Infrastructure.Persistence.Repositories;

internal sealed class TodoItemRepository(TodoListDbContext dbContext) : ITodoItemRepository
{
    public async Task<TodoItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await dbContext.TodoItems.FindAsync([id], cancellationToken);

    public async Task<TodoItem> AddAsync(TodoItem todoItem, CancellationToken cancellationToken = default)
    {
        await dbContext.TodoItems.AddAsync(todoItem, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return todoItem;
    }
}
