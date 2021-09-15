using Microsoft.Extensions.DependencyInjection;
using VeroneziVendas.Applications.Interfaces;
using VeroneziVendas.Applications.Services;

namespace VeroneziVendas.WinForm.Configurations
{
    public static class ConfigureServices
    {
        public static void AddConfigurationIoC(this IServiceCollection services)
        {
            services.AddScoped<VeroneziVendasForm>();

            services.AddScoped<IArquivoService, ArquivoService>();
            services.AddScoped<IDiretorioService, DiretorioService>();
            services.AddScoped<IDiretorioService, DiretorioService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IVendedorService, VendedorService>();
            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IItemService, ItemService>();
        }
    }
}
