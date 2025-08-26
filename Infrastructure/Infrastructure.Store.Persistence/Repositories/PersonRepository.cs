using Microsoft.EntityFrameworkCore;
using Core.Store.Domain.Abstractions;
using Core.Store.Domain.Entities;
using Infrastructure.Store.Persistence.Persistence;

namespace Infrastructure.Store.Persistence.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly StoreDbContext _ctx;
    public PersonRepository(StoreDbContext ctx) => _ctx = ctx;

    public async Task<IEnumerable<Person>> GetAllAsync(CancellationToken ct = default)
        => await _ctx.People.AsNoTracking().ToListAsync(ct);

    public async Task<Person?> GetByIdAsync(int id, CancellationToken ct = default)
        => await _ctx.People.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);

    public async Task AddAsync(Person entity, CancellationToken ct = default)
    {
        _ctx.People.Add(entity);
        await _ctx.SaveChangesAsync(ct);
    }
}
