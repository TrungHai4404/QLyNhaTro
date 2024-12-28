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
    public partial class frmTaoHoaDon : Form
    {
        private readonly KhachHangServices khachHangServices = new KhachHangServices();
        private readonly PhongTroServices phongTroServices = new PhongTroServices();
        private readonly LoaiPhongServices loaiPhongServices = new LoaiPhongServices();
        private readonly HopDongServices hopDongServices = new HopDongServices();
        private readonly HoaDonServices hoaDonServices = new HoaDonServices();
        private readonly DichVuServirces dichVuServirces = new DichVuServirces();
        public frmTaoHoaDon()
        {
            InitializeComponent();
            DuLieuLoaiPhong(loaiPhongServices.GetAll());
        }

        private void DuLieuLoaiPhong(List<LoaiPhong> LoaiPhong)
        {
            cmbLoaiPhong.DataSource = LoaiPhong;
            cmbLoaiPhong.DisplayMember = "TenLoaiPhong";
            cmbLoaiPhong.ValueMember = "MaLoaiPhong";
        }
        private void DuLieuSoPhong(List<PhongTro> SoPhong)
        {
            SoPhong.Insert(0, new PhongTro { MaPhong = "", TenPhong = "Trống" });
            cmbSoPhong.DataSource = SoPhong;
            cmbSoPhong.DisplayMember = "TenPhong";
            cmbSoPhong.ValueMember = "MaPhong";
        }
        // ĐỔ dữ liệu vào cmb loại phòng
        private void cmbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

            var loaiPhong = (LoaiPhong)cmbLoaiPhong.SelectedItem;
            var soPhong = phongTroServices.LayPhongTroCoKhachThueTheoLoaiPhong(loaiPhong.MaLoaiPhong);
            DuLieuSoPhong(soPhong);
        }

        private void cmbSoPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSoPhong.SelectedIndex != 0)
            {
                BindingData();
                bindGrid(khachHangServices.LayKhachThueTheoMaPhong(cmbSoPhong.SelectedValue.ToString()));
                MaHoaDon();
                ThemThongTin();

            }
            else
            {
                txtMaPhong.Text = "";
                txtSoPhong.Text = "";
                txtSL.Text = "";
                txtNgayBD.Text = "";
            }
        }
        // binding dữ liệu vào group box Thông tin phòng
        private void BindingData()
        {
            var phongTro = phongTroServices.LayPhongTroTheoMaPhong(cmbSoPhong.SelectedValue.ToString());
            if (phongTro != null)
            {
                txtLoaiPhong.Text = phongTro.MaLoaiPhong.ToString();
                txtSoPhong.Text = phongTro.TenPhong.ToString();
                txtSL.Text = phongTroServices.DemSoLuongKhachThueTheoMaPhong(phongTro.MaPhong).ToString();

                var khachThue = phongTro.KhachThues.FirstOrDefault();
                if (khachThue != null)
                {
                    txtNgayBD.Text = khachThue.NgayBatDauThue.ToString();
                }
                else
                {
                    txtNgayBD.Text = "N/A"; // or handle accordingly
                }
            }
            else
            {
                // Handle the case where phongTro is null
            }
        }
        // binding dữ liệu vào dgv Khách hàng
        private void bindGrid(List<KhachThue> khachThue)
        {
            dgvKhachThue.Rows.Clear();
            foreach (var item in khachThue)
            {
                int index = dgvKhachThue.Rows.Add();
                dgvKhachThue.Rows[index].Cells[0].Value = item.MaKhachThue;
                dgvKhachThue.Rows[index].Cells[1].Value = item.HoTen;
            }
        }
        // Binding dữ liệu vào bảng giá dịch vụ
        private void bangGiaDichVu()
        {
            txtInternet.Text = dichVuServirces.GiaTienDichVu("DV01").ToString();
            txtGiaNuoc.Text = dichVuServirces.GiaTienDichVu("DV02").ToString();
            txtGiaDien.Text = dichVuServirces.GiaTienDichVu("DV03").ToString();
            txtVeSinh.Text = dichVuServirces.GiaTienDichVu("DV04").ToString();
            txtBaoTri.Text = dichVuServirces.GiaTienDichVu("DV05").ToString();
        }
        //Binding dữ liệu vào panel các loại mã
        private void MaHoaDon()
        {
            var selectedValue = cmbSoPhong.SelectedValue?.ToString(); // Lấy mã phòng từ cmbSoPhong
            var dsHoaDon = hoaDonServices.LayDanhSachMaHoaDon(); // Lấy danh sách mã hóa đơn
            var maHopDong = phongTroServices.LayMaHopDongTheoMaPhong(selectedValue); // Lấy mã hợp đồng theo mã phòng
            txtMaHD.Text = hoaDonServices.TaoMaHoaDon(maHopDong, dsHoaDon).ToString();
            txtMaHopDong.Text = maHopDong;
            txtMaPhong.Text = selectedValue;
        }
        // Thêm thông tin vào panel tính tiền
        private void ThemThongTin()
        {
            // Lay gia tien va chi so
            var giaPhong = loaiPhongServices.LayGiaPhongTheoMaLoaiPhong(cmbLoaiPhong.SelectedValue.ToString());
            var giaDien = dichVuServirces.GiaTienDichVu("DV03");
            var giaNuoc = dichVuServirces.GiaTienDichVu("DV02");
            var giaInternet = dichVuServirces.GiaTienDichVu("DV01");
            var giaVeSinh = dichVuServirces.GiaTienDichVu("DV04");
            var giaBaoTri = dichVuServirces.GiaTienDichVu("DV05");
            // gan gia tien vao textbox
            txtTienPhong.Text = giaPhong.ToString();
            txtTienDien.Text = giaDien.ToString();
            txtTienNuoc.Text = giaNuoc.ToString();
            txtTienInternet.Text = giaInternet.ToString();
            txtTienVeSinh.Text = giaVeSinh.ToString();
            txtTienBaoTri.Text = giaBaoTri.ToString();
            // gan gia tien vao cot thanh tien
            txtThanhTienPhong.Text = giaPhong.ToString();
            txtThanhInternet.Text = giaInternet.ToString();
            txtThanhTienVeSinh.Text = giaVeSinh.ToString();
            txtThanhTienBaoTri.Text = giaBaoTri.ToString();
        }
        // Tinh Tien
        private void TinhTienVaThemVaoPanel()
        {
            // Lay gia tien va chi so
            var giaPhong = loaiPhongServices.LayGiaPhongTheoMaLoaiPhong(cmbLoaiPhong.SelectedValue.ToString());
            var giaDien = dichVuServirces.GiaTienDichVu("DV03");
            var giaNuoc = dichVuServirces.GiaTienDichVu("DV02");
            var giaInternet = dichVuServirces.GiaTienDichVu("DV01");
            var giaVeSinh = dichVuServirces.GiaTienDichVu("DV04");
            var giaBaoTri = dichVuServirces.GiaTienDichVu("DV05");
            var soDienCu = int.Parse(txtSoDienCu.Text);
            var soDienMoi = int.Parse(txtSoDienMoi.Text);
            var soNuocCu = int.Parse(txtKhoiNuocCu.Text);
            var soNuocMoi = int.Parse(txtKhoiNuocMoi.Text);
            // tinh gia dien va gia nuoc, tong tien
            if (soDienMoi < soDienCu)
            {
                MessageBox.Show("Số điện mới phải lớn hơn số điện cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (soNuocMoi < soNuocCu)
            {
                MessageBox.Show("Số nước mới phải lớn hơn số nước cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // tinh gias tien
            var tienDien = (soDienMoi - soDienCu) * giaDien;
            var tienNuoc = (soNuocMoi - soNuocCu) * giaNuoc;
            var tongTien = giaPhong + tienDien + tienNuoc + giaInternet + giaVeSinh + giaBaoTri;
            // gan gia tien vao cot thanh tien
            txtThanhTienDien.Text = tienDien.ToString();
            txtThanhTienNuoc.Text = tienNuoc.ToString();
            txtTongTien.Text = tongTien.ToString();
        }
        // Sự kiện thoát 
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            bangGiaDichVu();
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoDienCu.Text) || string.IsNullOrEmpty(txtSoDienMoi.Text) || string.IsNullOrEmpty(txtKhoiNuocCu.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TinhTienVaThemVaoPanel();

            }
        }
    }
}
