using Core.Store.Domain.Abstractions;
using Core.Store.Domain.Entities;
using Shared.Store.Contracts.People;
using System.Text.RegularExpressions;

namespace Core.Store.Application.UseCases.People;

public class CreatePerson
{
    private readonly IPersonRepository _repo;
    public CreatePerson(IPersonRepository repo) => _repo = repo;

    public async Task<PersonDto> Handle(PersonDto dto, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))  throw new ArgumentException("Name obrigatório");
        if (string.IsNullOrWhiteSpace(dto.Email)) throw new ArgumentException("Email obrigatório");

        // Normaliza CEP: remove não-dígitos e valida 8 dígitos
        string? cep = dto.Cep;
        if (!string.IsNullOrWhiteSpace(cep))
        {
            cep = Regex.Replace(cep, "[^0-9]", "");
            if (cep.Length != 8) throw new ArgumentException("CEP deve ter 8 dígitos");
        }

        var entity = new Person { Id = dto.Id, Name = dto.Name, Email = dto.Email, Cep = cep };
        await _repo.AddAsync(entity, ct);

        return new PersonDto(entity.Id, entity.Name, entity.Email, entity.Cep);
    }
}
