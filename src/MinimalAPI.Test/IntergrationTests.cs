using System.Net;
using FluentAssertions;
using Xunit;
using MinimalAPI;
using MinimalAPI.Endpoints; 

namespace MinimalAPI.IntergrationTest;

public class IntergrationTests : IClassFixture<TestingLibraryFactory>, IAsyncLifetime
{
    private readonly TestingLibraryFactory _factory;
    public IntergrationTests(TestingLibraryFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async void GetWeather()
    {
        // Setup 
        var httpClient = _factory.CreateClient();
        // Action 
        var result = await httpClient.GetAsync($"/weatherforecast");
        var returned = await result.Content.ReadFromJsonAsync<WeatherForceast[]>();

        // Result
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        returned.Should().NotBeNullOrEmpty();
        returned.Should().BeOfType<WeatherForceast[]>();    
    }
    public Task DisposeAsync()
    {
        //Post test cleanup goes here.
        return Task.CompletedTask; 
    }

    public Task InitializeAsync()
    {
        //run itilization items here if needed 
        return Task.CompletedTask;
    }


}
