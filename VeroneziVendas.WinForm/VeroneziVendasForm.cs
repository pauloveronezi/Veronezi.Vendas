using System;
using System.IO;
using System.Windows.Forms;
using VeroneziVendas.Applications.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;

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
            TimerFiles.Start();
            WatcherFiles.Path = $"{_ServiceDiretorio.Recuperar().FullName}\\.data\\in";
            WatcherFiles.EnableRaisingEvents = true;
        }

        private void WatcherFiles_Created(object sender, FileSystemEventArgs e)
        {
            Thread.Sleep(3000);
            var _arquivo = _ServiceArquivo.Ler(e);
            _ServiceArquivo.Processar(_arquivo);            
        }

        private void TimerFiles_Tick(object sender, EventArgs e)
        {
            InformarLocalArquivos();
        }

        private void InformarLocalArquivos()
        {
            dgvIn.DataSource = _ServiceDiretorio.ListarArquivos("\\.data\\in");
            dgvOut.DataSource = _ServiceDiretorio.ListarArquivos("\\.data\\out");
        }        
    }
}