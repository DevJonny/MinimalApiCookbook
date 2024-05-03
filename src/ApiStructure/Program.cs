using ApiStructure;
using Paramore.Brighter.Extensions.DependencyInjection;
using Paramore.Darker.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Configuring Brighter and Darker for CQRS
// https://github.com/BrighterCommand/Brighter
// https://github.com/BrighterCommand/Darker
builder.Services.AddBrighter();
builder.Services.AddDarker();

var app = builder.Build();

app.AddCustomerEndpoints();
app.AddAdminEndpoints();

app.Run();