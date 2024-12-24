using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private readonly HopDongServices hopDongServices = new HopDongServices();
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            DuLieuLoaiPhong(loaiPhongServices.GetAll());
            DuLieuLoaiPhongTrong(loaiPhongServices.GetAll());
        }
        // đổ dữ liệu vào group box phòng đã thuê
        private void DuLieuLoaiPhong(List<LoaiPhong> LoaiPhong)
        {
            cmbLoaiPhongThue.DataSource = LoaiPhong;
            cmbLoaiPhongThue.DisplayMember = "TenLoaiPhong";
            cmbLoaiPhongThue.ValueMember = "MaLoaiPhong";
        }
        private void DuLieuSoPhong(List<PhongTro> SoPhong)
        {
            cmbSoPhongThue.DataSource = SoPhong;
            cmbSoPhongThue.DisplayMember = "TenPhong";
            cmbSoPhongThue.ValueMember = "MaPhong";
        }
        // Đổ dữ liệu vào datagridview
        public void bindGrid(List<KhachThue> kh)
        {
            dgvDSKhachThue.Rows.Clear();
            foreach(var item in kh)
            {
                int index = dgvDSKhachThue.Rows.Add();
                dgvDSKhachThue.Rows[index].Cells[0].Value = item.MaKhachThue;
                dgvDSKhachThue.Rows[index].Cells[1].Value = item.HoTen;
                dgvDSKhachThue.Rows[index].Cells[2].Value = item.CMND_CCCD;
                dgvDSKhachThue.Rows[index].Cells[3].Value = item.DiaChiThuongTru;
                dgvDSKhachThue.Rows[index].Cells[4].Value = item.NgayBatDauThue;
            }
        }
        // Dữ liệu số phòng được chọn theo loại phòng

        private void cmbLoaiPhongThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoaiPhong loaiPhong = (LoaiPhong)cmbLoaiPhongThue.SelectedItem;
            if(loaiPhong != null)
            {
                var listSoPhong = phongTroServices.GetPhongTroByLoaiPhong(loaiPhong.MaLoaiPhong);
                DuLieuSoPhong(listSoPhong);
                var std = hopDongServices.LayKhachThueTheoMaPhong(cmbSoPhongThue.SelectedValue.ToString());
                bindGrid(std);

            }
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
            cmbSoPhongTrong.DataSource = SoPhong;
            cmbSoPhongTrong.DisplayMember = "TenPhong";
            cmbSoPhongTrong.ValueMember = "MaPhong";
        }

        private void cmbLoaiPhongTrong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoaiPhong loaiPhong = (LoaiPhong)cmbLoaiPhongTrong.SelectedItem;
            var trangthai = phongTroServices.PhongTrong();
            if (loaiPhong != null  )
            {
                var listSoPhong = phongTroServices.GetPhongTroByLoaiPhong(loaiPhong.MaLoaiPhong);
                var soPhongTrong = phongTroServices.PhongTrong();
                DuLieuSoPhongTrong(soPhongTrong);
            }
        }

        
    }
}
