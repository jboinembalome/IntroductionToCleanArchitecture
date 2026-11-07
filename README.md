# Introduction to Clean Architecture

Source code used in the article [Introduction to Clean Architecture](https://blouppy.com/blog/2023-05-28-introduction-to-clean-architecture/) on the [Blouppy](https://blouppy.com) website.

A small ToDoList API split into the four rings of Clean Architecture:

| Project | Ring | Holds |
| --- | --- | --- |
| `src/Core/TodoList.Domain` | Entities | `TodoItem` |
| `src/Core/TodoList.Application` | Use cases | `CreateTodoItemUseCase`, `GetTodoItemByIdUseCase` and the `ITodoItemRepository` port they need |
| `src/Infrastructure/TodoList.Infrastructure` | Interface adapters | `TodoItemRepository` on EF Core (in-memory provider) |
| `src/Presentation/TodoList.Api` | Frameworks and drivers | ASP.NET Core controller, request/response records and their mapping |

References only point inward: the domain depends on nothing, the application on the domain, the infrastructure on the application, and the API wires everything together.

## Project type
- ASP.NET Core Web API (controllers)

## Project version
- .NET 10 (C# 14)

## NuGet packages
- **Microsoft.EntityFrameworkCore.InMemory**: 10.0.14
- **Microsoft.AspNetCore.OpenApi**: 10.0.14

## Run it

```bash
dotnet run --project src/Presentation/TodoList.Api --launch-profile http
```

The OpenAPI document is served at `http://localhost:5041/openapi/v1.json` in Development.

```bash
curl -i -X POST http://localhost:5041/api/TodoItem \
  -H 'Content-Type: application/json' \
  -d '{"title":"Write the article","description":"Clean Architecture in C#","dueDate":"2026-11-30T00:00:00"}'

curl -i http://localhost:5041/api/TodoItem/1
```

## Give a Star! :star:
If you like or are using this project please give it a star. Thanks!

## Support this project! :pray:
If you want to help me to maintain this project or add improvements, it would be a pleasure!
