using Core.Person.Domain.Abstractions;
using Shared.Person.Contracts.People;

namespace Core.Person.Application.UseCases.People;

public class GetAllPeople
{
    private readonly IPersonRepository _repo;
    public GetAllPeople(IPersonRepository repo) => _repo = repo;

    public async Task<IEnumerable<PersonDto>> Handle(CancellationToken ct = default)
        => (await _repo.GetAllAsync(ct))
            .Select(p => new PersonDto(p.Id, p.Name, p.Email, p.Cep));
}
