using Microsoft.Extensions.DependencyInjection;
using VeroneziVendas.Applications.Interfaces;
using VeroneziVendas.Applications.Services;

namespace VeroneziVendas.WinForm.Configurations
{
    public static class ConfigureServices
    {
        public static void AddConfigurationIoC(this IServiceCollection services)//, IConfiguration configuration)
        {
            services.AddScoped<VeroneziVendasForm>();

            services.AddScoped<IArquivoService, ArquivoService>();
            services.AddScoped<IDiretorioService, DiretorioService>();            
        }
    }
}
