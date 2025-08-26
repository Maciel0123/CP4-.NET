using Shared.Store.Contracts.People;
using Shared.Store.Contracts.Cep;

namespace Web.Store.Mvc.Models;

public class PeopleIndexVm
{
    public IEnumerable<PersonDto> People { get; init; } = Enumerable.Empty<PersonDto>();
    public CepDto? Cep { get; init; }
}
