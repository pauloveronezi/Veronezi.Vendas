using System.Data;
using System.IO;

namespace VeroneziVendas.Applications.Interfaces
{
    public interface IDiretorioService
    {
        void Criar();

        DirectoryInfo Recuperar();

        DataTable ListarArquivos(string complementoDiretorio);
    }
}
