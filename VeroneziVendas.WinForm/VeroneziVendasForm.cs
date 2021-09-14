using System.IO;
using System.Windows.Forms;
using VeroneziVendas.Applications.Interfaces;

namespace VeroneziVendas.WinForm
{
    public partial class VeroneziVendasForm : Form
    {
        private readonly IDiretorioService _ServiceDiretorio;

        public VeroneziVendasForm(IDiretorioService diretorioService)
        {
            InitializeComponent();
            
            _ServiceDiretorio = diretorioService;
        }

        private void VeroneziVendasForm_Load(object sender, System.EventArgs e)
        {
            var _teste = _ServiceDiretorio.Recuperar();
        }

        private void watcherFiles_Created(object sender, FileSystemEventArgs e)
        {
            throw new System.NotSupportedException();
        }

        private void watcherFiles_Changed(object sender, FileSystemEventArgs e)
        {
            throw new System.NotSupportedException();
        }        
    }
}
