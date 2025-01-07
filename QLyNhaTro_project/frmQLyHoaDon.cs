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
    public partial class frmQLyHoaDon : Form
    {
        private readonly HoaDonServices hoaDonServices = new HoaDonServices();
        public frmQLyHoaDon()
        {
            InitializeComponent();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            bindGrid(hoaDonServices.GetAllHoaDon());
        }

        private void frmQLyHoaDon_Load(object sender, EventArgs e)
        {
            bindGrid(hoaDonServices.GetAllHoaDon());
        }
        // binding dữ liệu hóa đơn vào datagridview
        private void bindGrid(List<HoaDon> hoaDons)
        {
            dgvHoaDon.Rows.Clear();
            foreach (var item in hoaDons)
            {
                int index = dgvHoaDon.Rows.Add();
                dgvHoaDon.Rows[index].Cells[0].Value = item.MaHoaDon;
                dgvHoaDon.Rows[index].Cells[1].Value = item.HopDong.PhongTro.TenPhong; // Changed to TenPhong
                dgvHoaDon.Rows[index].Cells[2].Value = item.ThangNam;
                dgvHoaDon.Rows[index].Cells[3].Value = item.TienPhong;
                dgvHoaDon.Rows[index].Cells[4].Value = item.TienDichVu;
                dgvHoaDon.Rows[index].Cells[5].Value = item.TongTien;
                dgvHoaDon.Rows[index].Cells[6].Value = item.TrangThaiThanhToan;
            }
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            frmTaoHoaDon frm = new frmTaoHoaDon();
            frm.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvHoaDon.SelectedRows)
                {
                    if (row.Cells[6].Value.ToString() == "Chưa thanh toán")
                    {
                        //row.Cells[6].Value = "Đã thanh toán";
                        var maHoaDon = row.Cells[0].Value.ToString();
                        var hoaDon = hoaDonServices.LayHoaDonTheoMaHoaDon(maHoaDon);
                        
                        hoaDonServices.CapNhatHoaDon(hoaDon);
                    }
                    else
                    {
                        MessageBox.Show("Hóa đơn đã được thanh toán, không thể cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                bindGrid(hoaDonServices.GetAllHoaDon());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var date = DateTime.Now.ToString("dd/MM/yyyy");
            var time = DateTime.Now.ToString("hh:mm:ss tt");
            this.toolStripStatusLabel1.Text = string.Format($"Hôm nay là ngày: {date} - Bây giờ là: {time}");
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvHoaDon.SelectedRows)
                {
                    var maHoaDon = row.Cells[0].Value.ToString();
                    hoaDonServices.XoaHoaDonTheoMaHoaDon(maHoaDon);
                }
                MessageBox.Show("Xóa hóa đơn thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindGrid(hoaDonServices.GetAllHoaDon());
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenPhong = txtTenPhong.Text.Trim();
            if (!string.IsNullOrEmpty(tenPhong))
            {
                var hoaDons = hoaDonServices.GetAllHoaDon()
                    .Where(hd => hd.HopDong.PhongTro.TenPhong.Contains(tenPhong))
                    .ToList();
                if (hoaDons.Count > 0)
                {
                    bindGrid(hoaDons);
                }
                else
                {
                    MessageBox.Show("Phòng này không có hóa đơn nào!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên phòng cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
