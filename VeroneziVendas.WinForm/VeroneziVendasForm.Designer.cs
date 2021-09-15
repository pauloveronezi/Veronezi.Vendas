
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
            this.components = new System.ComponentModel.Container();
            this.WatcherFiles = new System.IO.FileSystemWatcher();
            this.gboxIn = new System.Windows.Forms.GroupBox();
            this.dgvIn = new System.Windows.Forms.DataGridView();
            this.dgvOut = new System.Windows.Forms.DataGridView();
            this.gboxOut = new System.Windows.Forms.GroupBox();
            this.TimerFiles = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.WatcherFiles)).BeginInit();
            this.gboxIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).BeginInit();
            this.gboxOut.SuspendLayout();
            this.SuspendLayout();
            // 
            // WatcherFiles
            // 
            this.WatcherFiles.EnableRaisingEvents = true;
            this.WatcherFiles.Filter = "*.txt";
            this.WatcherFiles.SynchronizingObject = this;
            this.WatcherFiles.Created += new System.IO.FileSystemEventHandler(this.WatcherFiles_Created);
            // 
            // gboxIn
            // 
            this.gboxIn.Controls.Add(this.dgvIn);
            this.gboxIn.Location = new System.Drawing.Point(12, 12);
            this.gboxIn.Name = "gboxIn";
            this.gboxIn.Size = new System.Drawing.Size(450, 250);
            this.gboxIn.TabIndex = 0;
            this.gboxIn.TabStop = false;
            this.gboxIn.Text = "Directory: IN";
            // 
            // dgvIn
            // 
            this.dgvIn.AllowUserToAddRows = false;
            this.dgvIn.AllowUserToDeleteRows = false;
            this.dgvIn.AllowUserToResizeColumns = false;
            this.dgvIn.AllowUserToResizeRows = false;
            this.dgvIn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIn.ColumnHeadersVisible = false;
            this.dgvIn.Location = new System.Drawing.Point(6, 22);
            this.dgvIn.Name = "dgvIn";
            this.dgvIn.ReadOnly = true;
            this.dgvIn.RowHeadersVisible = false;
            this.dgvIn.RowTemplate.Height = 25;
            this.dgvIn.Size = new System.Drawing.Size(438, 222);
            this.dgvIn.TabIndex = 0;
            // 
            // dgvOut
            // 
            this.dgvOut.AllowUserToAddRows = false;
            this.dgvOut.AllowUserToDeleteRows = false;
            this.dgvOut.AllowUserToResizeColumns = false;
            this.dgvOut.AllowUserToResizeRows = false;
            this.dgvOut.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOut.ColumnHeadersVisible = false;
            this.dgvOut.Location = new System.Drawing.Point(6, 22);
            this.dgvOut.Name = "dgvOut";
            this.dgvOut.ReadOnly = true;
            this.dgvOut.RowHeadersVisible = false;
            this.dgvOut.RowTemplate.Height = 25;
            this.dgvOut.Size = new System.Drawing.Size(438, 222);
            this.dgvOut.TabIndex = 0;
            // 
            // gboxOut
            // 
            this.gboxOut.Controls.Add(this.dgvOut);
            this.gboxOut.Location = new System.Drawing.Point(468, 12);
            this.gboxOut.Name = "gboxOut";
            this.gboxOut.Size = new System.Drawing.Size(450, 250);
            this.gboxOut.TabIndex = 1;
            this.gboxOut.TabStop = false;
            this.gboxOut.Text = "Directory: OUT";
            // 
            // TimerFiles
            // 
            this.TimerFiles.Interval = 3000;
            this.TimerFiles.Tick += new System.EventHandler(this.TimerFiles_Tick);
            // 
            // VeroneziVendasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 269);
            this.Controls.Add(this.gboxOut);
            this.Controls.Add(this.gboxIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VeroneziVendasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Veronezi.Vendas";
            this.Load += new System.EventHandler(this.VeroneziVendasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WatcherFiles)).EndInit();
            this.gboxIn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).EndInit();
            this.gboxOut.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.FileSystemWatcher WatcherFiles;
        private System.Windows.Forms.GroupBox gboxIn;
        private System.Windows.Forms.GroupBox gboxOut;
        private System.Windows.Forms.DataGridView dgvOut;
        private System.Windows.Forms.DataGridView dgvIn;
        private System.Windows.Forms.Timer TimerFiles;
    }
}

