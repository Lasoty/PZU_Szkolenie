using DeskBooking.Services.StatisticsServices;
using Microsoft.Extensions.DependencyInjection;

namespace DeskBooking.Services.Common
{
    public static class RegisterServicesExtension
    {
        /// <summary>
        /// Rejestracja klas logiki biznesowej aplikacji
        /// </summary>
        /// <param name="services">Kontener klas (IoC)</param>
        /// <returns>Zwraca obiekt <see cref="IServiceCollection"/></returns>
        public static IServiceCollection RegisterDeskBookingServices(this IServiceCollection services)
        {
            services.AddScoped<IStatisticsService, StatisticsService>();

            return services;
        }
    }
}
