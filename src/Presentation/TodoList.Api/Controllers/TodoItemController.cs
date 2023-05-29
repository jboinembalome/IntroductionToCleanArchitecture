using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Dtos.TodoItems;
using TodoList.Application.UseCases.TodoItems;
using TodoList.Domain.Entities;

namespace TodoList.Api.Controllers;

public class TodoItemController : ApiControllerBase
{
    private readonly ICreateTodoItemUseCase _createTodoItemUseCase;
    private readonly IGetTodoItemByIdUseCase _getTodoItemByIdUseCase;

    public TodoItemController(ICreateTodoItemUseCase createTodoItemUseCase, IGetTodoItemByIdUseCase getTodoItemByIdUseCase)
    {
        _createTodoItemUseCase = createTodoItemUseCase;
        _getTodoItemByIdUseCase = getTodoItemByIdUseCase;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItemDto?>> Get(int id, CancellationToken cancellationToken)
    {
        if (id <= 0) return BadRequest();

        var todoItem = await _getTodoItemByIdUseCase.Execute(id, cancellationToken);

        if (todoItem is null) return NotFound();

        var dto = new TodoItemDto
        {
            Id = todoItem.Id,
            Title = todoItem.Title,
            Description = todoItem.Description,
            DueDate = todoItem.DueDate,
            IsCompleted = todoItem.IsCompleted,
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<TodoItemDto>> Create(CreateTodoItemDto createTodoItemDto, CancellationToken cancellationToken)
    {
        var todoItem = new TodoItem
        {
            Title = createTodoItemDto.Title,
            Description = createTodoItemDto.Description,
            DueDate = createTodoItemDto.DueDate,
            IsCompleted = false
        };

        _ = await _createTodoItemUseCase.Execute(todoItem, cancellationToken);

        var dto = new TodoItemDto
        {
            Id = todoItem.Id,
            IsCompleted = todoItem.IsCompleted,
            Title = createTodoItemDto.Title,
            Description = createTodoItemDto.Description,
            DueDate = createTodoItemDto.DueDate
        };

        return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
    }
}