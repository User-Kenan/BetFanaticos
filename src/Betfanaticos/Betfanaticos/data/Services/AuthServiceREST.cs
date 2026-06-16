using Betfanaticos.data.models;
using Betfanaticos.data.Services;
using Betfanaticos.domain;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;

using System.Net.Http;
using System.Net.Http.Json;

public class AuthServiceREST : IAuthServiceRest
{
    private readonly HttpClient client;

    public AuthServiceREST(HttpClient client)
    {
        this.client = client;
        client.BaseAddress = new Uri("http://127.0.0.1:8000/");
    }

    public async Task<LoginResponse> Login(LoginRequest request)
    {
        var response = await client.PostAsJsonAsync("auth/login", request);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<LoginResponse>();
    }

    public async Task<UserResponse> Register(UserCreate request)
    {
        var response = await client.PostAsJsonAsync("auth/register", request);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<UserResponse>();
    }
}
