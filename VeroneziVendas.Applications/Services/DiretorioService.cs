using System;
using System.Collections.Generic;
using System.IO;
using VeroneziVendas.Applications.Interfaces;
using VeroneziVendas.Domain.Models;

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

        public List<string> ListarArquivos(string complementoDiretorio)
        {
            var _arquivos = new List<string>();

            foreach (var arquivo in new DirectoryInfo($"{_diretorio}{complementoDiretorio}").GetFiles())
            {
                _arquivos.Add(arquivo.Name);
            }

            return _arquivos;
        }

        public DirectoryInfo Recuperar()
        {
            return _diretorio;
        }
    }
}
