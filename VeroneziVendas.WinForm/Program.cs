using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using VeroneziVendas.WinForm.Configurations;

namespace VeroneziVendas.WinForm
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices.AddConfigurationIoC(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var _formulario = serviceProvider.GetRequiredService<VeroneziVendasForm>();
                Application.Run(_formulario);
            }            
        }
    }
}
