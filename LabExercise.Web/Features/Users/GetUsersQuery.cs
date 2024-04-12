using Microsoft.EntityFrameworkCore;

namespace LabExercise.Web.Features.Users;

public class GetUsersQueryRequest : IRequest<List<GetUsersQueryResponse>>
{
    
}

public class GetUsersQueryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}

public class GetUsersQueryHandler : IRequestHandler<GetUsersQueryRequest, List<GetUsersQueryResponse>>
{
    private readonly ExerciseContext _context;

    public GetUsersQueryHandler(ExerciseContext context)
    {
        _context = context;
    }

    public async Task<List<GetUsersQueryResponse>> Handle(GetUsersQueryRequest request, CancellationToken cancellationToken)
    {
        return await _context.Users
            .Select(q => new GetUsersQueryResponse { Id = q.Id, Name = q.Name })
            .OrderBy(q => q.Name).ThenBy(q => q.Id)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}