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
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvHoaDon.SelectedRows)
                {
                    if (row.Cells[6].Value.ToString() == "Đã thanh toán")
                    {
                        hoaDonServices.XoaHoaDonDaThanhToan("Đã thanh toán");
                    }
                }
                bindGrid(hoaDonServices.GetAllHoaDon());
            }
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
                dgvHoaDon.Rows[index].Cells[1].Value = item.MaHopDong;
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
    }
}
