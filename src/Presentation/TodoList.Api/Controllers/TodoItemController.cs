using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Dtos.TodoItems;
using TodoList.Api.Mappers.TodoItems;
using TodoList.Application.UseCases.TodoItems;

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

        var dto = todoItem.ToTodoItemDto();
        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<TodoItemDto>> Create(CreateTodoItemDto createTodoItemDto, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(createTodoItemDto?.Title)) return BadRequest();

        var todoItem = createTodoItemDto.ToTodoItem();
        _ = await _createTodoItemUseCase.Execute(todoItem, cancellationToken);

        var dto = todoItem.ToTodoItemDto();
        return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
    }
}