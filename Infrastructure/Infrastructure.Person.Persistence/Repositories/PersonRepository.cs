using Microsoft.EntityFrameworkCore;
using Core.Person.Domain.Abstractions;
using Infrastructure.Person.Persistence.Persistence;
// Alias para a entidade
using PersonEntity = Core.Person.Domain.Entities.Person;

namespace Infrastructure.Person.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _ctx;
        public PersonRepository(PersonDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<PersonEntity>> GetAllAsync(CancellationToken ct = default)
            => await _ctx.People.AsNoTracking().ToListAsync(ct);

        public async Task<PersonEntity?> GetByIdAsync(int id, CancellationToken ct = default)
            => await _ctx.People.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);

        public async Task AddAsync(PersonEntity entity, CancellationToken ct = default)
        {
            _ctx.People.Add(entity);
            await _ctx.SaveChangesAsync(ct);
        }
    }
}
