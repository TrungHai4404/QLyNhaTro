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
    public partial class frmQLyPhongTro : Form
    {
        public event Action updateData;
        private readonly PhongTroServices phongTroServices = new PhongTroServices();
        private readonly LoaiPhongServices loaiPhongServices = new LoaiPhongServices();
        private readonly DichVuServirces dichVuServirces = new DichVuServirces();

        public frmQLyPhongTro()
        {
            InitializeComponent();
        }
        private void frmQLyPhongTro_Load(object sender, EventArgs e)
        {
            radPhongDon.Checked = true;
            bindingData();
        }
        // Hiển thị thời gian
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            var date = DateTime.Now.ToString("dd/MM/yyyy");
            var time = DateTime.Now.ToString("hh:mm:ss tt");
            this.toolStripStatusLabel1.Text = string.Format($"Hôm nay là ngày: {date} - Bây giờ là: {time}");
        }
        // Biding dữ liệu từ database vào datagridview
        private void bindingData()
        {
           dgvPhongTro.Rows.Clear();
            foreach (var item in phongTroServices.GetAll())
            {
                int index = dgvPhongTro.Rows.Add();
                var loaiPhong = loaiPhongServices.GetAll().SingleOrDefault(x => x.MaLoaiPhong == item.MaLoaiPhong);
                dgvPhongTro.Rows[index].Cells[0].Value = item.MaPhong;
                dgvPhongTro.Rows[index].Cells[1].Value = item.TenPhong;
                dgvPhongTro.Rows[index].Cells[2].Value = loaiPhong.TenLoaiPhong;
                dgvPhongTro.Rows[index].Cells[3].Value = item.SucChua;
                dgvPhongTro.Rows[index].Cells[4].Value = item.LoaiPhong.GiaCoBan;
                dgvPhongTro.Rows[index].Cells[5].Value = item.TrangThai;
            }
        }
        //TViết sự kiện thêm phòng trọ
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenPhong.Text))
            {
                MessageBox.Show("Tên phòng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Kiem tra phong da ton tai chua
            var tenPhong = txtTenPhong.Text;
            var KtraTonTai = phongTroServices.KiemTraPhongTonTai(tenPhong);
            if (KtraTonTai == 1)
            {
                MessageBox.Show("Phòng đã tồn tai, Vui lòng nhập phòng khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                PhongTro phongTro = new PhongTro
                {
                    MaPhong = phongTroServices.TaoMaPhong(),
                    TenPhong = txtTenPhong.Text,
                    MaLoaiPhong = radPhongDon.Checked ? "LP01" : "LP02",
                    GiaThue = loaiPhongServices.LayGiaPhongTheoMaLoaiPhong(radPhongDon.Checked ? "LP01" : "LP02"),
                    SucChua = radPhongDon.Checked ? 2 : 3, // Fixing the error by converting string to int
                    TrangThai = "Trống",
                    MoTa = "",

                };
                LoaiPhong loaiPhong = new LoaiPhong
                {
                    MaLoaiPhong = radPhongDon.Checked ? "LP01" : "LP02",
                    TenLoaiPhong = radPhongDon.Checked ? "Phòng đơn" : "Phòng đôi",
                    GiaCoBan = loaiPhongServices.LayGiaPhongTheoMaLoaiPhong(radPhongDon.Checked ? "LP01" : "LP02"),
                    TienIch = ""
                };
                phongTroServices.ThemPhongTro(phongTro);
                MessageBox.Show("Thêm phòng trọ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                updateData?.Invoke();
                bindingData();
                txtTenPhong.Text = "";
                radPhongDon.Checked = true;
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult  dlg = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Xóa 1 phòng trọ
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhongTro.SelectedRows.Count > 0)
            {
                string maPhong = dgvPhongTro.SelectedRows[0].Cells[0].Value.ToString();
                string trangThai = dgvPhongTro.SelectedRows[0].Cells[5].Value.ToString();
                if (trangThai == "Đang thuê")
                {
                    MessageBox.Show("Không thể xóa phòng trọ đang được thuê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng trọ này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        phongTroServices.XoaPhongTro(maPhong);
                        MessageBox.Show("Xóa phòng trọ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        updateData?.Invoke();
                        bindingData();
                    }
                }    
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng trọ cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}
