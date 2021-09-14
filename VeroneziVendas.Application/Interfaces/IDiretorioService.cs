using System.IO;

namespace VeroneziVendas.Application.Interfaces
{
    public interface IDiretorioService
    {
        void Criar();

        DirectoryInfo Recuperar();
    }
}
