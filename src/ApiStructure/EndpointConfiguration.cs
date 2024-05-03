using ApiStructure.Features.Admin.Teams;
using ApiStructure.Features.Admin.Users;
using ApiStructure.Features.Customer.Basket;
using ApiStructure.Features.Customer.Products;

namespace ApiStructure;

public static class AdminEndpoints
{
    public static WebApplication AddAdminEndpoints(this WebApplication app)
    {
        app.AddUserEndpoints();
        app.AddTeamEndpoints();
        return app;
    }
}

public static class CustomerEndpoints
{
    public static WebApplication AddCustomerEndpoints(this WebApplication app)
    {
        app.AddProductEndpoints();
        app.AddBasketEndpoints();
        return app;
    }
}