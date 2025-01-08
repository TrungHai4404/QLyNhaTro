using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLyNhaTro.BUS;
using QLyNhaTro.DAL.Models;

namespace QLyNhaTro_project
{
    public partial class frmQLyKhach : Form
    {
        public event Action DataUpdate; 
        private string avtFilePath = string.Empty;
        private readonly KhachHangServices khachHangServices = new KhachHangServices();
        private readonly PhongTroServices phongTroServices = new PhongTroServices();
        private readonly LoaiPhongServices loaiPhongServices = new LoaiPhongServices();
        private readonly HopDongServices hopDongServices = new HopDongServices();
        private readonly HoaDonServices hoaDonServices = new HoaDonServices();

        public frmQLyKhach()
        {
            InitializeComponent();
        }
        private void frmQLyKhach_Load(object sender, EventArgs e)
        {
            DuLieuLoaiPhong(loaiPhongServices.GetAll());
            var list = khachHangServices.GetAll();
            bindGrid(list);
            clearData();
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

        private void cmbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            var loaiPhong = (LoaiPhong)cmbLoaiPhong.SelectedItem;
            var soPhong = phongTroServices.LayPhongTroTheoLoaiPhong(loaiPhong.MaLoaiPhong);
            DuLieuSoPhong(soPhong); // Hàm này để load danh sách phòng vào ComboBox
            
        }
        // đổ dữ liệu phòng còn có thể thêm khách hàng vào datagridview
        private void cmbSoPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSoPhong = cmbSoPhong.SelectedValue?.ToString();
            var selectedLoaiPhong = cmbLoaiPhong.SelectedValue?.ToString();

            if (!string.IsNullOrEmpty(selectedSoPhong))
            { 
                var khachThue = khachHangServices.LayKhachThueTheoMaPhong(selectedSoPhong);
                bindGrid(khachThue);// Đổ dữ liệu khách thuê vào DataGridView
            }
            
        }
        public void bindGrid(List<KhachThue> kh)
        {
            dgvDSKhachThue.Rows.Clear();
            foreach (var item in kh)
            {
                int index = dgvDSKhachThue.Rows.Add();
                var phongTro = phongTroServices.LayPhongTroTheoMaPhong(item.MaPhong);
                dgvDSKhachThue.Rows[index].Cells[0].Value = phongTro?.TenPhong;
                dgvDSKhachThue.Rows[index].Cells[1].Value = item.MaKhachThue;
                dgvDSKhachThue.Rows[index].Cells[2].Value = item.HoTen;
                dgvDSKhachThue.Rows[index].Cells[3].Value = item.CMND_CCCD;
                dgvDSKhachThue.Rows[index].Cells[4].Value = item.DiaChiThuongTru;
                dgvDSKhachThue.Rows[index].Cells[5].Value = item.GioiTinh;
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }


        private void gbDanhSachPhongTro_Paint_1(object sender, PaintEventArgs e)
        {
            // Tạo bút vẽ (Pen) cho viền
            using (Pen pen = new Pen(Color.Black, 2)) // Màu viền xanh, độ dày 2px
            {
                // Lấy kích thước của GroupBox
                Rectangle borderRect = new Rectangle(
                    gbDanhSachPhongTro.ClientRectangle.X,
                    gbDanhSachPhongTro.ClientRectangle.Y, // Dịch xuống vừa đủ để tránh chữ
                    gbDanhSachPhongTro.ClientRectangle.Width,
                    gbDanhSachPhongTro.ClientRectangle.Height
                );

                // Vẽ viền hình chữ nhật (trừ vùng chữ)
                e.Graphics.DrawRectangle(pen, borderRect);
            }
        }

        private void gbThemKhach_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 2)) // Màu viền xanh, độ dày 2px
            {
                // Lấy kích thước của GroupBox
                Rectangle borderRect = new Rectangle(
                    gbThemKhach.ClientRectangle.X,
                    gbThemKhach.ClientRectangle.Y,
                    gbThemKhach.ClientRectangle.Width,
                    gbThemKhach.ClientRectangle.Height
                );
                // Vẽ viền hình chữ nhật (trừ vùng chữ)
                e.Graphics.DrawRectangle(pen, borderRect);
            }
        }

        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png )|*.jpg; *.jpeg; *.png ";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    avtFilePath = openFileDialog.FileName;
                    Avatar.Image = Image.FromFile(avtFilePath);
                }
            }
        }
        private void loadAVT(string maKH)
        {
            string folderPath = Path.Combine(Application.StartupPath, "Images");
            var khachHang = khachHangServices.FindByID(maKH);
            if (khachHang != null && !string.IsNullOrEmpty(khachHang.Avatar))
            {
                string avtFilePath = Path.Combine(folderPath, khachHang.Avatar);
                if (File.Exists(avtFilePath))
                {
                    Avatar.Image = Image.FromFile(avtFilePath);
                }
                else
                {
                    Avatar.Image = null;
                }
            }
        }
        private string saveAVT(string sourceFilePath, string maKH)
        {
            try
            {
                string folderPath = Path.Combine(Application.StartupPath, "Images");
                Console.WriteLine($"Đường dẫn thư mục images: {folderPath}");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string fileExtension = Path.GetExtension(sourceFilePath);
                string targetFilePath = Path.Combine(folderPath, $"{maKH}{fileExtension}");
                if (!File.Exists(sourceFilePath))
                {
                    throw new FileNotFoundException($"Khong tim thay file: {sourceFilePath}");
                }
                File.Copy(sourceFilePath, targetFilePath, true);
                return $"{maKH}{fileExtension}";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loi luu avatar: {ex.Message}", "Loi", MessageBoxButtons.OK);
                return null;
            }
        }


        
        // Sự kiện khi click vào 1 dòng trong DataGridView
        private void dgvDSKhachThue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var maKH = dgvDSKhachThue.Rows[e.RowIndex].Cells[1].Value.ToString();
                var khachHang = khachHangServices.FindByID(maKH);
                if (khachHang != null)
                {
                    txtHoTen.Text = khachHang.HoTen;
                    txtCMND.Text = khachHang.CMND_CCCD;
                    txtDiaChi.Text = khachHang.DiaChiThuongTru;
                    txtSDT.Text = khachHang.SDT;
                    ngaySinh.Value = khachHang.NgaySinh ?? DateTime.Now;
                    radNam.Checked = khachHang.GioiTinh == "Nam";
                    radNu.Checked = khachHang.GioiTinh == "Nữ";
                    loadAVT(maKH);
                }
            }
        }
        // Kiem tra cccd/cmnd
        private bool checkID(string id)
        {
            if (id.Length != 12 && id.Length != 9)
            {
                MessageBox.Show("Vui lòng nhập CCCD hoặc CMND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(id, @"^\d+$"))
            {
                MessageBox.Show("ID chỉ là các kí tự số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // kiem tra sdt
        private bool checkSDT(string id)
        {
            if (id.Length != 10)
            {
                MessageBox.Show("Vui lòng nhập sdt có 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(id, @"^\d+$"))
            {
                MessageBox.Show("SDT chỉ là các kí tự số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void clearData()
        {
            //cmbSoPhong.SelectedValue = 0;
            txtHoTen.Text = "";
            txtCMND.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            radNam.Checked = true;
            ngaySinh.Value = DateTime.Now;
            Avatar.Image = null;
            avtFilePath = string.Empty;
            ngayThue.Value = DateTime.Now;
        }
        // Hàm kiểm tra text box
        private bool KtraTextBox()
        {
            if (ngaySinh.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtCMND.Text) || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtDiaChi.Text) )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (checkID(txtCMND.Text) == false)
                return false;
            if (checkSDT(txtSDT.Text) == false)
                return false;
            return true;
        }
        // Viết chức năng thêm khách thuê và thêm hợp đồng trong chức năng này
        private void btnThemKhachThue_Click(object sender, EventArgs e)
        {
            var selectedSoPhong = cmbSoPhong.SelectedValue?.ToString();
            var selectedLoaiPhong = cmbLoaiPhong.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(selectedSoPhong) || string.IsNullOrEmpty(selectedLoaiPhong))
            {
                MessageBox.Show("Vui lòng chọn phòng trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (KtraTextBox() == false)
            {
                return;
            }
            int demKT = khachHangServices.DemSLKhach(selectedSoPhong); // Đếm số lượng khách thuê trong phòng
            int loaiPhong = loaiPhongServices.KiemTraLoaiPhong(selectedLoaiPhong); // Kiểm tra loại phòng (LP01 hoặc LP02)

            // Kiểm tra điều kiện sức chứa
            if ((loaiPhong == 0 && demKT < 2) || (loaiPhong == 1 && demKT < 3))
            {
                // Tạo khách thuê mới
                var khachThue = new KhachThue
                {
                    MaKhachThue = khachHangServices.TaoMaKhachThue(),
                    HoTen = txtHoTen.Text,
                    CMND_CCCD = txtCMND.Text,
                    DiaChiThuongTru = txtDiaChi.Text,
                    SDT = txtSDT.Text,
                    NgayBatDauThue = ngayThue.Value,
                    GioiTinh = radNam.Checked ? "Nam" : "Nữ",
                    NgaySinh = ngaySinh.Value,
                    MaPhong = selectedSoPhong
                };
                if (!string.IsNullOrEmpty(avtFilePath))
                {
                    string avtFileName = saveAVT(avtFilePath, txtHoTen.Text);
                    if (!string.IsNullOrEmpty(avtFileName))
                    {
                        khachThue.Avatar = avtFileName;
                    }
                }
                khachHangServices.ThemKhachThue(khachThue);
                //tạo hợp đồng theo khách thuê
                var hopDong = new HopDong
                {
                    MaHopDong = hopDongServices.TaoMaHopDong(),
                    MaPhong = khachThue.MaPhong,
                    MaKhachThue = khachThue.MaKhachThue,
                    NgayKyHopDong = khachThue.NgayBatDauThue,
                    NgayKetThuc = khachThue.NgayBatDauThue?.AddMonths(6), // Ngày kết thúc hợp đồng sau 6 tháng
                    TinhTrang = "Đang hiệu lực"
                };
                hopDongServices.ThemHopDong(hopDong);
                //Cap nhat tinh trang phong
                phongTroServices.CapNhatTinhTrangPhong(selectedSoPhong, "Đang thuê");
                MessageBox.Show("Thêm khách thuê thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var khachThueMoi = khachHangServices.LayKhachThueTheoMaPhong(selectedSoPhong);
                bindGrid(khachThueMoi);
                DataUpdate?.Invoke();
                clearData();
                avtFilePath = string.Empty;
            }
            else
            {
                MessageBox.Show("Phòng này đã đủ người. Vui lòng chọn phòng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        // viết hàm cập nhật khách thuê và hop đồng
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDSKhachThue.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDSKhachThue.SelectedRows[0];
                var maKH = selectedRow.Cells[1].Value.ToString();
                var khachHang = khachHangServices.FindByID(maKH);
                if (KtraTextBox() == false)
                {
                    return;
                }
                if (khachHang != null)
                {
                    khachHang.HoTen = txtHoTen.Text;
                    khachHang.CMND_CCCD = txtCMND.Text;
                    khachHang.DiaChiThuongTru = txtDiaChi.Text;
                    khachHang.SDT = txtSDT.Text;
                    khachHang.NgaySinh = ngaySinh.Value;
                    khachHang.NgayBatDauThue = ngayThue.Value;
                    khachHang.GioiTinh = radNam.Checked ? "Nam" : "Nữ";

                    // Kiem tra file co duoc chon k
                    if (!string.IsNullOrEmpty(avtFilePath))
                    {
                        string avtFileName = saveAVT(avtFilePath, maKH);
                        if (!string.IsNullOrEmpty(avtFileName))
                        {
                            khachHang.Avatar = avtFileName;
                        }
                    }
                    khachHangServices.CapNhatKhachThue(khachHang);
                    var hopDong = hopDongServices.FindByID(khachHang.MaKhachThue);
                    hopDongServices.CapNhatHopDong(hopDong.MaHopDong, khachHang.NgayBatDauThue);
                    MessageBox.Show("Cập nhật thông tin khách thuê thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var khachThueMoi = khachHangServices.LayKhachThueTheoMaPhong(khachHang.MaPhong);
                    bindGrid(khachThueMoi);
                    
                    clearData();
                }
            }
            // Cập nhật form trang chủ
            DataUpdate?.Invoke();
        }
        // Viết sự kiện xóa khách thuê
        private void btnXoa_Click(object sender, EventArgs e)
        {
            var selectedSoPhong = cmbSoPhong.SelectedValue?.ToString();
            if (dgvDSKhachThue.SelectedRows.Count > 0)
            {
                var maKH = dgvDSKhachThue.SelectedRows[0].Cells[1].Value.ToString();
                hoaDonServices.XoaHoaDon(hopDongServices.FindByID(maKH).MaHopDong);
                hopDongServices.XoaHopDong(maKH);
                khachHangServices.XoaKhachThue(maKH);
                var kiemTraPhong = phongTroServices.KiemTraPhongConKhachThueKhong(selectedSoPhong);
                if (kiemTraPhong == 0)
                {
                    phongTroServices.CapNhatTinhTrangPhong(selectedSoPhong, "Trống");
                }
                bindGrid(khachHangServices.GetAll());
                DataUpdate?.Invoke();
                clearData();
                MessageBox.Show("Xóa khách thuê thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách thuê cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var date = DateTime.Now.ToString("dd/MM/yyyy");
            var time = DateTime.Now.ToString("hh:mm:ss tt");
            this.toolStripStatusLabel1.Text = string.Format($"Hôm nay là ngày: {date} - Bây giờ là: {time}");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            clearData();
            var list = khachHangServices.GetAll();
            bindGrid(list);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenKhachHang = txtTenKH.Text.Trim();
            if (string.IsNullOrEmpty(tenKhachHang))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var khachThue = khachHangServices.GetAll().Where(kh => RemoveDiacritics(kh.HoTen).IndexOf(RemoveDiacritics(tenKhachHang), StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (khachThue.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bindGrid(khachThue);
            }
        }

        private string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
        
    }
}
