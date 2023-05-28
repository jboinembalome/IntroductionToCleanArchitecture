using TodoList.Core.Domain.Interfaces;

namespace TodoList.Core.Domain.Entities;

public class TodoItem : IEntity<int>
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsCompleted { get; set; }
}