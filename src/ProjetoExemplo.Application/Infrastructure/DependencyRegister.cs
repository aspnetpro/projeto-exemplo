using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoExemplo.Application.Infrastructure.Data;

namespace ProjetoExemplo.Application.Infrastructure;

public static class DependencyRegister
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfigurationManager configuration)
    {
        services.AddTransient<IDbContext, MssqlDbContext>((context) =>
        {
            var connString = configuration.GetConnectionString("MSSQL"); ;
            return new MssqlDbContext(connString);
        });

        return services;
    }
}
