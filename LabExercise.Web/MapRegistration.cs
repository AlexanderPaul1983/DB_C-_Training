using LabExercise.Web.Features.Users;

namespace LabExercise.Web;

public static class MapRegistration
{
    public static void UseMaps(this WebApplication app)
    {
        app.MapGet("Users/",
            async (IMediator mediator, [AsParameters] GetUsersQueryRequest request)
                => await mediator.Send(request));

        app.MapPost("Users/",
            async (IMediator mediator,AddUserCommandRequest request) 
                => await mediator.Send(request));
    }
}