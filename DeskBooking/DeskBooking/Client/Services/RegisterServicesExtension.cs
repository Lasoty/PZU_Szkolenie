using Microsoft.Extensions.DependencyInjection;

namespace DeskBooking.Client.Services
{
    public static class RegisterServicesExtension
    {
        /// <summary>
        /// Rejestracja klas logiki biznesowej aplikacji
        /// </summary>
        /// <param name="services">Kontener klas (IoC)</param>
        /// <returns>Zwraca obiekt <see cref="IServiceCollection"/></returns>
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IStatisticsProvider, StatisticsProvider>();
            services.AddScoped<IDeskDataProvider, DeskDataProvider>();

            return services;
        }
    }
}
