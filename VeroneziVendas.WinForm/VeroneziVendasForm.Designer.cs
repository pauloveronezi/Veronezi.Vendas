
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
            this.gboxIn = new System.Windows.Forms.GroupBox();
            this.dgvIn = new System.Windows.Forms.DataGridView();
            this.dgvOut = new System.Windows.Forms.DataGridView();
            this.gboxOut = new System.Windows.Forms.GroupBox();
            this.gboxError = new System.Windows.Forms.GroupBox();
            this.dgvError = new System.Windows.Forms.DataGridView();
            this.gboxProcessed = new System.Windows.Forms.GroupBox();
            this.dgvProcessed = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.watcherFiles)).BeginInit();
            this.gboxIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).BeginInit();
            this.gboxOut.SuspendLayout();
            this.gboxError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvError)).BeginInit();
            this.gboxProcessed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessed)).BeginInit();
            this.SuspendLayout();
            // 
            // watcherFiles
            // 
            this.watcherFiles.EnableRaisingEvents = true;
            this.watcherFiles.Filter = "*.txt";
            this.watcherFiles.SynchronizingObject = this;
            this.watcherFiles.Created += new System.IO.FileSystemEventHandler(this.watcherFiles_Created);
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
            this.dgvIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIn.Location = new System.Drawing.Point(6, 22);
            this.dgvIn.Name = "dgvIn";
            this.dgvIn.RowTemplate.Height = 25;
            this.dgvIn.Size = new System.Drawing.Size(438, 222);
            this.dgvIn.TabIndex = 0;
            // 
            // dgvOut
            // 
            this.dgvOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOut.Location = new System.Drawing.Point(6, 22);
            this.dgvOut.Name = "dgvOut";
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
            // gboxError
            // 
            this.gboxError.Controls.Add(this.dgvError);
            this.gboxError.Location = new System.Drawing.Point(12, 268);
            this.gboxError.Name = "gboxError";
            this.gboxError.Size = new System.Drawing.Size(450, 250);
            this.gboxError.TabIndex = 2;
            this.gboxError.TabStop = false;
            this.gboxError.Text = "Directory: ERROR";
            // 
            // dgvError
            // 
            this.dgvError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvError.Location = new System.Drawing.Point(6, 22);
            this.dgvError.Name = "dgvError";
            this.dgvError.RowTemplate.Height = 25;
            this.dgvError.Size = new System.Drawing.Size(438, 222);
            this.dgvError.TabIndex = 0;
            // 
            // gboxProcessed
            // 
            this.gboxProcessed.Controls.Add(this.dgvProcessed);
            this.gboxProcessed.Location = new System.Drawing.Point(468, 268);
            this.gboxProcessed.Name = "gboxProcessed";
            this.gboxProcessed.Size = new System.Drawing.Size(450, 250);
            this.gboxProcessed.TabIndex = 3;
            this.gboxProcessed.TabStop = false;
            this.gboxProcessed.Text = "Directory: PROCESSED";
            // 
            // dgvProcessed
            // 
            this.dgvProcessed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcessed.Location = new System.Drawing.Point(6, 22);
            this.dgvProcessed.Name = "dgvProcessed";
            this.dgvProcessed.RowTemplate.Height = 25;
            this.dgvProcessed.Size = new System.Drawing.Size(438, 222);
            this.dgvProcessed.TabIndex = 0;
            // 
            // VeroneziVendasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 527);
            this.Controls.Add(this.gboxProcessed);
            this.Controls.Add(this.gboxError);
            this.Controls.Add(this.gboxOut);
            this.Controls.Add(this.gboxIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VeroneziVendasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Veronezi.Vendas";
            this.Load += new System.EventHandler(this.VeroneziVendasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.watcherFiles)).EndInit();
            this.gboxIn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).EndInit();
            this.gboxOut.ResumeLayout(false);
            this.gboxError.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvError)).EndInit();
            this.gboxProcessed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.FileSystemWatcher watcherFiles;
        private System.Windows.Forms.GroupBox gboxIn;
        private System.Windows.Forms.GroupBox gboxProcessed;
        private System.Windows.Forms.DataGridView dgvProcessed;
        private System.Windows.Forms.GroupBox gboxError;
        private System.Windows.Forms.DataGridView dgvError;
        private System.Windows.Forms.GroupBox gboxOut;
        private System.Windows.Forms.DataGridView dgvOut;
        private System.Windows.Forms.DataGridView dgvIn;
    }
}

