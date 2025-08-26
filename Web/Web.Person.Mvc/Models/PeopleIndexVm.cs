using Shared.Person.Contracts.People;
using Shared.Person.Contracts.Cep;

namespace Web.Person.Mvc.Models;

public class PeopleIndexVm
{
    public IEnumerable<PersonDto> People { get; init; } = Enumerable.Empty<PersonDto>();
    public CepDto? Cep { get; init; }
}
