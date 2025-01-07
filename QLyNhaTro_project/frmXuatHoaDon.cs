using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using static QLyNhaTro_project.frmTaoHoaDon;

namespace QLyNhaTro_project
{
    internal partial class frmXuatHoaDon : Form
    {
        private rptHoaDon hoaDon;
        public frmXuatHoaDon(rptHoaDon data)
        {
            InitializeComponent();
            hoaDon = data;
        }
        private void rptViewerHoaDon_Load(object sender, EventArgs e)
        {
            rptViewerHoaDon.LocalReport.DataSources.Clear();
            rptViewerHoaDon.LocalReport.ReportPath = "rpHoaDon.rdlc";

            // Convert hoaDon to a compatible type, e.g., DataTable
            DataTable hoaDonTable = ConvertToDataTable(hoaDon); // Implement this method
            if (hoaDonTable.Rows.Count > 0)
            {
                var source = new ReportDataSource("HoaDonDataset", hoaDonTable);
                rptViewerHoaDon.LocalReport.DataSources.Add(source);
            }
            else
            {
                MessageBox.Show("Không có thông tin hóa đơn để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.rptViewerHoaDon.RefreshReport();
        }
        private DataTable ConvertToDataTable(rptHoaDon hoaDon)
        {
            DataTable table = new DataTable();
            table.Columns.Add("maHD", typeof(string));
            table.Columns.Add("maPhong", typeof(string));
            table.Columns.Add("maHopDong", typeof(string));
            table.Columns.Add("tienPhong", typeof(string));
            table.Columns.Add("tienDien", typeof(string));
            table.Columns.Add("soDienCu", typeof(string));
            table.Columns.Add("soDienMoi", typeof(string));
            table.Columns.Add("tienNuoc", typeof(string));
            table.Columns.Add("soNuocCu", typeof(string));
            table.Columns.Add("soNuocMoi", typeof(string));
            table.Columns.Add("tienIntenet", typeof(string));
            table.Columns.Add("tienVeSinh", typeof(string));
            table.Columns.Add("tienBaoTri", typeof(string));
            table.Columns.Add("thanhTienPhong", typeof(string));
            table.Columns.Add("thanhTienDien", typeof(string));
            table.Columns.Add("thanhTienNuoc", typeof(string));
            table.Columns.Add("thanhTienInternet", typeof(string));
            table.Columns.Add("thanhTienVeSinh", typeof(string));
            table.Columns.Add("thanhTienBaoTri", typeof(string));
            table.Columns.Add("tongTien", typeof(string));
            table.Columns.Add("giaDien", typeof(string));
            table.Columns.Add("giaNuoc", typeof(string));
            table.Columns.Add("giaInternet", typeof(string));
            table.Columns.Add("giaVeSinh", typeof(string));
            table.Columns.Add("giaBaoTri", typeof(string));
            table.Rows.Add(hoaDon.maHD, hoaDon.maPhong, hoaDon.maHopDong,
                           hoaDon.tienPhong, hoaDon.tienDien, hoaDon.soDienCu,
                           hoaDon.soDienMoi, hoaDon.tienNuoc, hoaDon.soNuocCu,
                           hoaDon.soNuocMoi, hoaDon.tienIntenet, hoaDon.tienVeSinh,
                           hoaDon.tienBaoTri, hoaDon.thanhTienPhong, hoaDon.thanhTienDien,
                           hoaDon.thanhTienNuoc, hoaDon.thanhTienInternet, hoaDon.thanhTienVeSinh,
                           hoaDon.thanhTienBaoTri, hoaDon.tongTien, hoaDon.giaDien, hoaDon.giaNuoc,
                           hoaDon.giaInternet, hoaDon.giaVeSinh, hoaDon.giaBaoTri);

            return table;
        }

        private void rptViewerHoaDon_Load_1(object sender, EventArgs e)
        {

        }
    }
    
}
