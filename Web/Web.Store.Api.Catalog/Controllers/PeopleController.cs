using Microsoft.AspNetCore.Mvc;
using Core.Store.Application.UseCases.People;
using Shared.Store.Contracts.People;

namespace Web.Store.Api.Catalog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromServices] GetAllPeople useCase, CancellationToken ct)
        => Ok(await useCase.Handle(ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromServices] CreatePerson useCase, PersonDto dto, CancellationToken ct)
        => Created("", await useCase.Handle(dto, ct));
}
