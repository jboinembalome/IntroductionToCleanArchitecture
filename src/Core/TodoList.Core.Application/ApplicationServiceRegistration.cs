
using Microsoft.Extensions.DependencyInjection;
using TodoList.Core.Application.UseCases.TodoItems;

namespace TodoList.Infrastructure;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateTodoItemUseCase, CreateTodoItemUseCase>();
        services.AddScoped<IGetTodoItemByIdUseCase, GetTodoItemByIdUseCase>();

        return services;
    }
}

