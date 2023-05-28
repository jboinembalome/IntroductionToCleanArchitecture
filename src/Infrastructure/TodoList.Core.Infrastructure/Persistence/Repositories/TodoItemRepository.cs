using TodoList.Core.Application.Interfaces.Persistence.Repositories;
using TodoList.Core.Domain.Entities;

namespace TodoList.Infrastructure.Persistence.Repositories;

internal class TodoItemRepository : ITodoItemRepository
{
    private readonly TodoListDbContext _dbContext;

    public TodoItemRepository(TodoListDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TodoItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var keyValues = new object[] { id };
        return await _dbContext.TodoItems.FindAsync(keyValues, cancellationToken);
    }

    public async Task<TodoItem> AddAsync(TodoItem todoItem, CancellationToken cancellationToken = default)
    {
        await _dbContext.TodoItems.AddAsync(todoItem, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return todoItem;
    }
}
