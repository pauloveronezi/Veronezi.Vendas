using System.IO;

namespace VeroneziVendas.Applications.Interfaces
{
    public interface IDiretorioService
    {
        void Criar();

        DirectoryInfo Recuperar();
    }
}
