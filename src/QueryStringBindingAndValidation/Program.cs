using FluentValidation;
using QueryStringBindingAndValidation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidatorsFromAssemblyContaining<Ping>();

var app = builder.Build();

app.UseHttpsRedirection();

app
    .MapGet("/ping", ([AsParameters] Ping orderBy) => Results.Ok(new
    {
        orderBy.Message,
        orderBy.Amount,
        orderBy.AmountString
    }))
    .AddEndpointFilter<PingValidatorFilter<Ping>>();

app.Run();

public record Ping(string Message, decimal Amount, string AmountString);