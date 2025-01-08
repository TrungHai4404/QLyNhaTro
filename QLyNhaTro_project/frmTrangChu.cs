using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLyNhaTro.BUS;
using QLyNhaTro.DAL.Models;

namespace QLyNhaTro_project
{
    public partial class frmTrangChu : Form
    {
        private readonly KhachHangServices khachHangServices = new KhachHangServices();
        private readonly PhongTroServices phongTroServices = new PhongTroServices();
        private readonly LoaiPhongServices loaiPhongServices = new LoaiPhongServices();
        //private readonly HopDongServices hopDongServices = new HopDongServices();
        private readonly DichVuServirces dichVuServirces = new DichVuServirces();
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            DuLieuLoaiPhongThue(loaiPhongServices.GetAll());
            DuLieuLoaiPhongTrong(loaiPhongServices.GetAll());
            bindGrid(khachHangServices.GetAll());
            gbThongTinNhaTro();

        }
        // Hiển thị thời gian
        private void timer1_Tick(object sender, EventArgs e)
        {
            var date = DateTime.Now.ToString("dd/MM/yyyy");
            var time = DateTime.Now.ToString("hh:mm:ss tt");
            this.toolStripStatusLabel1.Text = string.Format($"Hôm nay là ngày: {date} - Bây giờ là: {time}");
        }
        //Cap nhat Du lieu
        private void formUpdate()
        {
            
            var khachHang = khachHangServices.GetAll();
            bindGrid(khachHang);
            gbThongTinNhaTro();
            

        }
        // đổ dữ liệu vào group box phòng đã thuê
        private void DuLieuLoaiPhongThue(List<LoaiPhong> LoaiPhong)
        {
            cmbLoaiPhongThue.DataSource = LoaiPhong;
            cmbLoaiPhongThue.DisplayMember = "TenLoaiPhong";
            cmbLoaiPhongThue.ValueMember = "MaLoaiPhong";
        }
        private void DuLieuSoPhongThue(List<PhongTro> SoPhong)
        {
            SoPhong.Insert(0, new PhongTro { MaPhong = "", TenPhong = "Trống" });
            cmbSoPhongThue.DataSource = SoPhong;
            cmbSoPhongThue.DisplayMember = "TenPhong";
            cmbSoPhongThue.ValueMember = "MaPhong";
        }
        
        // Dữ liệu số phòng được chọn theo loại phòng

        private void cmbLoaiPhongThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoaiPhong loaiPhong = (LoaiPhong)cmbLoaiPhongThue.SelectedItem;
            if(loaiPhong != null)
            {
                var listSoPhong = phongTroServices.LayPhongTroCoKhachThueTheoLoaiPhong(loaiPhong.MaLoaiPhong);
                DuLieuSoPhongThue(listSoPhong);
            }
        }

        private void cmbSoPhongThue_SelectedIndexChanged(object sender, EventArgs e)
        { 
            bindGrid(khachHangServices.LayKhachThueTheoMaPhong(cmbSoPhongThue.SelectedValue.ToString()));
        }

        // Đổ dữ liệu vào combobox Phòng trống
        private void DuLieuLoaiPhongTrong(List<LoaiPhong> LoaiPhong)
        {
            cmbLoaiPhongTrong.DataSource = LoaiPhong;
            cmbLoaiPhongTrong.DisplayMember = "TenLoaiPhong";
            cmbLoaiPhongTrong.ValueMember = "MaLoaiPhong";
        }
        private void DuLieuSoPhongTrong(List<PhongTro> SoPhong)
        {
            SoPhong.Insert(0, new PhongTro { MaPhong = "", TenPhong = "Trống" });
            cmbSoPhongTrong.DataSource = SoPhong;
            cmbSoPhongTrong.DisplayMember = "TenPhong";
            cmbSoPhongTrong.ValueMember = "MaPhong";
        }

        private void cmbLoaiPhongTrong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoaiPhong loaiPhong = (LoaiPhong)cmbLoaiPhongTrong.SelectedItem;
            if (loaiPhong != null  )
            {
                var listSoPhong = phongTroServices.LayPhongTroTrongTheoLoaiPhong(loaiPhong.MaLoaiPhong);
                DuLieuSoPhongTrong(listSoPhong);
            }
        }
        // Đổ dữ liệu vào datagridview
        public void bindGrid(List<KhachThue> kh)
        {
            dgvDSKhachThue.Rows.Clear();
            foreach (var item in kh)
            {
                int index = dgvDSKhachThue.Rows.Add();
                dgvDSKhachThue.Rows[index].Cells[0].Value = item.MaKhachThue;
                dgvDSKhachThue.Rows[index].Cells[1].Value = item.HoTen;
                dgvDSKhachThue.Rows[index].Cells[2].Value = item.CMND_CCCD;
                dgvDSKhachThue.Rows[index].Cells[3].Value = item.DiaChiThuongTru;
                dgvDSKhachThue.Rows[index].Cells[4].Value = item.NgayBatDauThue;
            }
        }
        // Đổ dữ liệu vào GroupBox thông tin phòng trống
        private void ThongTinPhongTrong()
        {
            PhongTro phongTro = phongTroServices.LayPhongTroTheoMaPhong(cmbSoPhongTrong.SelectedValue.ToString());
            if (phongTro != null)
            {
                txtMaPhong.Text = phongTro.MaPhong;
                txtLoaiPhong.Text = phongTro.LoaiPhong.TenLoaiPhong;
                txtDienTich.Text = phongTro.LoaiPhong.DienTich.ToString();
                txtGiaTien.Text = phongTro.LoaiPhong.GiaCoBan.ToString();
            }
        }
        private void cmbSoPhongTrong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbSoPhongTrong.SelectedIndex != 0)
            {
                ThongTinPhongTrong();
            }
            else
            {
                txtMaPhong.Text = "";
                txtLoaiPhong.Text = "";
                txtDienTich.Text = "";
                txtGiaTien.Text = "";
            }
            ThongTinPhongTrong();
        }
        // group box Thông tin nhà trọ
        private void gbThongTinNhaTro()
        {
            txtPhongDaThue.Text = phongTroServices.SoLuongPhongDaThue().ToString();
            txtSLPhongTrong.Text = phongTroServices.SoLuongPhongTrong().ToString();
            txtGiaDien.Text = dichVuServirces.GiaTienDichVu("DV03").ToString();
            txtGiaNuoc.Text = dichVuServirces.GiaTienDichVu("DV02").ToString();
            txtGiaInternet.Text = dichVuServirces.GiaTienDichVu("DV01").ToString();
        }
        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLyHoaDon frm = new frmQLyHoaDon();
            frm.Show();
        }
        // button Thoát
        private void tsThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        // button form Quản lý phòng trọ
        private void tsQLPhongThue_Click(object sender, EventArgs e)
        {
            frmQLyPhongTro frm = new frmQLyPhongTro();
            frm.updateData += formUpdate;
            frm.Show();
        }
        // button form Quán lý khách thuê
        private void tsQLKhachThue_Click(object sender, EventArgs e)
        {
            frmQLyKhach frm = new frmQLyKhach();
            frm.DataUpdate += formUpdate;
            frm.Show();
        }

        private void tsSuaGiaDV_Click(object sender, EventArgs e)
        {
            frmCapNhatDichVu frm = new frmCapNhatDichVu();
            frm.CapNhatDichVu += formUpdate;
            frm.Show();
        }

        private void tsTinhTienPhong_Click(object sender, EventArgs e)
        {
            frmTaoHoaDon frm = new frmTaoHoaDon();
            frm.Show();
        }

        private void tsTraPhong_Click(object sender, EventArgs e)
        {
            frmTraPhong frm = new frmTraPhong();
            frm.updateData += formUpdate;
            frm.Show();
        }
        // Shortcut key
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.F4:
                    tsThoat_Click(this, EventArgs.Empty);
                    return true;
                case Keys.F1:
                    thốngKêDoanhThuToolStripMenuItem_Click(this, EventArgs.Empty);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void quảnLýKháchThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLyKhach frm = new frmQLyKhach();
            frm.DataUpdate += formUpdate;
            frm.Show();
            
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsThoat_Click(sender, e);
        }
        private void quảnLýHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLyHopDong frm = new frmQLyHopDong();
            frm.ShowDialog();
        }

        private void thốngKêDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThu frm = new frmThongKeDoanhThu();
            frm.ShowDialog();
        }

        private void quảnLýPhòngTrọToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            tsQLPhongThue_Click(sender, e);
        }

        private void sửaGiáDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsSuaGiaDV_Click(sender, e);
        }

        private void tínhTiềnPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsTinhTienPhong_Click(sender, e);
        }

        private void trảPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsTraPhong_Click(sender,e);
        }

        private void dgvDSKhachThue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
