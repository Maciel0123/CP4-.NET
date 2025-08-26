using Shared.Store.Contracts.Cep;
using System.Net.Http.Json;

namespace Web.Store.Mvc.Services;

public class CepApiClient
{
    private readonly HttpClient _http;
    public CepApiClient(HttpClient http) => _http = http;

    public async Task<CepDto?> GetAsync(string cep, CancellationToken ct = default)
        => await _http.GetFromJsonAsync<CepDto>($"api/cep/{cep}", ct);
}
