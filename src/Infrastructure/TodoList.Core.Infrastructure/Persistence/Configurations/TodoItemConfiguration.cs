using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TodoList.Core.Domain.Entities;

namespace TodoList.Infrastructure.Persistence.Configurations
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.Property(b => b.Id)
               .IsRequired();

            builder.Property(b => b.Title)
               .IsRequired();
        }
    }
}
