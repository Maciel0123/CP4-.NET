using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Web.Person.Api.Cep.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CepController : ControllerBase
{
    private readonly IHttpClientFactory _factory;
    public CepController(IHttpClientFactory factory) => _factory = factory;

    [HttpGet("{cep}")]
    public async Task<IActionResult> Get(string cep, CancellationToken ct)
    {
        var client = _factory.CreateClient("viacep");
        var dto = await client.GetFromJsonAsync<object>($"ws/{cep}/json/", ct);
        return Ok(dto);
    }
}
