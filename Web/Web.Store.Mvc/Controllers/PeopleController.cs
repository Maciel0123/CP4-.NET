using Microsoft.AspNetCore.Mvc;
using Shared.Store.Contracts.People;
using Web.Store.Mvc.Models;
using Web.Store.Mvc.Services;

namespace Web.Store.Mvc.Controllers;

public class PeopleController : Controller
{
    private readonly PeopleApiClient _people;
    private readonly CepApiClient _cep;

    public PeopleController(PeopleApiClient people, CepApiClient cep)
    {
        _people = people;
        _cep = cep;
    }

    public async Task<IActionResult> Index(string? cep, CancellationToken ct)
    {
        var people = await _people.GetAllAsync();
        var cepInfo = string.IsNullOrWhiteSpace(cep) ? null : await _cep.GetAsync(cep!, ct);
        return View(new PeopleIndexVm { People = people, Cep = cepInfo });
    }

    [HttpPost]
    public async Task<IActionResult> Create(string name, string email, string? cep, CancellationToken ct)
    {
        await _people.CreateAsync(new PersonDto(0, name, email, cep));
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult LookupCep(string cep)
        => RedirectToAction(nameof(Index), new { cep });
}
