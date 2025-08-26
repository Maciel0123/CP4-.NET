using Shared.Person.Contracts.People;
using System.Net.Http.Json;

namespace Web.Person.Mvc.Services;

public class PeopleApiClient
{
    private readonly HttpClient _http;
    public PeopleApiClient(HttpClient http) => _http = http;

    public async Task<IEnumerable<PersonDto>> GetAllAsync()
        => await _http.GetFromJsonAsync<IEnumerable<PersonDto>>("api/people") ?? [];

    public async Task CreateAsync(PersonDto dto)
        => await _http.PostAsJsonAsync("api/people", dto);
}
