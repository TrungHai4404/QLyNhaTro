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
    public partial class frmTraPhong : Form
    {
        public event Action updateData;
        private readonly KhachHangServices khachHangServices = new KhachHangServices();
        private readonly PhongTroServices phongTroServices = new PhongTroServices();
        private readonly LoaiPhongServices loaiPhongServices = new LoaiPhongServices();
        private readonly HopDongServices hopDongServices = new HopDongServices();
        private readonly HoaDonServices hoaDonServices = new HoaDonServices();
        public frmTraPhong()
        {
            InitializeComponent();
        }

        private void frmTraPhong_Load(object sender, EventArgs e)
        {
            DuLieuLoaiPhongThue(loaiPhongServices.GetAll());
        }
        // đổ dữ liệu vào group box phòng đã thuê
        private void DuLieuLoaiPhongThue(List<LoaiPhong> LoaiPhong)
        {
            cmbLoaiPhong.DataSource = LoaiPhong;
            cmbLoaiPhong.DisplayMember = "TenLoaiPhong";
            cmbLoaiPhong.ValueMember = "MaLoaiPhong";
        }
        private void DuLieuSoPhongThue(List<PhongTro> SoPhong)
        {
            SoPhong.Insert(0, new PhongTro { MaPhong = "", TenPhong = "Trống" });
            cmbSoPhong.DataSource = SoPhong;
            cmbSoPhong.DisplayMember = "TenPhong";
            cmbSoPhong.ValueMember = "MaPhong";
        }

        // Dữ liệu số phòng được chọn theo loại phòng
        private void cmbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoaiPhong loaiPhong = (LoaiPhong)cmbLoaiPhong.SelectedItem;
            if (loaiPhong != null)
            {
                var listSoPhong = phongTroServices.LayPhongTroCoKhachThueTheoLoaiPhong(loaiPhong.MaLoaiPhong);
                DuLieuSoPhongThue(listSoPhong);
            }
        }

        private void cmbSoPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindGrid(khachHangServices.LayKhachThueTheoMaPhong(cmbSoPhong.SelectedValue.ToString()));
        }
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

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            if (cmbSoPhong.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cần trả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                var maPhong = cmbSoPhong.SelectedValue.ToString();
                var hopDong = hopDongServices.FindByMaPhong(maPhong);
                if (hopDong != null)
                {
                    var khachThue = khachHangServices.FindByID(hopDong.MaKhachThue);
                    if (khachThue != null)
                    {
                        var dsHoaDon = hoaDonServices.LayDSHoaDonTheoMaHopDong(hopDong.MaHopDong);
                        foreach(var item in dsHoaDon)
                        {
                            hoaDonServices.XoaHoaDon(hopDong.MaHopDong);
                        }
                        hopDongServices.XoaHopDong(hopDong.MaKhachThue);
                        khachHangServices.XoaKhachThue(khachThue.MaKhachThue);
                    }
                    phongTroServices.CapNhatTinhTrangPhong(maPhong, "Trống");
                }
                updateData?.Invoke();
                MessageBox.Show("Trả phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmTraPhong_Load(sender, e);
            }    
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var date = DateTime.Now.ToString("dd/MM/yyyy");
            var time = DateTime.Now.ToString("hh:mm:ss tt");
            this.toolStripStatusLabel1.Text = string.Format($"Hôm nay là ngày: {date} - Bây giờ là: {time}");
        }
    }
}
