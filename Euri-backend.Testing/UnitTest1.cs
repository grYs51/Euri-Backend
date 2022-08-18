using System.Net;
using Euri_backend.Testing.Utilities;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions;

namespace Euri_backend.Testing;

public class UnitTest1 : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly HttpClient _client;
    
    public UnitTest1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        var factory = new CustomWebApplicationFactory<Program>();
        _client = factory.CreateDefaultClient();
    }   
    
    /* get User by id */
    // [Fact]
    // public async Task GetUserById()
    // {
    //     var response = await _client.GetAsync("/api/users/1");
    //     response.EnsureSuccessStatusCode();
    //     
    //     
    //     var responseString = await response.Content.ReadAsStringAsync();
    //     Assert.Equal(expected, responseString);
    // }
    
    /* Status code should be 200 when getting user */
    [Fact]
    public async Task GetUserByIdWithStatusCode200()
    {
        var response = await _client.GetAsync("/api/Users/1");
        _testOutputHelper.WriteLine(response.ToString());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
}