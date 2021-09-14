using System.Collections.Generic;
using System.IO;
using VeroneziVendas.Domain.Models;

namespace VeroneziVendas.Applications.Interfaces
{
    public interface IDiretorioService
    {
        void Criar();

        DirectoryInfo Recuperar();

        List<string> ListarArquivos(string complementoDiretorio);
    }
}
