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

namespace QLyNhaTro_project
{
    public partial class frmQLyHopDong : Form
    {
        private readonly HopDongServices hopDongServices = new HopDongServices();
        private readonly KhachHangServices khachHangServices = new KhachHangServices();
        public frmQLyHopDong()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmQLyHopDong_Load(object sender, EventArgs e)
        {
            bindGrid();
            KiemTraHD();
        }
        //Binding dữ liệu
        private void bindGrid()
        {
            dgvThongTin.Rows.Clear();
            var list = hopDongServices.GetAll();
            foreach (var item in list)
            {
                int index = dgvThongTin.Rows.Add();
                dgvThongTin.Rows[index].Cells[0].Value = item.MaHopDong;
                dgvThongTin.Rows[index].Cells[1].Value = item.MaPhong;
                dgvThongTin.Rows[index].Cells[2].Value = item.KhachThue.HoTen;
                dgvThongTin.Rows[index].Cells[3].Value = item.KhachThue.DiaChiThuongTru;
                dgvThongTin.Rows[index].Cells[4].Value = item.NgayKyHopDong;
                dgvThongTin.Rows[index].Cells[5].Value = item.NgayKetThuc;
                dgvThongTin.Rows[index].Cells[6].Value = item.TinhTrang;
            }
        }

        // kiểm tra tình trạng hợp đồng
        private void KiemTraHD()
        {
            var list = hopDongServices.GetAll();
            foreach (var item in list)
            {
                if (item.NgayKyHopDong.HasValue && item.NgayKyHopDong.Value.AddMonths(6) < DateTime.Now)
                {
                    item.TinhTrang = "Hết hạn";
                    hopDongServices.CapNhatTinhTrang(item);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            KiemTraHD();
            bindGrid();
            txtMaHD.Text = "";
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            if (dgvThongTin.SelectedRows.Count > 0)
            {
                var selectedRow = dgvThongTin.SelectedRows[0];
                var maHopDong = selectedRow.Cells[0].Value.ToString();
                var hopDong = hopDongServices.FindByMaHD(maHopDong);

                if (hopDong != null)
                {
                    hopDong.NgayKetThuc = hopDong.NgayKetThuc;
                    hopDong.TinhTrang = "Đang hiệu lực";
                    hopDongServices.CapNhatHopDong(hopDong.MaHopDong, hopDong.NgayKetThuc);
                    hopDongServices.CapNhatTinhTrang(hopDong);
                    MessageBox.Show("Gia hạn hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bindGrid();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hợp đồng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần gia hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            rptHopDong rpt = new rptHopDong();
            rpt = TruyenDuLieuHopDong(rpt);

            frmXuatHopDong frm = new frmXuatHopDong(rpt);
            frm.ShowDialog();
        }
        internal rptHopDong TruyenDuLieuHopDong(rptHopDong rpt)
        {
            if (dgvThongTin.SelectedRows.Count > 0)
            {
                var selectedRow = dgvThongTin.SelectedRows[0];
                var maHopDong = selectedRow.Cells[0].Value.ToString();
                var hopDong = hopDongServices.FindByMaHD(maHopDong);
                var dienTich = hopDongServices.LayLoaiPhongTheoMaPhong(hopDong.MaPhong);
                if (hopDong != null)
                {
                    rpt.hoTen = hopDong.KhachThue.HoTen;
                    rpt.cccd = hopDong.KhachThue.CMND_CCCD;
                    rpt.diaChi = hopDong.KhachThue.DiaChiThuongTru;
                    rpt.tenPhong = hopDong.PhongTro.TenPhong;
                    rpt.giaPhong = hopDong.PhongTro.GiaThue.ToString();
                    rpt.ngayThue = hopDong.NgayKyHopDong.HasValue ? hopDong.NgayKyHopDong.Value : DateTime.MinValue;
                    rpt.dienTich = dienTich.ToString();
                    return rpt;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hợp đồng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return rpt;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tenKhachHang = txtMaHD.Text.Trim();
            if (!string.IsNullOrEmpty(tenKhachHang))
            {
                var hopDongs = hopDongServices.GetAll().Where(hd => hd.KhachThue.HoTen.IndexOf(tenKhachHang, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                if (hopDongs.Any())
                {
                    dgvThongTin.Rows.Clear();
                    foreach (var hopDong in hopDongs)
                    {
                        int index = dgvThongTin.Rows.Add();
                        dgvThongTin.Rows[index].Cells[0].Value = hopDong.MaHopDong;
                        dgvThongTin.Rows[index].Cells[1].Value = hopDong.MaPhong;
                        dgvThongTin.Rows[index].Cells[2].Value = hopDong.KhachThue.HoTen;
                        dgvThongTin.Rows[index].Cells[3].Value = hopDong.KhachThue.DiaChiThuongTru;
                        dgvThongTin.Rows[index].Cells[4].Value = hopDong.NgayKyHopDong;
                        dgvThongTin.Rows[index].Cells[5].Value = hopDong.NgayKetThuc;
                        dgvThongTin.Rows[index].Cells[6].Value = hopDong.TinhTrang;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hợp đồng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
