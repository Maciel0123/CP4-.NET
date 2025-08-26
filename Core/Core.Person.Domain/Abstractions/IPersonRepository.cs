using PersonEntity = Core.Person.Domain.Entities.Person;

namespace Core.Person.Domain.Abstractions;

public interface IPersonRepository
{
    Task<IEnumerable<PersonEntity>> GetAllAsync(CancellationToken ct = default);
    Task<PersonEntity?> GetByIdAsync(int id, CancellationToken ct = default);
    Task AddAsync(PersonEntity entity, CancellationToken ct = default);
}
