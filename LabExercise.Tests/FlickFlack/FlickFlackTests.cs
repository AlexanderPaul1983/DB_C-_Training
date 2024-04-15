using LabExercise.Web.Features.FlickFlack;

namespace LabExercise.Tests.FlickFlack;

public class FlickFlackTests
{
    private const string Flick = "Flick";
    private const string Flack = "Flack";
    private const string FlickFlack = "FlickFlack";
    private readonly GetFlickFlackQueryHandler _handler = new();
    
    // Aufgabe a) 
    
    [Fact]
    public async void ErrorWhenEndGreaterThen100()
    {
        // Arrange 
        var request = new GetFlickFlackQueryRequest { Start = 20, End = 110 };

        // Act
        var action = () => _handler.Handle(request, new CancellationToken());

        // Assert
        await action.Should().ThrowExactlyAsync<ArgumentException>();
    }
    
    [Fact]
    public async void ErrorWhenStartGreaterEnd()
    {
        // Arrange 
        var request = new GetFlickFlackQueryRequest { Start = 20, End = 19 };

        // Act
        var action = () => _handler.Handle(request, new CancellationToken());

        // Assert
        await action.Should().ThrowExactlyAsync<ArgumentException>();
    }
    
    // Aufgabe b)

    [Fact]
    public async void ErrorWhenStartSmallerThanOne()
    {
        // Arrange
        var request = new GetFlickFlackQueryRequest { Start = 0, End = 30 };
        var handler = new GetFlickFlackQueryHandler();

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(request, new CancellationToken()));
        Assert.Equal("Ungültige Eingabe, Start darf nicht weniger als 1 sein!", exception.Message);
    }

    [Fact]
    public async void ErrorWhenEndBiggerThanHundert()
    {
        var request = new GetFlickFlackQueryRequest(){Start = 20, End = 110};
        var handler = new GetFlickFlackQueryHandler();

        var exception =
            await Assert.ThrowsAsync<ArgumentException>((() => handler.Handle(request, new CancellationToken())));
        Assert.Equal("Falsche Eingabe: End darf nicht mehr als 100 sein!", exception.Message);
    }
    [Fact]
    public async void ErrorWhenStartIsBiggerThanEnd()
    {
        var request = new GetFlickFlackQueryRequest() { Start = 50, End = 49 };
        var handler = new GetFlickFlackQueryHandler();
        
        var expection = await Assert.ThrowsAsync<ArgumentException>((() =>
            handler.Handle(request, new CancellationToken())));
        Assert.Equal("Falsche Eingabe: Start darf nicht größer als End sein!", expection.Message);
    }

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