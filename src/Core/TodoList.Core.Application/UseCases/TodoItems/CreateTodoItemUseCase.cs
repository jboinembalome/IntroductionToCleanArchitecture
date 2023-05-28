using TodoList.Core.Application.Dtos.TodoItems;
using TodoList.Core.Application.Interfaces.Persistence.Repositories;
using TodoList.Core.Domain.Entities;

namespace TodoList.Core.Application.UseCases.TodoItems;

public interface ICreateTodoItemUseCase
{
    Task<TodoItemDto> Execute(CreateTodoItemDto createTodoItemDto, CancellationToken cancellationToken = default);
}

public class CreateTodoItemUseCase : ICreateTodoItemUseCase
{
    private readonly ITodoItemRepository _todoItemRepository;

    public CreateTodoItemUseCase(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task<TodoItemDto> Execute(CreateTodoItemDto createTodoItemDto, CancellationToken cancellationToken = default)
    {
        if (createTodoItemDto is null)
            throw new ArgumentNullException(nameof(createTodoItemDto));

        var todoItem = new TodoItem
        {
            Title = createTodoItemDto.Title,
            Description = createTodoItemDto.Description,
            DueDate = createTodoItemDto.DueDate,
            IsCompleted = false
        };

        _ = await _todoItemRepository.AddAsync(todoItem, cancellationToken);

        var todoItemDto = new TodoItemDto
        {
            Id = todoItem.Id,
            IsCompleted = todoItem.IsCompleted,
            Title = createTodoItemDto.Title,
            Description = createTodoItemDto.Description,
            DueDate = createTodoItemDto.DueDate
        };

        return todoItemDto;
    }
}
