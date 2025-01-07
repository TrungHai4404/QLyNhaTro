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
using QLyNhaTro.DAL.Models;

namespace QLyNhaTro_project
{
    public partial class frmXuatHopDong : Form
    {
        private rptHopDong hopDong;
        public frmXuatHopDong(rptHopDong data)
        {
            InitializeComponent();
            hopDong = data;
        }

        private void frmXuatHopDong_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "rpHopDong.rdlc";
            DataTable hopDongTable = ConvertToDataTable(hopDong); // Implement this method
            if (hopDongTable.Rows.Count > 0)
            {
                var source = new ReportDataSource("DataSet1", hopDongTable);
                reportViewer1.LocalReport.DataSources.Add(source);
            }
            this.reportViewer1.RefreshReport();
        }
        private DataTable ConvertToDataTable(rptHopDong hopDong)
        {
            DataTable table = new DataTable();
            table.Columns.Add("hoTen", typeof(string));
            table.Columns.Add("cccd", typeof(string));
            table.Columns.Add("diaChi", typeof(string));
            table.Columns.Add("tenPhong", typeof(string));
            table.Columns.Add("giaPhong", typeof(string));
            table.Columns.Add("dienTich", typeof(string));
            table.Columns.Add("ngayThue", typeof(DateTime));

            table.Rows.Add(hopDong.hoTen, hopDong.cccd, hopDong.diaChi, 
                           hopDong.tenPhong, hopDong.giaPhong, hopDong.dienTich, 
                           hopDong.ngayThue);
            return table;
        }
    }
}
