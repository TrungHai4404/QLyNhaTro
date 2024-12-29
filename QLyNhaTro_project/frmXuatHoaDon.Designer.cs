namespace QLyNhaTro_project
{
    partial class frmXuatHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rptViewerHoaDon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptViewerHoaDon
            // 
            this.rptViewerHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewerHoaDon.Location = new System.Drawing.Point(0, 0);
            this.rptViewerHoaDon.Name = "rptViewerHoaDon";
            this.rptViewerHoaDon.ServerReport.BearerToken = null;
            this.rptViewerHoaDon.Size = new System.Drawing.Size(1036, 649);
            this.rptViewerHoaDon.TabIndex = 0;
            // 
            // frmXuatHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 649);
            this.Controls.Add(this.rptViewerHoaDon);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmXuatHoaDon";
            this.Text = "frmXuatHoaDon";
            this.Load += new System.EventHandler(this.rptViewerHoaDon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptViewerHoaDon;
    }
}