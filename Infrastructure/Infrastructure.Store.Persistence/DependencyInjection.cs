using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.Store.Domain.Abstractions;
using Infrastructure.Store.Persistence.Persistence;
using Infrastructure.Store.Persistence.Repositories;

namespace Infrastructure.Store.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration cfg)
    {
        var cs = cfg.GetConnectionString("OracleDb");
        services.AddDbContext<StoreDbContext>(opt => opt.UseOracle(cs));
        services.AddScoped<IPersonRepository, PersonRepository>();
        return services;
    }
}
