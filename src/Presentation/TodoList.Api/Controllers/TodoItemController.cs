using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Dtos.TodoItems;
using TodoList.Api.Mappers.TodoItems;
using TodoList.Application.UseCases.TodoItems;

namespace TodoList.Api.Controllers;

public sealed class TodoItemController(
    ICreateTodoItemUseCase createTodoItemUseCase,
    IGetTodoItemByIdUseCase getTodoItemByIdUseCase) : ApiControllerBase
{
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TodoItemDto>> Get(int id, CancellationToken cancellationToken)
    {
        if (id <= 0) return BadRequest();

        var todoItem = await getTodoItemByIdUseCase.Execute(id, cancellationToken);
        if (todoItem is null) return NotFound();

        return todoItem.ToTodoItemDto();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TodoItemDto>> Create(CreateTodoItemDto createTodoItemDto, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(createTodoItemDto.Title)) return BadRequest();

        var todoItem = createTodoItemDto.ToTodoItem();
        var createdTodoItem = await createTodoItemUseCase.Execute(todoItem, cancellationToken);

        var dto = createdTodoItem.ToTodoItemDto();
        return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
    }
}
