using System.Net;
using System.Net.Http.Json;
using System.Text;
using Euri_backend.Data.Dto;
using Euri_backend.Data.Models;
using Euri_backend.Testing.Utilities;
using Newtonsoft.Json;

namespace Euri_backend.Testing;

public class BasketControllerTesting
{
    private HttpClient _client;
    
    public BasketControllerTesting()
    {
        var factory = new ControllerFactory<Program>();
        _client = factory.CreateDefaultClient();
    }
    
    /* should get all baskets */
    [Fact]
    [Trait("Endpoint", "GET")]
    public async Task GetAllBaskets()
    {
        var baskets = await _client.GetFromJsonAsync<IEnumerable<BasketModel>>("/api/baskets");
        Assert.Equal(2, baskets.Count());
    }
    
    /* should get a basket */
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [Trait("Endpoint", "GET")]

    public async Task GetBasket(int id)
    {
        var basket = await _client.GetFromJsonAsync<BasketModel>($"api/Baskets/{id}");
        Assert.Equal(id, basket.Id);
        Assert.True(basket.Items.Any());
    }
    
    /* should return not found when getting a basket that doesn't exist */
    [Fact]
    [Trait("Endpoint", "GET")]

    public async Task GetBasketNotFound()
    {
        var response = await _client.GetAsync("/api/baskets/9999");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    /* should create a basket */
    [Fact]
    [Trait("Endpoint", "POST")]
    public async Task CreateBasket()
    {
        var basket = new CreateBasketDto()
        {
            Items = new List<CreateBasketItemDto>
            {
                new ()
                {
                    Id = 1,
                    Quantity = 10
                },
                new ()
                {
                    Id = 2,
                    Quantity = 20
                },
                new ()
                {
                    Id = 3,
                    Quantity = 30
                }
            }
        };
        var response = await _client.PostAsJsonAsync("api/baskets", basket);
        response.EnsureSuccessStatusCode();
        var stringResponse = await response.Content.ReadAsStringAsync();
        var newBasket = JsonConvert.DeserializeObject<BasketModel>(stringResponse);
        Assert.Equal(3, newBasket.Id);
        Assert.Equal(3, newBasket.Items.Count);
    }
    
    /* should delete a basket */
    [Fact]
    [Trait("Endpoint", "DELETE")]
    public async Task DeleteBasket()
    {
        var response = await _client.DeleteAsync("/api/baskets/1");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        
        var response2 = await _client.GetAsync("/api/baskets/1");
        Assert.Equal(HttpStatusCode.NotFound, response2.StatusCode);
    }
}