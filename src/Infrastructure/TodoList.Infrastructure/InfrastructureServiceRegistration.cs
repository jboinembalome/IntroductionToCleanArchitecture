using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Application.Interfaces.Persistence.Repositories;
using TodoList.Infrastructure.Persistence;
using TodoList.Infrastructure.Persistence.Repositories;

namespace TodoList.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<TodoListDbContext>(options =>
                options.UseInMemoryDatabase("TodoListDb"));

        services.AddScoped<ITodoItemRepository, TodoItemRepository>();

        return services;
    }
}

