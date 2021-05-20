using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaNghi.Model;
namespace QuanLyNhaNghi
{
    public partial class DANGKYTAIKHOAN : Form
    {
        public DANGKYTAIKHOAN()
        {
            InitializeComponent();
        }

        private void DANGKYTAIKHOAN_Load(object sender, EventArgs e)
        {

        }
        //tạo thêm tài khoản
        private void TaoTK()
        {
            using (var context = new Model1())
            {
                TAIKHOAN tk = new TAIKHOAN()
                {
                    TenDangNhap = txtAccount.Text,
                    MatKhau = txtPassword.Text
                };
                context.TAIKHOANs.Add(tk);
                context.SaveChanges();
            }
        }       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            TAIKHOAN taikhoan = context.TAIKHOANs.FirstOrDefault(p => p.TenDangNhap == txtAccount.Text);
            if (txtAccount.Text == "" || txtPassword.Text == "")
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            if(taikhoan == null)
            {
                if(txtPassword.Text == txtReMK.Text)
                {
                    TaoTK();
                    context.SaveChanges();
                    MessageBox.Show("Đăng ký thành công !");
                }
                else
                {
                    MessageBox.Show("Mật khẩu không khớp !");
                }
            
            }
            else
            {
                MessageBox.Show("Tên tài khoản đã tồn tại!");
            }
            

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login fm = new Login();
            fm.Show();
        }

        private void DANGKYTAIKHOAN_FormClosed(object sender, FormClosedEventArgs e)
        {

            this.Hide();
            Login fm = new Login();
            fm.Show();
        }
    }
}
