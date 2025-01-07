namespace QLyNhaTro_project
{
    partial class frmThongKeDoanhThu
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
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.btnDTNam = new System.Windows.Forms.Button();
            this.btnDTQuy = new System.Windows.Forms.Button();
            this.btnDTThang = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.AllowUserToAddRows = false;
            this.dgvDoanhThu.AllowUserToDeleteRows = false;
            this.dgvDoanhThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoanhThu.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDoanhThu.Location = new System.Drawing.Point(84, 352);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.ReadOnly = true;
            this.dgvDoanhThu.RowHeadersVisible = false;
            this.dgvDoanhThu.RowHeadersWidth = 51;
            this.dgvDoanhThu.RowTemplate.Height = 24;
            this.dgvDoanhThu.Size = new System.Drawing.Size(803, 213);
            this.dgvDoanhThu.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(259, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(463, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "THỐNG KÊ DOANH THU";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbNam);
            this.panel1.Controls.Add(this.btnDTNam);
            this.panel1.Controls.Add(this.btnDTQuy);
            this.panel1.Controls.Add(this.btnDTThang);
            this.panel1.Location = new System.Drawing.Point(173, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 188);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(266, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Năm";
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(240, 143);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(121, 24);
            this.cmbNam.TabIndex = 1;
            // 
            // btnDTNam
            // 
            this.btnDTNam.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnDTNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDTNam.Location = new System.Drawing.Point(457, 19);
            this.btnDTNam.Name = "btnDTNam";
            this.btnDTNam.Size = new System.Drawing.Size(109, 103);
            this.btnDTNam.TabIndex = 0;
            this.btnDTNam.Text = "Doanh thu theo năm";
            this.btnDTNam.UseVisualStyleBackColor = false;
            this.btnDTNam.Click += new System.EventHandler(this.btnDTNam_Click);
            // 
            // btnDTQuy
            // 
            this.btnDTQuy.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnDTQuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDTQuy.Location = new System.Drawing.Point(255, 19);
            this.btnDTQuy.Name = "btnDTQuy";
            this.btnDTQuy.Size = new System.Drawing.Size(106, 89);
            this.btnDTQuy.TabIndex = 0;
            this.btnDTQuy.Text = "Doanh thu theo quý";
            this.btnDTQuy.UseVisualStyleBackColor = false;
            this.btnDTQuy.Click += new System.EventHandler(this.btnDTQuy_Click);
            // 
            // btnDTThang
            // 
            this.btnDTThang.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnDTThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDTThang.Location = new System.Drawing.Point(54, 19);
            this.btnDTThang.Name = "btnDTThang";
            this.btnDTThang.Size = new System.Drawing.Size(108, 103);
            this.btnDTThang.TabIndex = 0;
            this.btnDTThang.Text = "Doanh thu theo tháng";
            this.btnDTThang.UseVisualStyleBackColor = false;
            this.btnDTThang.Click += new System.EventHandler(this.btnDTThang_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(339, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "BẢNG DOANH THU";
            // 
            // frmThongKeDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(978, 589);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDoanhThu);
            this.MaximizeBox = false;
            this.Name = "frmThongKeDoanhThu";
            this.Text = "Thống kê doanh thu";
            this.Load += new System.EventHandler(this.frmThongKeDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDTNam;
        private System.Windows.Forms.Button btnDTQuy;
        private System.Windows.Forms.Button btnDTThang;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}