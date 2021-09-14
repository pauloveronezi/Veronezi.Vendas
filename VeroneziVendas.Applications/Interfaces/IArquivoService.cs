using System.IO;
using VeroneziVendas.Domain.Models;

namespace VeroneziVendas.Applications.Interfaces
{
    public interface IArquivoService
    {
        Arquivo Ler(FileSystemEventArgs arquivo);

        void Processar(Arquivo arquivo);
    }
}
