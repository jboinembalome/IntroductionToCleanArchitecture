using TodoList.Application.Interfaces.Persistence.Repositories;
using TodoList.Domain.Entities;

namespace TodoList.Application.UseCases.TodoItems;

public interface ICreateTodoItemUseCase
{
    Task<TodoItem> Execute(TodoItem todoItem, CancellationToken cancellationToken = default);
}

internal class CreateTodoItemUseCase : ICreateTodoItemUseCase
{
    private readonly ITodoItemRepository _todoItemRepository;

    public CreateTodoItemUseCase(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task<TodoItem> Execute(TodoItem todoItem, CancellationToken cancellationToken = default)
    {
        if (todoItem is null)
            throw new ArgumentNullException(nameof(todoItem));

        _ = await _todoItemRepository.AddAsync(todoItem, cancellationToken);

        return todoItem;
    }
}
