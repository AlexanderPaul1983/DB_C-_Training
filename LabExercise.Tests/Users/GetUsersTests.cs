using LabExercise.Tests.Helpers;
using LabExercise.Web.Features.Users;

namespace LabExercise.Tests.Users;

public class GetUsersTests  : BaseTestWithExerciseContext
{
    [Fact]
    public async void GetUsers()
    {
        // Arrange 
        var createRequest = new AddUserCommandRequest { Name = "Test" };
        var createHandler = new AddUserCommandHandler(DbContext);
        await createHandler.Handle(createRequest, new CancellationToken());
        var request = new GetUsersQueryRequest { };
        var handler = new GetUsersQueryHandler(DbContext);

        // Act
        var response = await handler.Handle(request, new CancellationToken());

        // Assert
        response.Should().HaveCount(1);
        response.First().Should().BeEquivalentTo(createRequest);
    }
}