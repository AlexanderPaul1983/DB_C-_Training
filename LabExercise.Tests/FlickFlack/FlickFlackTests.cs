using LabExercise.Web.Features.FlickFlack;

namespace LabExercise.Tests.FlickFlack;

public class FlickFlackTests
{
    private const string Flick = "Flick";
    private const string Flack = "Flack";
    private const string FlickFlack = "FlickFlack";
    private readonly GetFlickFlackQueryHandler _handler = new();

    [Fact]
    public async void ErrorWhenStartLessThen1()
    {
        // Arrange 
        var request = new GetFlickFlackQueryRequest { Start = 0, End = 30 };

        // Act
        var action = () => _handler.Handle(request, new CancellationToken());

        // Assert
        await action.Should().ThrowExactlyAsync<ArgumentException>();
    }

    [Fact]
    public async void Start1End12()
    {
        // Arrange 
        var request = new GetFlickFlackQueryRequest { Start = 1, End = 12 };

        // Act
        var result = await _handler.Handle(request, new CancellationToken());

        // Assert
        result.Should().NotBeNull();
        result.Elements.Should().BeEquivalentTo("1", "2", Flick, Flack, "5", Flick,
            "7", Flack, Flick, "10", "11", FlickFlack);
    }
}