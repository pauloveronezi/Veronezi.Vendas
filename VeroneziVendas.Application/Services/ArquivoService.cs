using System.IO;
using System.Linq;
using VeroneziVendas.Application.Interfaces;

namespace VeroneziVendas.Application.Services
{
    public class ArquivoService : IArquivoService
    {
        public void Ler(string arquivo)
        {
            var _linhasArquivo = File.ReadAllLines(arquivo);

            foreach (var _linha in _linhasArquivo)
            {
                var _teste = _linha.Split("ç").ToList();
            }
        }
    }
