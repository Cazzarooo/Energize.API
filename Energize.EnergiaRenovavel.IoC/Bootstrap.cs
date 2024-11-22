using Energize.API.Domain.Interfaces;
using Energize.EnergiaRenovavel.Application.Service;
using Energize.EnergiaRenovavel.Data.AppData;
using Energize.EnergiaRenovavel.Data.Repositories;
using Energize.EnergiaRenovavel.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Energize.EnergiaRenovavel.IoC
{
    public static class Bootstrap
    {
        public static void Start(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options => {
                options.UseOracle(configuration["ConnectionStrings:Oracle"]);
            });

            services.AddTransient<IEnderecoService, EnderecoService>();

            services.AddTransient<IEnergiaRenovavelRepository, EnergiaRenovavelRepository>();

            services.AddTransient<IEnergiaRenovavelApplicationService, EnergiaRenovavelApplicationService>();

        }
    }
}
