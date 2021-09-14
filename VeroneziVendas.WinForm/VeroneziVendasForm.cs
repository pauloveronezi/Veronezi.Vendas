﻿using System;
using System.IO;
using System.Windows.Forms;
using VeroneziVendas.Applications.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace VeroneziVendas.WinForm
{
    public partial class VeroneziVendasForm : Form
    {
        private readonly IArquivoService _ServiceArquivo;
        private readonly IDiretorioService _ServiceDiretorio;

        public VeroneziVendasForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _ServiceArquivo = serviceProvider.GetService<IArquivoService>();
            _ServiceDiretorio = serviceProvider.GetService<IDiretorioService>();
        }

        private void VeroneziVendasForm_Load(object sender, System.EventArgs e)
        {
            _ServiceDiretorio.Criar();
            watcherFiles.Path = $"{_ServiceDiretorio.Recuperar().FullName}\\.data\\in";
            InformarLocalArquivos();
        }

        private void watcherFiles_Created(object sender, FileSystemEventArgs e)
        {
            var _arquivo = _ServiceArquivo.Ler(e);
            _ServiceArquivo.Processar(_arquivo);
        }

        private void InformarLocalArquivos()
        {
            dgvIn.DataSource = _ServiceDiretorio.ListarArquivos("\\.data\\in");
            dgvOut.DataSource = _ServiceDiretorio.ListarArquivos("\\.data\\out");
            dgvError.DataSource = _ServiceDiretorio.ListarArquivos("\\.data\\error");
            dgvProcessed.DataSource = _ServiceDiretorio.ListarArquivos("\\.data\\processed");
        }
    }
}
