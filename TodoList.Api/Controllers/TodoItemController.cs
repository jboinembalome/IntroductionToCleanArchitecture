using Microsoft.AspNetCore.Mvc;
using TodoList.Core.Application.Dtos.TodoItems;
using TodoList.Core.Application.UseCases.TodoItems;

namespace TodoList.Api.Controllers
{
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
        public async Task<ActionResult<TodoItemDto>> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await _getTodoItemByIdUseCase.Execute(id, cancellationToken);
            if (dto is null) return NotFound();

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> Create(CreateTodoItemDto createTodoItemDto, CancellationToken cancellationToken)
        {
            var dto = await _createTodoItemUseCase.Execute(createTodoItemDto, cancellationToken);

            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }
    }
}