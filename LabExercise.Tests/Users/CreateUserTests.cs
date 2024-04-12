using LabExercise.Tests.Helpers;
using LabExercise.Web.Features.Users;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LabExercise.Tests.Users;

public class CreateUserTests : BaseTestWithExerciseContext
{
    [Fact]
    public async void CreateUser()
    {
        // Arrange 
        var request = new AddUserCommandRequest { Name = "Test" };
        var handler = new AddUserCommandHandler(DbContext);
        
        // Act
        var result = await handler.Handle(request, new CancellationToken());
        
        // Assert
        result.Should().BeOfType<Ok>();
    }
}