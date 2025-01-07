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
    
    public partial class frmThongKeDoanhThu : Form
    {
        private readonly HoaDonServices hoaDonServices = new HoaDonServices();
        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }
        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            // Tự động điền danh sách năm (ví dụ từ 2022 đến năm hiện tại)
            int currentYear = DateTime.Now.Year;
            cmbNam.Items.AddRange(Enumerable.Range(2022, currentYear - 2021).Select(y => y.ToString()).ToArray());
            cmbNam.SelectedIndex = cmbNam.Items.Count - 1; // Mặc định chọn năm hiện tại

        }
        private void btnDTThang_Click(object sender, EventArgs e)
        {
            LoadDoanhThuTheoTieuChi("Thang");
        }

        private void btnDTQuy_Click(object sender, EventArgs e)
        {
            LoadDoanhThuTheoTieuChi("Quy");
        }

        private void btnDTNam_Click(object sender, EventArgs e)
        {
            LoadDoanhThuTheoTieuChi("Nam");
        }

        private void LoadDoanhThuTheoTieuChi(string tieuChi)
        {
            if (cmbNam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn năm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(cmbNam.SelectedItem.ToString(), out int selectedYear))
            {
                MessageBox.Show("Năm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var hoaDonList = hoaDonServices.GetAllHoaDon()
                .Where(hd => DateTime.TryParseExact(hd.ThangNam, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var date) && date.Year == selectedYear);

            List<object> result = null;

            if (tieuChi == "Thang")
            {
                result = hoaDonList
                    .GroupBy(hd => DateTime.ParseExact(hd.ThangNam, "MM/yyyy", null).Month)
                    .Select(g => new { Thang = g.Key, TongTien = g.Sum(hd => hd.TongTien ?? 0) })
                    .OrderBy(dt => dt.Thang)
                    .Cast<object>()
                    .ToList();
            }
            else if (tieuChi == "Quy")
            {
                result = hoaDonList
                    .GroupBy(hd => (DateTime.ParseExact(hd.ThangNam, "MM/yyyy", null).Month - 1) / 3 + 1)
                    .Select(g => new { Quy = g.Key, TongTien = g.Sum(hd => hd.TongTien ?? 0) })
                    .OrderBy(dt => dt.Quy)
                    .Cast<object>()
                    .ToList();
            }
            else if (tieuChi == "Nam")
            {
                result = hoaDonList
                    .GroupBy(hd => DateTime.ParseExact(hd.ThangNam, "MM/yyyy", null).Year)
                    .Select(g => new { Nam = g.Key, TongTien = g.Sum(hd => hd.TongTien ?? 0) })
                    .Cast<object>()
                    .ToList();
            }
            else
            {
                MessageBox.Show("Tiêu chí không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvDoanhThu.DataSource = result;
        }
    }
}
