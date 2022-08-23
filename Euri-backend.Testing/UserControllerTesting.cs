using System.Net;
using System.Text;
using Euri_backend.Data.Dto;
using Euri_backend.Data.Models;
using Euri_backend.Testing.Utilities;
using Newtonsoft.Json;

namespace Euri_backend.Testing;

public class UserControllerTesting
{
    private readonly HttpClient _client;

    public UserControllerTesting()
    {
        var factory = new ControllerFactory<Program>();
        _client = factory.CreateDefaultClient();
    }

    /* Status code should be 200 when getting all user */
    [Fact(DisplayName = "Get all users should return 200")]
    public async Task ReturnsOk()
    {
        var response = await _client.GetAsync("/api/users");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    /* lenght of the response should 2 */
    [Fact(DisplayName = "Get all users should return 2 users")]
    public async Task ReturnLengthOf2Users()
    {
        // UpdateDbWithUsers();
        var response = await _client.GetAsync("/api/users");
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal(2, JsonConvert.DeserializeObject<List<UserModel>>(content).Count);
    }

    /* should return the user with id 1 */
    [Fact(DisplayName = "Get user with id 1 should return user with id 1")]
    public async Task ReturnsUserWithId()
    {
        var response = await _client.GetAsync("/api/users/1");
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal(1, JsonConvert.DeserializeObject<UserModel>(content).Id);
    }

    /* should return notFound when user doesn't exist */
    [Fact(DisplayName = "Should return notFound when user doesn't exist")]
    public async Task ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/users/9999");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    /* When creating a user it should return the user with an id */
    [Fact(DisplayName = "When creating a user it should return the user with an id")]
    public async Task CreateUser_ReturnsUserWithId()
    {
        var user = new CreateUserDto
        {
            FirstName = "test3",
            LastName = "test3",
            Password = "secretpassword",
            Email = "test3.test3@euri.com",
            Role = "testrole",
            Address = new CreateAddressDto
            {
                City = "testcity",
                Country = "testcountry",
                Street = "teststreet",
                Zip = "testzipcode",
                Number = "testnumber"
            }
        };
        var response = await _client.PostAsync("/api/users",
            new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        /* should have an id */
        Assert.True(JsonConvert.DeserializeObject<UserModel>(content).Id > 0);
    }

    /* When user doesn't have the same id as endpoint it should return a badRequest */
    [Fact(DisplayName = "When user doesn't have the same id as the endpoint it should return a badRequest")]
    public async Task CreateUser_ReturnsBadRequest()
    {
        var user = new UpdatedUserDto
        {
            Id = 1,
            FirstName = "test3",
            LastName = "test3",
            Password = "secretpassword",
            Email = "test3@euri.com",
            Role = "testrole",
            Address = new UpdateAddressDto
            {
                City = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                Country = "testcountry",
                Street = "teststreet",
                Zip = "testzipcode",
                Number = "testnumber"
            }
        };
        var response = await _client.PutAsync("/api/users/2",
            new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    /* When updating a user it should update the values*/
    [Fact(DisplayName = "When updating a user it should update the values")]
    public async Task UpdateUser_UpdatesValues()
    {
        var user = new UpdatedUserDto
        {
            Id = 1,
            FirstName = "test3",
            LastName = "test3",
            Password = "secretpassword",
            Email = "test3@euri.com",
            Role = "testrole",
            Address = new UpdateAddressDto
            {
                City = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                Country = "testcountry",
                Street = "teststreet",
                Zip = "testzipcode",
                Number = "testnumber"
            }
        };

        var response = await _client.PutAsync("/api/users/1",
            new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("test3", JsonConvert.DeserializeObject<UserModel>(content).FirstName);
        Assert.Equal("ABCDEFGHIJKLMNOPQRSTUVWXYZ", JsonConvert.DeserializeObject<UserModel>(content).Address.City);
    }

/* When updating a user it should return notFound when user doesn't exist */
    [Fact(DisplayName = "When updating a user it should return notFound when user doesn't exist")]
    public async Task UpdateUser_ReturnsNotFound()
    {
        var user = new UpdatedUserDto
        {
            Id = 9999,
            FirstName = "test3",
            LastName = "test3",
            Password = "secretpassword",
            Email = "test3@euri.com",
            Role = "testrole",
            Address = new UpdateAddressDto
            {
                City = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                Country = "testcountry",
                Street = "teststreet",
                Zip = "testzipcode",
                Number = "testnumber"
            }
        };

        var response = await _client.PutAsync("/api/users/9999",
            new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    /* When deleting a user it should return ok */
    [Fact(DisplayName = "When deleting a user it should return ok")]
    public async Task DeleteUser_ReturnsOk()
    {
        var response = await _client.DeleteAsync("/api/users/1");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

/* When deleting a user it should return notFound when user doesn't exist */

    [Fact(DisplayName = "When deleting a user it should return notFound when user doesn't exist")]
    public async Task DeleteUser_ReturnsNotFound()
    {
        var response = await _client.DeleteAsync("/api/users/9999");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}