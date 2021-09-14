using System;
using System.Data;
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

        public DataTable ListarArquivos(string complementoDiretorio)
        {
            var _dataTable = new DataTable();
            _dataTable.Columns.Add("Name");
            var _arquivos = Directory.GetFiles($"{_diretorio}{complementoDiretorio}");

            for (int i = 0; i < _arquivos.Length; i++)
            {
                FileInfo _file = new FileInfo(_arquivos[i]);
                var _linhaDataTable = _dataTable.NewRow();
                _linhaDataTable[0] = _file.Name;
                _dataTable.Rows.Add(_linhaDataTable);
            }

            return _dataTable;
        }

        public DirectoryInfo Recuperar()
        {
            return _diretorio;
        }
    }
}
