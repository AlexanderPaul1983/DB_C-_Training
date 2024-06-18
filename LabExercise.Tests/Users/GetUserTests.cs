using LabExercise.Tests.Helpers;
using LabExercise.Web.Features.Users;

namespace LabExercise.Tests.Users;

public class GetUserTests : BaseTestWithExerciseContext
{
    
     /*
    [Fact]
    public async void GetUserWithValidId()
    {
        // Arrange
        var createRequest = new AddUserCommandRequest { Name = "Test" };
        var createHandler = new AddUserCommandHandler(DbContext);
        await createHandler.Handle(createRequest, new CancellationToken());
        var getUsersRequest = new GetUsersQueryRequest();
        var getUserHandler = new GetUsersQueryHandler(DbContext);
        var id = (await getUserHandler.Handle(getUsersRequest, new CancellationToken()))
            .First().Id;

        var request = new GetUserQueryRequest { Id = id };
        var handler = new GetUserQueryHandler(DbContext);
        // Act
        var response = (await handler.Handle(request, new CancellationToken()));

        // Assert
        response.Should().NotBeNull();
        response?.Id.Should().Be(id);
    }

    [Fact]
    public async void GetUserWithInvalidId()
    {
        // Arrange
        var request = new GetUserQueryRequest { Id = Int32.MinValue };
        var handler = new GetUserQueryHandler(DbContext);
        // Act
        var response = (await handler.Handle(request, new CancellationToken()));

        // Assert
        response.Should().BeNull();
    }

    */
}