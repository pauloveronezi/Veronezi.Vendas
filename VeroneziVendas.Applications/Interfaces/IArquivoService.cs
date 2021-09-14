using System.IO;
using System.Threading.Tasks;
using VeroneziVendas.Domain.Models;

namespace VeroneziVendas.Applications.Interfaces
{
    public interface IArquivoService
    {
        Arquivo Ler(FileSystemEventArgs arquivo);

        Arquivo Salvar(Arquivo arquivo, string dataOut);

        Arquivo Processar(Arquivo arquivo);
    }
}
