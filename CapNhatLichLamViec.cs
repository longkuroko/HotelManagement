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
    public partial class CapNhatLichLamViec : Form
    {
        public CapNhatLichLamViec()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void UpdateCa()
        {
            Model1 context = new Model1();
            try
            {
                PHANCONG s = context.PHANCONGs.FirstOrDefault(p => p.MaNV.ToLower() == txtMaNV.Text.ToLower());
                if (s != null)
                {
                    s.Ca = comboBox1.SelectedItem.ToString();
                    context.SaveChanges();
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên!", "message", MessageBoxButtons.OK);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CapNhatLichLamViec_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateCa();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            //QuanLyNhanVien fm = new QuanLyNhanVien();
            //fm.Show();
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            Model1 contetxt = new Model1();
            List<NHANVIEN> listKhachHang = contetxt.NHANVIENs.ToList();
            foreach(var item in listKhachHang)
            {
                
                if(item.MaNV.ToLower() == txtMaNV.Text.ToLower())
                {
                    txtTen.Text = item.TenNV;
                }
                if (txtMaNV.Text == "")
                {
                    txtTen.Text = "";
                }
            }
        }
    }
}
