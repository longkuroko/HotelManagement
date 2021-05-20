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
    public partial class ThemPhieuDichVu : Form
    {
        public ThemPhieuDichVu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            PHIEUDICHVU s = context.PHIEUDICHVUs.FirstOrDefault(p => p.SoPhieuDV == txtSoDV.Text);
            CHITIETDICHVU x = context.CHITIETDICHVUs.FirstOrDefault(p => p.SoPhieuDV == txtSoDV.Text);
            if (s != null)
            {
                MessageBox.Show("Phiếu dịch vụ đã tồn tại!");
            }
            else
            {
                InsertPhieuDichVu();
                InsertDv();
                context.SaveChanges();
                MessageBox.Show("Thêm mới thành công!");
            
            }
       
        }

        private void ThemPhieuDichVu_Load(object sender, EventArgs e)
        {
            load();
        }
        private void FillCMBDichVu(List<DICHVU> listDichVu)
        {
            cmbDichVu.DataSource = listDichVu;
            cmbDichVu.DisplayMember = "TenDichVu";
            cmbDichVu.ValueMember = "MaDichVu";
        }
       
        private void load()
        {
            Model1 context = new Model1();
            List<CHITIETTHUEPHONG> listThuePhong = context.CHITIETTHUEPHONGs.ToList();
            List<CHITIETHOADON> lishd = context.CHITIETHOADONs.ToList();
            //FillHOADON(lishd);
            List<DICHVU> lisdv = context.DICHVUs.ToList();
            FillCMBDichVu(lisdv);
            FillPhieuThuePhong(listThuePhong);
        }

        //fill cmbSoPhieuThue
        //hien thi nhung phong dang thue nhung ko su dung dich vu
        private void FillPhieuThuePhong(List<CHITIETTHUEPHONG> listThuePhong)
        {
            Model1 context = new Model1();
            List<CHITIETTHUEPHONG> thuephong = new List<CHITIETTHUEPHONG>();
            List<PHIEUDICHVU> lisdv = context.PHIEUDICHVUs.ToList();
            foreach(var item in listThuePhong)
            {

                PHIEUDICHVU s = context.PHIEUDICHVUs.FirstOrDefault(p => p.SoPhieuTP == item.SoPhieuTP);
                    if(s==null)
                    {
                        thuephong.Add(item);
                    }
                    
                
                           
            }
            cmbMaPhong.DataSource = thuephong;
            cmbMaPhong.DisplayMember = "MaPhong";
            cmbMaPhong.ValueMember = "MaPhong";

            comboBox1.DataSource = thuephong;
            comboBox1.DisplayMember = "SoPhieuTP";
            comboBox1.ValueMember = "SoPhieuTP";

            txtSoDV.Text = "DV" + comboBox1.Text;


        }
        //THÊM PHIẾU DỊCH VỤ
        private void InsertPhieuDichVu()
        {
            using (var context = new Model1())
            {
                PHIEUDICHVU s = new PHIEUDICHVU()
                {
                    SoPhieuDV = txtSoDV.Text,
                    SoPhieuTP = comboBox1.SelectedValue.ToString(),
                    MaPhong = cmbMaPhong.SelectedValue.ToString(),
                    NgayThucHienDV = dateTimePicker1.Value,
                    TongTienDV = 0

                };
                context.PHIEUDICHVUs.Add(s);
                context.SaveChanges();
            }
        }
        //insert dichvu
        private void InsertDv()
        {
            using(var context= new Model1())
            {
                CHITIETDICHVU s = new CHITIETDICHVU()
                {
                    SoPhieuDV = txtSoDV.Text,
                    MaDichVu = cmbDichVu.SelectedValue.ToString(),
                    SoLuong = Convert.ToInt32(txtSLSD.Text)

                };
                context.CHITIETDICHVUs.Add(s);
                context.SaveChanges();
                
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
        
        private void btnXóa_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<PHIEUDICHVU> listphieudv = context.PHIEUDICHVUs.ToList();
            PHIEUDICHVU s = context.PHIEUDICHVUs.FirstOrDefault(p => p.SoPhieuDV == txtSoDV.Text);
            if (s != null)
            {
                context.PHIEUDICHVUs.Remove(s);
                context.SaveChanges();
                MessageBox.Show("Xóa thành công");

            }
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoDV.Text = "DV" + comboBox1.Text;
        }
    }
}
