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
    public partial class QuanLyNhanVien : Form
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CapNhatThongTinNhanVien fm = new CapNhatThongTinNhanVien();
            fm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Home fm = new Home();
            //fm.Show();
        }
        //bindgrid
        private void bindgird(List<PHANCONG> listPhanCong) {
            dataGridView1.Rows.Clear();
            foreach(var item in listPhanCong)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.MaNV;
                dataGridView1.Rows[index].Cells[1].Value = item.NHANVIEN.TenNV;
                dataGridView1.Rows[index].Cells[2].Value = item.NHANVIEN.ChucVu;
                dataGridView1.Rows[index].Cells[3].Value = item.NHANVIEN.DienThoai;
                dataGridView1.Rows[index].Cells[4].Value = item.Ca;
    
            }

            
        }
        private void load()
        {
            Model1 context = new Model1();
            List<PHANCONG> listPhanCong = context.PHANCONGs.ToList();
            bindgird(listPhanCong);
        }
        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnUpdateCaLam_Click(object sender, EventArgs e)
        {
            this.Hide();
            CapNhatLichLamViec fm = new CapNhatLichLamViec();
            fm.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
