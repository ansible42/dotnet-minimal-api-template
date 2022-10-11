using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MinimalAPI;

namespace MinimalAPI.IntergrationTest;


public class TestingLibraryFactory : WebApplicationFactory<IAPIMarker>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        //builder.ConfigureServices(collection =>
        //{
        //You can use this locaton to inject singletons or other configureations 
        //as requred for you testing. 
        //collection.AddSingleton()
        //});
    }
}

