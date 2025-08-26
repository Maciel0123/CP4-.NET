using Core.Store.Domain.Entities;

namespace Core.Store.Domain.Abstractions;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> GetAllAsync(CancellationToken ct = default);
    Task<Person?> GetByIdAsync(int id, CancellationToken ct = default);
    Task AddAsync(Person entity, CancellationToken ct = default);
}
