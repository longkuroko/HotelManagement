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
using System.Net;
using System.Net.Mail;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
namespace QuanLyNhaNghi
{
    public partial class EmailLogin : Form
    {
        public EmailLogin()
        {
            InitializeComponent();
        }

        private void EmailLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { // tạo một tin nhắn và thêm những thông tin cần thiết như: ai gửi, người nhận, tên tiêu đề, và có đôi lời gì cần nhắn nhủ
                Model1 context = new Model1();
                List<TAIKHOAN> x = context.TAIKHOANs.ToList();
                foreach (var item in x)
                {
                    if (item.TenDangNhap == textBox2.Text)
                    {
                        MailMessage mail = new MailMessage("longsteve.jobs@gmail.com", textBox1.Text, "matkhau", "mật khẩu của bạn: "+item.MatKhau);
                        mail.IsBodyHtml = true;
                        SmtpClient client = new SmtpClient("smtp.gmail.com");
                        client.Host = "smtp.gmail.com";
                        //ta không dùng cái mặc định đâu, mà sẽ dùng cái của riêng mình
                        client.UseDefaultCredentials = false;
                        client.Port = 587; //vì sử dụng Gmail nên mình dùng port 587
                                           // thêm vào credential vì SMTP server cần nó để biết được email + password của email đó mà bạn đang dùng
                        client.Credentials = new System.Net.NetworkCredential("longsteve.jobs@gmail.com", "0902964036");
                        client.EnableSsl = true; //vì ta cần thiết lập kết nối SSL với SMTP server nên cần gán nó bằng true
                        client.Send(mail);
                        MessageBox.Show("Đã gửi tin nhắn thành công!", "Thành Công", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập không đúng");
                    }
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();


            }
        }
    }
}
