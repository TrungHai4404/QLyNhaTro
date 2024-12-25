using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLyNhaTro_project
{
    public partial class frmQLyKhach : Form
    {
        public frmQLyKhach()
        {
            InitializeComponent();
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
                    gbDanhSachPhongTro.ClientRectangle.Width ,
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
    }
}
