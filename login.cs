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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtAccount.Text == "Tên đăng nhập")
            {
                txtAccount.Text = "";
                txtAccount.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtAccount.Text == "")
            {
                txtAccount.Text = "Tên đăng nhập";
                txtAccount.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Mật khẩu")
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.Text = "Mật khẩu";
                txtPassword.ForeColor = Color.Silver;
            }
        }
        private void DangNhap(List<TAIKHOAN> tk)
        {
            foreach(var item in tk)
            {
                if(item.TenDangNhap== txtAccount.Text)
                {
                    if(item.MatKhau == txtPassword.Text)
                    {
                        this.Hide();
                        Home fm = new Home();
                        MessageBox.Show("Đăng nhập thành công!");
                        fm.Show();
                        
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "message", MessageBoxButtons.OK);
                    }
                }
            }
        }
        private void QuenMK(List<TAIKHOAN> tk)
        {
           
            foreach (var item in tk)
            {
              
                if (item.TenDangNhap == txtAccount.Text)
                {
                        MessageBox.Show("Mật khẩu là :" + item.MatKhau);
                        break;
                }
            }
            MessageBox.Show("Tên tài khoản không chính xác!");

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAccount.Text == "" || txtPassword.Text == "")
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                Model1 context = new Model1();
                List<TAIKHOAN> tk = context.TAIKHOANs.ToList();
                DangNhap(tk);
            }
            catch { }

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnQuenMK_Click(object sender, EventArgs e)
        {
            EmailLogin fm = new EmailLogin();
            fm.Show();
            //Model1 context = new Model1();
            //List<TAIKHOAN> mk = context.TAIKHOANs.ToList();
            //QuenMK(mk);
                                 
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DANGKYTAIKHOAN fm = new DANGKYTAIKHOAN();
            fm.Show();
        }
    }
}
