using System.Net;
using System.Text;
using Euri_backend.Data;
using Euri_backend.Data.Dto;
using Euri_backend.Data.Models;
using Euri_backend.Testing.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Euri_backend.Testing;

public class UnitTest1
{
    private readonly HttpClient _client;
    
    public UnitTest1()
    {
        var factory = new CustomWebApplicationFactory<Program>();
        _client = factory.CreateDefaultClient();
    }

    /* Status code should be 200 when getting all user */
    [Fact]
    public async Task ReturnsOk()
    {
        var response = await _client.GetAsync("/api/users");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    /* lenght of the response should 2 */
    [Fact]
    public async Task ReturnLengthOf2Users()
    {
        // UpdateDbWithUsers();
        var response = await _client.GetAsync("/api/users");
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal(2, JsonConvert.DeserializeObject<List<UserModel>>(content).Count);
        
    }
    
    /* should return the user with id 1 */
    [Fact]
    public async Task ReturnsUserWithId()
    {
        var response = await _client.GetAsync("/api/users/1");
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal(1, JsonConvert.DeserializeObject<UserModel>(content).Id);
    }
    
    /* should return notFound when user doesn't exist */
    [Fact]
    public async Task ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/users/9999");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    /* When creating a user it should return the user with an id */
    [Fact]
    public async Task CreateUser_ReturnsUserWithId()
    {
        var user = new CreateUserDto()
        {
            FirstName = "test3",
            LastName = "test3",
            Password = "secretpassword",
            Email = "test3.test3@euri.com",
            Role = "testrole",
            Address = new CreateAddressDto()
            {
                City = "testcity",
                Country = "testcountry",
                Street = "teststreet",
                Zip = "testzipcode",
                Number = "testnumber",
            },
        };
        var response = await _client.PostAsync("/api/users",
            new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        /* should have an id */
        
        Assert.True(JsonConvert.DeserializeObject<UserModel>(content).Id > 0);
    }
}