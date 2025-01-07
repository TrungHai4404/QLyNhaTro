namespace QLyNhaTro_project
{
    partial class frmQLyKhach
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
            this.components = new System.ComponentModel.Container();
            this.gbDanhSachPhongTro = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSoPhong = new System.Windows.Forms.ComboBox();
            this.cmbLoaiPhong = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvDSKhachThue = new System.Windows.Forms.DataGridView();
            this.tenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maKhach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbThemKhach = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.radNu = new System.Windows.Forms.RadioButton();
            this.radNam = new System.Windows.Forms.RadioButton();
            this.btnLoadImg = new System.Windows.Forms.Button();
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.ngayThue = new System.Windows.Forms.DateTimePicker();
            this.ngaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThemKhachThue = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBoxTimKiem = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDanhSachPhongTro.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKhachThue)).BeginInit();
            this.gbThemKhach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBoxTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDanhSachPhongTro
            // 
            this.gbDanhSachPhongTro.BackColor = System.Drawing.Color.LightGreen;
            this.gbDanhSachPhongTro.Controls.Add(this.label4);
            this.gbDanhSachPhongTro.Controls.Add(this.label2);
            this.gbDanhSachPhongTro.Controls.Add(this.cmbSoPhong);
            this.gbDanhSachPhongTro.Controls.Add(this.cmbLoaiPhong);
            this.gbDanhSachPhongTro.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDanhSachPhongTro.Location = new System.Drawing.Point(12, 37);
            this.gbDanhSachPhongTro.Name = "gbDanhSachPhongTro";
            this.gbDanhSachPhongTro.Size = new System.Drawing.Size(266, 140);
            this.gbDanhSachPhongTro.TabIndex = 3;
            this.gbDanhSachPhongTro.TabStop = false;
            this.gbDanhSachPhongTro.Text = "Danh sách phòng trọ";
            this.gbDanhSachPhongTro.Paint += new System.Windows.Forms.PaintEventHandler(this.gbDanhSachPhongTro_Paint_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Số Phòng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loại Phòng:";
            // 
            // cmbSoPhong
            // 
            this.cmbSoPhong.FormattingEnabled = true;
            this.cmbSoPhong.Location = new System.Drawing.Point(130, 83);
            this.cmbSoPhong.Name = "cmbSoPhong";
            this.cmbSoPhong.Size = new System.Drawing.Size(124, 24);
            this.cmbSoPhong.TabIndex = 0;
            this.cmbSoPhong.SelectedIndexChanged += new System.EventHandler(this.cmbSoPhong_SelectedIndexChanged);
            // 
            // cmbLoaiPhong
            // 
            this.cmbLoaiPhong.FormattingEnabled = true;
            this.cmbLoaiPhong.Location = new System.Drawing.Point(130, 39);
            this.cmbLoaiPhong.Name = "cmbLoaiPhong";
            this.cmbLoaiPhong.Size = new System.Drawing.Size(124, 24);
            this.cmbLoaiPhong.TabIndex = 0;
            this.cmbLoaiPhong.SelectedIndexChanged += new System.EventHandler(this.cmbLoaiPhong_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvDSKhachThue);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 352);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(926, 233);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Danh sách khách thuê";
            // 
            // dgvDSKhachThue
            // 
            this.dgvDSKhachThue.AllowUserToAddRows = false;
            this.dgvDSKhachThue.AllowUserToDeleteRows = false;
            this.dgvDSKhachThue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSKhachThue.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDSKhachThue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSKhachThue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tenPhong,
            this.maKhach,
            this.hoTen,
            this.ID,
            this.diaChi,
            this.gioiTinh});
            this.dgvDSKhachThue.Location = new System.Drawing.Point(6, 21);
            this.dgvDSKhachThue.Name = "dgvDSKhachThue";
            this.dgvDSKhachThue.ReadOnly = true;
            this.dgvDSKhachThue.RowHeadersVisible = false;
            this.dgvDSKhachThue.RowHeadersWidth = 51;
            this.dgvDSKhachThue.RowTemplate.Height = 24;
            this.dgvDSKhachThue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSKhachThue.Size = new System.Drawing.Size(920, 212);
            this.dgvDSKhachThue.TabIndex = 3;
            this.dgvDSKhachThue.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSKhachThue_CellContentClick);
            // 
            // tenPhong
            // 
            this.tenPhong.HeaderText = "Tên Phòng";
            this.tenPhong.MinimumWidth = 6;
            this.tenPhong.Name = "tenPhong";
            this.tenPhong.ReadOnly = true;
            // 
            // maKhach
            // 
            this.maKhach.HeaderText = "Mã Khách";
            this.maKhach.MinimumWidth = 6;
            this.maKhach.Name = "maKhach";
            this.maKhach.ReadOnly = true;
            // 
            // hoTen
            // 
            this.hoTen.HeaderText = "Họ Tên";
            this.hoTen.MinimumWidth = 6;
            this.hoTen.Name = "hoTen";
            this.hoTen.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.HeaderText = "CCCD/CMND";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // diaChi
            // 
            this.diaChi.HeaderText = "Địa Chỉ";
            this.diaChi.MinimumWidth = 6;
            this.diaChi.Name = "diaChi";
            this.diaChi.ReadOnly = true;
            // 
            // gioiTinh
            // 
            this.gioiTinh.HeaderText = "Giới Tính";
            this.gioiTinh.MinimumWidth = 6;
            this.gioiTinh.Name = "gioiTinh";
            this.gioiTinh.ReadOnly = true;
            // 
            // gbThemKhach
            // 
            this.gbThemKhach.BackColor = System.Drawing.Color.OldLace;
            this.gbThemKhach.Controls.Add(this.radNu);
            this.gbThemKhach.Controls.Add(this.radNam);
            this.gbThemKhach.Controls.Add(this.btnLoadImg);
            this.gbThemKhach.Controls.Add(this.Avatar);
            this.gbThemKhach.Controls.Add(this.ngayThue);
            this.gbThemKhach.Controls.Add(this.ngaySinh);
            this.gbThemKhach.Controls.Add(this.txtDiaChi);
            this.gbThemKhach.Controls.Add(this.textBox6);
            this.gbThemKhach.Controls.Add(this.txtSDT);
            this.gbThemKhach.Controls.Add(this.txtCMND);
            this.gbThemKhach.Controls.Add(this.txtHoTen);
            this.gbThemKhach.Controls.Add(this.label8);
            this.gbThemKhach.Controls.Add(this.label5);
            this.gbThemKhach.Controls.Add(this.label7);
            this.gbThemKhach.Controls.Add(this.label10);
            this.gbThemKhach.Controls.Add(this.label6);
            this.gbThemKhach.Controls.Add(this.label9);
            this.gbThemKhach.Controls.Add(this.label3);
            this.gbThemKhach.Location = new System.Drawing.Point(401, 37);
            this.gbThemKhach.Name = "gbThemKhach";
            this.gbThemKhach.Size = new System.Drawing.Size(537, 284);
            this.gbThemKhach.TabIndex = 5;
            this.gbThemKhach.TabStop = false;
            this.gbThemKhach.Text = "Thêm khách thuê";
            this.gbThemKhach.Paint += new System.Windows.Forms.PaintEventHandler(this.gbThemKhach_Paint);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLamMoi.Location = new System.Drawing.Point(837, 327);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(101, 28);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // radNu
            // 
            this.radNu.AutoSize = true;
            this.radNu.Location = new System.Drawing.Point(193, 180);
            this.radNu.Name = "radNu";
            this.radNu.Size = new System.Drawing.Size(45, 20);
            this.radNu.TabIndex = 5;
            this.radNu.TabStop = true;
            this.radNu.Text = "Nữ";
            this.radNu.UseVisualStyleBackColor = true;
            // 
            // radNam
            // 
            this.radNam.AutoSize = true;
            this.radNam.Location = new System.Drawing.Point(100, 180);
            this.radNam.Name = "radNam";
            this.radNam.Size = new System.Drawing.Size(57, 20);
            this.radNam.TabIndex = 5;
            this.radNam.TabStop = true;
            this.radNam.Text = "Nam";
            this.radNam.UseVisualStyleBackColor = true;
            // 
            // btnLoadImg
            // 
            this.btnLoadImg.Location = new System.Drawing.Point(413, 167);
            this.btnLoadImg.Name = "btnLoadImg";
            this.btnLoadImg.Size = new System.Drawing.Size(75, 23);
            this.btnLoadImg.TabIndex = 4;
            this.btnLoadImg.Text = "Chọn ảnh";
            this.btnLoadImg.UseVisualStyleBackColor = true;
            this.btnLoadImg.Click += new System.EventHandler(this.btnLoadImg_Click);
            // 
            // Avatar
            // 
            this.Avatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Avatar.Location = new System.Drawing.Point(272, 113);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(135, 135);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Avatar.TabIndex = 3;
            this.Avatar.TabStop = false;
            // 
            // ngayThue
            // 
            this.ngayThue.CustomFormat = "dd/MM/yyyy";
            this.ngayThue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngayThue.Location = new System.Drawing.Point(346, 79);
            this.ngayThue.MaxDate = new System.DateTime(2030, 12, 25, 0, 0, 0, 0);
            this.ngayThue.MinDate = new System.DateTime(1890, 1, 1, 0, 0, 0, 0);
            this.ngayThue.Name = "ngayThue";
            this.ngayThue.Size = new System.Drawing.Size(141, 22);
            this.ngayThue.TabIndex = 2;
            this.ngayThue.Value = new System.DateTime(2024, 12, 25, 0, 0, 0, 0);
            // 
            // ngaySinh
            // 
            this.ngaySinh.CustomFormat = "dd/MM/yyyy";
            this.ngaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngaySinh.Location = new System.Drawing.Point(100, 80);
            this.ngaySinh.MaxDate = new System.DateTime(2030, 12, 25, 0, 0, 0, 0);
            this.ngaySinh.MinDate = new System.DateTime(1890, 1, 1, 0, 0, 0, 0);
            this.ngaySinh.Name = "ngaySinh";
            this.ngaySinh.Size = new System.Drawing.Size(138, 22);
            this.ngaySinh.TabIndex = 2;
            this.ngaySinh.Value = new System.DateTime(2024, 12, 25, 0, 0, 0, 0);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(346, 31);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(141, 22);
            this.txtDiaChi.TabIndex = 1;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(346, 31);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(141, 22);
            this.textBox6.TabIndex = 1;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(97, 226);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(144, 22);
            this.txtSDT.TabIndex = 1;
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(97, 132);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(141, 22);
            this.txtCMND.TabIndex = 1;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(97, 35);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(141, 22);
            this.txtHoTen.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "SĐT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ngày Sinh";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Giới tính";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(272, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Ngày thuê";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "CCCD";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(269, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Họ Tên";
            // 
            // btnThemKhachThue
            // 
            this.btnThemKhachThue.BackColor = System.Drawing.Color.MintCream;
            this.btnThemKhachThue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnThemKhachThue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemKhachThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemKhachThue.Location = new System.Drawing.Point(295, 45);
            this.btnThemKhachThue.Name = "btnThemKhachThue";
            this.btnThemKhachThue.Size = new System.Drawing.Size(100, 63);
            this.btnThemKhachThue.TabIndex = 4;
            this.btnThemKhachThue.Text = "Thêm";
            this.btnThemKhachThue.UseVisualStyleBackColor = false;
            this.btnThemKhachThue.Click += new System.EventHandler(this.btnThemKhachThue_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.MintCream;
            this.btnSua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(295, 114);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 63);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.MintCream;
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(295, 183);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 63);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.MintCream;
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(295, 258);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 63);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(952, 31);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(290, 28);
            this.toolStripLabel1.Text = "Quản lý thông tin khách thuê";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.RoyalBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 591);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(952, 23);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(951, 23);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Loading...";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBoxTimKiem
            // 
            this.groupBoxTimKiem.BackColor = System.Drawing.Color.LightGreen;
            this.groupBoxTimKiem.Controls.Add(this.btnTimKiem);
            this.groupBoxTimKiem.Controls.Add(this.txtTenKH);
            this.groupBoxTimKiem.Controls.Add(this.label1);
            this.groupBoxTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTimKiem.Location = new System.Drawing.Point(12, 204);
            this.groupBoxTimKiem.Name = "groupBoxTimKiem";
            this.groupBoxTimKiem.Size = new System.Drawing.Size(266, 117);
            this.groupBoxTimKiem.TabIndex = 4;
            this.groupBoxTimKiem.TabStop = false;
            this.groupBoxTimKiem.Text = "Tìm kiếm khách thuê";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnTimKiem.Location = new System.Drawing.Point(63, 65);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(129, 40);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm ";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(99, 31);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(143, 22);
            this.txtTenKH.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhập Tên:";
            // 
            // frmQLyKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(952, 614);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.groupBoxTimKiem);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThemKhachThue);
            this.Controls.Add(this.gbThemKhach);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gbDanhSachPhongTro);
            this.MaximizeBox = false;
            this.Name = "frmQLyKhach";
            this.Text = "Quản lý khách thuê";
            this.Load += new System.EventHandler(this.frmQLyKhach_Load);
            this.gbDanhSachPhongTro.ResumeLayout(false);
            this.gbDanhSachPhongTro.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKhachThue)).EndInit();
            this.gbThemKhach.ResumeLayout(false);
            this.gbThemKhach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBoxTimKiem.ResumeLayout(false);
            this.groupBoxTimKiem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDanhSachPhongTro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSoPhong;
        private System.Windows.Forms.ComboBox cmbLoaiPhong;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvDSKhachThue;
        private System.Windows.Forms.GroupBox gbThemKhach;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker ngayThue;
        private System.Windows.Forms.DateTimePicker ngaySinh;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Button btnThemKhachThue;
        private System.Windows.Forms.Button btnLoadImg;
        private System.Windows.Forms.PictureBox Avatar;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn maKhach;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioiTinh;
        private System.Windows.Forms.RadioButton radNu;
        private System.Windows.Forms.RadioButton radNam;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox groupBoxTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTenKH;
    }
}