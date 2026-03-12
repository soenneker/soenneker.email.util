using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Email.Util.Abstract;
using Soenneker.ServiceBus.Transmitter.Registrars;

namespace Soenneker.Email.Util.Registrars;

/// <summary>
/// A utility to place emails on Service Bus
/// </summary>
public static class EmailUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IEmailUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddEmailUtilAsSingleton(this IServiceCollection services)
    {
        services.AddServiceBusTransmitterAsSingleton().TryAddSingleton<IEmailUtil, EmailUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IEmailUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddEmailUtilAsScoped(this IServiceCollection services)
    {
        services.AddServiceBusTransmitterAsScoped().TryAddScoped<IEmailUtil, EmailUtil>();

        return services;
    }
}