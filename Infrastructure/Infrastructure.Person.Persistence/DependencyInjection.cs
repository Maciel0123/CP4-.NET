using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.Person.Domain.Abstractions;
using Infrastructure.Person.Persistence.Persistence;
using Infrastructure.Person.Persistence.Repositories;

namespace Infrastructure.Person.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration cfg)
        {
            var cs = cfg.GetConnectionString("OracleDb");
            if (string.IsNullOrWhiteSpace(cs))
                throw new InvalidOperationException("ConnectionStrings:OracleDb não configurada.");

            services.AddDbContext<PersonDbContext>(opt => opt.UseOracle(cs));
            services.AddScoped<IPersonRepository, PersonRepository>();
            return services;
        }
    }
}
