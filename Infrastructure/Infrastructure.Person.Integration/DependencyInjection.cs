using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;

namespace Infrastructure.Person.Integration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIntegration(this IServiceCollection services)
        {
            services.AddHttpClient("viacep", c =>
            {
                c.BaseAddress = new Uri("https://viacep.com.br/");
                c.Timeout = TimeSpan.FromSeconds(10);
            })
            .AddPolicyHandler(HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, attempt => TimeSpan.FromMilliseconds(200 * attempt)))
            .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(5)));

            return services;
        }
    }
}
