
namespace VeroneziVendas.WinForm
{
    partial class VeroneziVendasForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.watcherFiles = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.watcherFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // watcherFiles
            // 
            this.watcherFiles.EnableRaisingEvents = true;
            this.watcherFiles.Filter = "*.txt";
            this.watcherFiles.SynchronizingObject = this;
            // 
            // VeroneziVendasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 579);
            this.Name = "VeroneziVendasForm";
            this.Text = "Veronezi.Vendas";
            this.Load += new System.EventHandler(this.VeroneziVendasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.watcherFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.FileSystemWatcher watcherFiles;
    }
}

