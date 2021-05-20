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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        //hien thi form quan ly phong
        private void qUẢNLÝToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyPhong fm = new QuanLyPhong();
            fm.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyKhachHang fm = new QuanLyKhachHang();
            fm.Show();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CapNhatThongTinNhanVien fm = new CapNhatThongTinNhanVien();
            fm.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult h = MessageBox.Show("Bạn có chắc muốn đăng xuất không ?", "Message", MessageBoxButtons.YesNo);
                if (h == DialogResult.Yes)
                {
                    this.Hide();
                    Login lg1 = new Login();
                    lg1.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChiTietPhieuDatPhong fm = new ChiTietPhieuDatPhong();
            fm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rightclick(button2); UpdateColor(button2);Click(button2);
          
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        //sự kien Rightclic
        private void Rightclick(Button x)
        {
            if (x.BackColor == Color.White)
            {
                ContextMenu cm = new ContextMenu();
                cm.MenuItems.Add("Đặt phòng",new EventHandler(btnDatPhong_Click));
                cm.MenuItems.Add("Xem thông tin phòng",new EventHandler(quảnLýPhòngToolStripMenuItem_Click));
                x.ContextMenu = cm;
            }
            else if (x.BackColor == Color.Red)
            {
                ContextMenu cm = new ContextMenu();
                cm.MenuItems.Add("Xem dịch vụ",new EventHandler(btnXemPhong_Click));
                cm.MenuItems.Add("Trả phòng",new EventHandler(btnTraPhong_Click));
                x.ContextMenu = cm;
            }
        }
        //set sự kiên click
        private void Click(Button x)
        {
            if(x.BackColor == Color.Red)
            {
                HoaDon fm = new HoaDon();
                fm.Show();
            }
            if(x.BackColor == Color.White)
            {
                ChiTietPhieuDatPhong fm = new ChiTietPhieuDatPhong();
                fm.Show();
            }
           
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            Rightclick(button1); Click(button1);
        
       
        }
        private void setMau()//set màu cho các nút
        {
            UpdateColor(button1); UpdateColor(button2); UpdateColor(button3); UpdateColor(button4); UpdateColor(button5); UpdateColor(button6);
            UpdateColor(button7); UpdateColor(button8); UpdateColor(button9); UpdateColor(button10); UpdateColor(button11); UpdateColor(button12);
            UpdateColor(button13); UpdateColor(button14); UpdateColor(button15); UpdateColor(button16); UpdateColor(button17); UpdateColor(button18);
            UpdateColor(button19); UpdateColor(button20); UpdateColor(button21); UpdateColor(button22); UpdateColor(button23); UpdateColor(button24); UpdateColor(button25);
        }
        private void load()//load 
        {
            Model1 context = new Model1();
            List<PHONG> listPhong = context.PHONGs.ToList();//lấy ds phòng
            List<CHITIETHOADON> listdv = context.CHITIETHOADONs.ToList();
          
            setMau();
        

        }
      
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //Cập nhật màu sắc cho các nút
        private void UpdateColor(Button x)
        {
            Model1 context = new Model1();
            List<PHONG> listPhong = context.PHONGs.ToList();//lấy ds phòng
            foreach(var item in listPhong)
            {
                if(item.MaPhong == x.Text)
                {
                    if(item.TrangThai == "Confirmed")
                    {
                        x.BackColor = Color.Red;
                    }
                    else if(item.TrangThai == "Empty")
                    {
                        x.BackColor = Color.White;
                    }
                }
            }
        }
        //
        private void Home_Load(object sender, EventArgs e)
        {           
            load();
   
   

        }
      
        private void button6_Click(object sender, EventArgs e)
        {
            Rightclick(button6); Click(button6);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btnXemPhong_Click(object sender, EventArgs e)
        {
            //this.Hide();
            PhieuSuDungDichVu fm = new PhieuSuDungDichVu();
            fm.Show();
        }

        private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LienHe fm = new LienHe();
            fm.Show();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void quảnLýPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            QuanLyPhong fm = new QuanLyPhong();
            fm.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            QuanLyKhachHang fm = new QuanLyKhachHang();
            fm.Show();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            QuanLyNhanVien fm = new QuanLyNhanVien();
            fm.Show();
        }

        private void liênHệToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            LienHe fm = new LienHe();
            fm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rightclick(button3); Click(button3);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Rightclick(button4); Click(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Rightclick(button5); Click(button5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Rightclick(button7); Click(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Rightclick(button8); Click(button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Rightclick(button9); Click(button9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Rightclick(button10); Click(button10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Rightclick(button11); Click(button11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Rightclick(button12); Click(button12);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Rightclick(button13); Click(button13);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Rightclick(button14); Click(button14);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Rightclick(button15); Click(button15);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Rightclick(button16); Click(button16);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Rightclick(button17); Click(button17);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Rightclick(button18); Click(button18);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Rightclick(button19); Click(button19);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Rightclick(button20); Click(button20);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Rightclick(button21); Click(button21);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Rightclick(button22); Click(button22);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Rightclick(button23); Click(button23);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Rightclick(button24); Click(button24);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Rightclick(button25); Click(button25);
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThanhToan_TraPhong fm = new ThanhToan_TraPhong();
            fm.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn có chắc đăng xuất không?", "Message", MessageBoxButtons.YesNo);
            if (h == DialogResult.Yes)
            {
                this.Hide();
                Login fm = new Login(); fm.Show();
            }
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report fm = new Report();
            fm.Show();
        }

        private void xuấtFileExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ex fm = new Ex();
            fm.Show();
        }

        private void button1_BackColorChanged(object sender, EventArgs e)
        {
            
        }
    }
    
}