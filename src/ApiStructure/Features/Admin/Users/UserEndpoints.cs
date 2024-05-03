using ApiStructure.Features.Admin.Users.CreateUser;
using ApiStructure.Features.Admin.Users.GetAll;
using Paramore.Brighter;
using Paramore.Darker;

namespace ApiStructure.Features.Admin.Users;

public static class Api
{
    public static WebApplication AddUserEndpoints(this WebApplication app)
    {
        app.MapGroup("/users").MapUserApis();
        return app;
    }

    private static RouteGroupBuilder MapUserApis(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetAllUsers);
        group.MapGet("/{id}", GetUser);
        group.MapPost("/", CreateUser);
        group.MapPut("/{id}", UpdateUser);
        group.MapDelete("/{id}", DeleteUser);

        return group;
    }

    private static async Task<IResult> GetAllUsers(IQueryProcessor queryProcessor)
    {
        var result = await queryProcessor.ExecuteAsync(new GetAllUsersQuery());

        return Results.Ok(result);
    }

    private static async Task<IResult> GetUser(int userId)
        => Results.Ok();

    private static async Task<IResult> CreateUser(IAmACommandProcessor commandProcessor)
    {
        await commandProcessor.SendAsync<CreateUserCommand>(new());

        return Results.Created();
    }

    private static Task<IResult> UpdateUser(int id)
        => Task.FromResult(Results.Accepted());
    
    private static Task<IResult> DeleteUser(int id)
        => Task.FromResult(Results.NoContent());
}