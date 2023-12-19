using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoExemplo.Application.Modules.Tickets.Services;

namespace ProjetoExemplo.Application.Modules;

public static class DependencyRegister
{
    public static IServiceCollection AddModule(this IServiceCollection services)
    {
        // auth

        // tickets
        services.AddTransient<ICreateNewTicket, CreateNewTicket>();

        return services;
    }
}
