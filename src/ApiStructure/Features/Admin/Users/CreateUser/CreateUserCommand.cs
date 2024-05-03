using Paramore.Brighter;

namespace ApiStructure.Features.Admin.Users.CreateUser;

public class CreateUserCommand : Command
{
    public CreateUserCommand() : base(Guid.NewGuid())
    {
    }
}