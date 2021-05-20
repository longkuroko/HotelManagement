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
    public partial class QuanLyPhong : Form
    {
        public QuanLyPhong()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Home fm = new Home();
            //fm.Show();
        }

        private void btnCapNhatVatTu_Click(object sender, EventArgs e)
        {
            //this.Hide();
            QuanLyVatTu fm = new QuanLyVatTu();
            fm.Show();
        }

        private void btnCapNhatDichVu_Click(object sender, EventArgs e)
        {
            //this.Hide();
            QuanLyDichVu fm = new QuanLyDichVu();
            fm.Show();

        }
        private void Load_Data()
        {
            
            try
            {
                Model1 context = new Model1();
                List<PHONG> listPhong = context.PHONGs.ToList();
                BindGrid(listPhong);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
       
        //BindGrid
        private void BindGrid(List<PHONG> listPhong)
        {
            dgvQLPhong.Rows.Clear();
            foreach(var item in listPhong)
            {
                int index = dgvQLPhong.Rows.Add();
                dgvQLPhong.Rows[index].Cells[0].Value = item.MaPhong;
                dgvQLPhong.Rows[index].Cells[1].Value = item.MaLoaiPhong;
                dgvQLPhong.Rows[index].Cells[2].Value = item.STTTang;
                dgvQLPhong.Rows[index].Cells[3].Value = item.GiaTien;
                dgvQLPhong.Rows[index].Cells[4].Value = item.TrangThai;

            }
        }
        private void QuanLyPhong_Load(object sender, EventArgs e)
        {
            Load_Data();
            SetGridViewStyle(dgvQLPhong);
            
        }
        public void SetGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgview.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgview.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgview.BackgroundColor = Color.White;
            dgview.EnableHeadersVisualStyles = false;
            dgview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgview.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgview.AllowUserToDeleteRows = false;
            dgview.AllowUserToAddRows = false;
            dgview.AllowUserToOrderColumns = true;
            dgview.MultiSelect = false;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void btnCapNhatLoaiPhong_Click(object sender, EventArgs e)
        {
            
            CapNhatLoaiPhong fm = new CapNhatLoaiPhong();
            fm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void QuanLyPhong_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            //Home fm = new Home();
            //fm.Show();
        }
    }
}
