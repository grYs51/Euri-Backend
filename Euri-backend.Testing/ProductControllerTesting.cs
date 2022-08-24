using System.Net;
using System.Net.Http.Json;
using System.Text;
using Euri_backend.Data.Dto;
using Euri_backend.Data.Models;
using Euri_backend.Testing.Utilities;
using Newtonsoft.Json;

namespace Euri_backend.Testing;

public class ProductControllerTesting
{
    private readonly HttpClient _client;

    public ProductControllerTesting()
    {
        var factory = new ControllerFactory<Program>();
        _client = factory.CreateDefaultClient();
    }

    /* should get page one with 10 products */
    [Fact]
    public async Task Get_Should_Return_10_Products()
    {
        var products = await _client.GetFromJsonAsync<IEnumerable<ProductModel>>("/api/Products");
        Assert.Equal(10, products.Count());
    }

    /* should get header with metadata about all items*/
    [Fact]
    public async Task Get_Should_Return_Header_With_Amount_Of_Items()
    {
        var response = await _client.GetAsync("/api/products");
        response.EnsureSuccessStatusCode();
        var stringHeader = response.Headers.GetValues("X-Pagination").FirstOrDefault();
        var header = JsonConvert.DeserializeObject<Metadata>(stringHeader);
        Assert.Equal(11, header.TotalCount);
        Assert.Equal(10, header.PageSize);
        Assert.Equal(1, header.CurrentPage);
        Assert.Equal(2, header.TotalPages);
        Assert.True(header.HasNext);
        Assert.False(header.HasPrevious);
    }

    /* should get page two with 2 products */
    [Fact]
    public async Task Get_Should_Return_2_Products()
    {
        var response = await _client.GetAsync("/api/products?PageNumber=2&pageSize=2");
        response.EnsureSuccessStatusCode();
        var stringResponse = await response.Content.ReadAsStringAsync();
        var products = JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(stringResponse);
        var stringHeader = response.Headers.GetValues("X-Pagination").FirstOrDefault();
        var header = JsonConvert.DeserializeObject<Metadata>(stringHeader);

        Assert.Equal(2, products.Count());
        Assert.Equal(2, header.CurrentPage);
    }

    /* should get 3 product with category 1 */
    [Fact]
    public async Task Get_Should_Return_3_Products_With_Category_1()
    {
        var products = await _client.GetFromJsonAsync<IEnumerable<ProductModel>>("/api/products?Filter=1");
        Assert.Equal(3, products.Count());
    }

    /* should get empty list when no products with category 9999 */
    [Fact]
    public async Task Get_Should_Return_Empty_List_When_No_Products_With_Category_9999()
    {
        var products = await _client.GetFromJsonAsync<IEnumerable<ProductModel>>("/api/products?Filter=9999");
        Assert.Empty(products);
    }

    /* should return product with id 1 */
    [Fact]
    public async Task Get_Should_Return_Product_With_Id_1()
    {
        var product = await _client.GetFromJsonAsync<ProductModel>("/api/products/1");
        Assert.Equal(1, product.Id);
    }

    /* should return 404 when product with id 9999 not found */
    [Fact]
    public async Task Get_Should_Return_404_When_Product_With_Id_9999_Not_Found()
    {
        var response = await _client.GetAsync("/api/products/9999");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    /* should return 400 when id is not an int */
    [Fact]
    public async Task Get_Should_Return_400_When_Id_is_Not_An_Int()
    {
        var response = await _client.GetAsync("api/Products/string");
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    /* should return product with id 12 when creating new product */
    [Fact]
    public async Task Post_Should_Return_Product_With_Id_12()
    {
        var product = new CreateProductDto()
        {
            Name = "Product 12",
            Description = "Description 12",
            Price = 2,
            Category = "1",
            Discount = 12,
            Stock = 2,
        };
        
        var response = await _client.PostAsJsonAsync("/api/products", product);
        response.EnsureSuccessStatusCode();
        var stringResponse = await response.Content.ReadAsStringAsync();
        var newProduct = JsonConvert.DeserializeObject<ProductModel>(stringResponse);

        Assert.Equal(12, newProduct.Id);
    }
    
    /* should return bad request when dto is not correct */
    [Fact]
    public async Task Post_Should_Return_Bad_Request_When_Dto_Is_Not_Correct()
    {
        var product = new 
        {
            user = "Product 12",
            Description = "Description 12",
            Price = "2.99",
            Category = "1",
        };

        var response = await _client.PostAsJsonAsync("/api/products", product);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    /* should update product with id 1 */
    [Fact]
    public async Task Put_Should_Update_Product_With_Id_1()
    {
        var product = new UpdateProductDto()
        {
            Id = 1,
            Name = "New Product 1",
            Description = "Description 1",
            Price = 2,
            Category = "1",
            Discount = 1,
            Stock = 99,
        };
        var response = await _client.PutAsJsonAsync("/api/products/1", product);
        response.EnsureSuccessStatusCode();
        var stringResponse = await response.Content.ReadAsStringAsync();
        var newProduct = JsonConvert.DeserializeObject<ProductModel>(stringResponse);

        Assert.Equal("New Product 1", newProduct.Name);
        Assert.Equal(99, newProduct.Stock);
    }
    
    /* should delete product with id 1 */
    [Fact]
    public async Task Delete_Should_Delete_Product_With_Id_1()
    {
        var response = await _client.DeleteAsync("/api/products/1");
        response.EnsureSuccessStatusCode();
        
        var responseGet = await _client.GetAsync("/api/products/1");
        Assert.Equal(HttpStatusCode.NotFound, responseGet.StatusCode);
    }
}    