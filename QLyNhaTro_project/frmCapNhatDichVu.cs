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
    public partial class frmCapNhatDichVu : Form
    {
        public event Action CapNhatDichVu;
        private readonly DichVuServirces dichVuServirces = new DichVuServirces();
        public frmCapNhatDichVu()
        {
            InitializeComponent();
        }

        private void frmCapNhatDichVu_Load(object sender, EventArgs e)
        {
            bindGrid();
        }
        // binding dữ liệu vào datagridview
        private void bindGrid()
        {
            dgvDichVu.Rows.Clear();
            foreach (var item in dichVuServirces.GetAll())
            {
                int index = dgvDichVu.Rows.Add();
                dgvDichVu.Rows[index].Cells[0].Value = item.MaDichVu;
                dgvDichVu.Rows[index].Cells[1].Value = item.TenDichVu;
                dgvDichVu.Rows[index].Cells[2].Value = item.DonGia;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            var date = DateTime.Now.ToString("dd/MM/yyyy");
            var time = DateTime.Now.ToString("hh:mm:ss tt");
            this.toolStripStatusLabel1.Text = string.Format($" {date} -  {time}");
        }

        private void dgvDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDichVu.SelectedRows.Count > 0)
            {
                txtMaDV.Text = dgvDichVu.SelectedRows[0].Cells[0].Value.ToString();
                txtTen.Text = dgvDichVu.SelectedRows[0].Cells[1].Value.ToString();
                txtGia.Text = dgvDichVu.SelectedRows[0].Cells[2].Value.ToString();     
            }
        }
        // button cập nhật dịch vụ
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDV.Text) || string.IsNullOrEmpty(txtTen.Text) || string.IsNullOrEmpty(txtGia.Text))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DichVu dv = new DichVu()
            {
                MaDichVu = txtMaDV.Text,
                TenDichVu = txtTen.Text,
                DonGia = decimal.Parse(txtGia.Text)
            };
            dichVuServirces.CapNhatDichVu(dv);
            CapNhatDichVu?.Invoke();
            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bindGrid();
        }

    }
}
