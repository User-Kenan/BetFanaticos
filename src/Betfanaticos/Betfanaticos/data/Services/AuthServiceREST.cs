using Betfanaticos.data.models;
using Betfanaticos.data.Services;
using Betfanaticos.domain;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;

using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Betfanaticos.UI;

public class AuthServiceREST : IAuthServiceRest
{
    private readonly HttpClient client;

    public AuthServiceREST(HttpClient client)
    {
        this.client = client;
    }


    // Prompt: schreibe mir ein endpunkt wo meine http exceptions in wpf angezeigt werden
    private string ParseFastApiError(string content)
    {
        try
        {
            var json = JsonDocument.Parse(content); 
            var root = json.RootElement;

            if (root.TryGetProperty("detail", out var detail))
            {
                if (detail.ValueKind == JsonValueKind.String)
                    return detail.GetString();

                if (detail.ValueKind == JsonValueKind.Array)
                    return detail[0].GetProperty("msg").GetString();
            }
        }
        catch { }

        return content;
    }
    

    public async Task<LoginResponse> Login(LoginRequest request)
    {
        var response = await client.PostAsJsonAsync("auth/login", request);

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception(ParseFastApiError(content));

        return JsonSerializer.Deserialize<LoginResponse>(content)!;
    }


    public async Task<UserResponse> Register(UserCreate request)
    {
        var response = await client.PostAsJsonAsync("auth/register", request);

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception(ParseFastApiError(content));

        return JsonSerializer.Deserialize<UserResponse>(content)!;
    }

    
}
