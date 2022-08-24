using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Euri_backend.Testing.Utilities;

public static class TestExtensions
{
    public static async Task<T?> GetFromJsonWithOptionsAsync<T>(this HttpClient client, string url)
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new JsonStringEnumConverter());
        return await client.GetFromJsonAsync<T>(url, options: options);
    }
}