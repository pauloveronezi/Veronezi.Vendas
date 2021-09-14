using System;
using System.Collections.Generic;
using System.IO;
using VeroneziVendas.Applications.Interfaces;

namespace VeroneziVendas.Applications.Services
{
    public class DiretorioService : IDiretorioService
    {
        private readonly DirectoryInfo _diretorio = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent;

        public DiretorioService(IServiceProvider serviceProvider)
        {

        }

        public void Criar()
        {
            var _diretorioData = $"{_diretorio.FullName}\\.data";
            var _diretorioIn = $"{_diretorio.FullName}\\.data\\in";
            var _diretorioOut = $"{_diretorio.FullName}\\.data\\out";
            var _diretorioError = $"{_diretorio.FullName}\\.data\\error";
            var _diretorioProcessed = $"{_diretorio.FullName}\\.data\\processed";

            if (!Directory.Exists(_diretorioData))
            {
                Directory.CreateDirectory(_diretorioData);
            }

            if (!Directory.Exists(_diretorioIn))
            {
                Directory.CreateDirectory(_diretorioIn);
            }

            if (!Directory.Exists(_diretorioOut))
            {
                Directory.CreateDirectory(_diretorioOut);
            }

            if (!Directory.Exists(_diretorioError))
            {
                Directory.CreateDirectory(_diretorioError);
            }

            if (!Directory.Exists(_diretorioProcessed))
            {
                Directory.CreateDirectory(_diretorioProcessed);
            }
        }

        public IEnumerable<string> ListarArquivos()
        {
            var _arquivosIn = Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent + "\\.data\\in");

            return _arquivosIn;
        }

        public DirectoryInfo Recuperar()
        {
            return _diretorio;
        }
    }
}
