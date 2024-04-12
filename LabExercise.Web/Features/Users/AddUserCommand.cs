namespace LabExercise.Web.Features.Users;

public class AddUserCommandRequest : IRequest<IResult>
{
    public string Name { get; set; } = "";
}

public class AddUserCommandHandler : IRequestHandler<AddUserCommandRequest, IResult>
{
    private readonly ExerciseContext _context;

    public AddUserCommandHandler(ExerciseContext context)
    {
        _context = context;
    }

    public async Task<IResult> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return Results.BadRequest("Name can not be empty");

        var newUser = new User { Name = request.Name };
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync(cancellationToken);
        return Results.Ok();
    }
}