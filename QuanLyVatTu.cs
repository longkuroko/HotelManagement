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
    public partial class QuanLyVatTu : Form
    {
        public QuanLyVatTu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            //QuanLyPhong fm = new QuanLyPhong();
            //fm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void fillMaPhong(List<PHONG> listPhong)
        {
            cmbPhong.DataSource = listPhong;
            cmbPhong.DisplayMember = "MaPhong";
            cmbPhong.ValueMember = "MaPhong";
        }
        private void fillTienNghi(List<LOAITIENNGHI> listLoaiTienNghi)
        {
            cmbTienNghi.DataSource = listLoaiTienNghi;
            cmbTienNghi.DisplayMember = "TenLoaiTienNghi";
            cmbTienNghi.ValueMember = "MaLoaiTienNghi";
        }
        //BindGrid
        private void BindGrid(List<TIENNGHI> listTienNghi)
        {
            dgvTienNghi.Rows.Clear();
          
            foreach (var item in listTienNghi)
            {
                if (item.MaPhong == cmbPhong.SelectedValue.ToString())
                {

                    int index = dgvTienNghi.Rows.Add();
                    dgvTienNghi.Rows[index].Cells[0].Value = item.MaLoaiTienNghi;
                    dgvTienNghi.Rows[index].Cells[1].Value = item.LOAITIENNGHI.TenLoaiTienNghi;
                    dgvTienNghi.Rows[index].Cells[2].Value = item.NgayBatDauTrangBi;
                    dgvTienNghi.Rows[index].Cells[3].Value = item.LOAITIENNGHI.TinhTrang;
                

                }
            }
        }
       
        private void load()
        {
            Model1 context = new Model1();
            List<TIENNGHI> listTienNghi = context.TIENNGHIs.ToList();//lấy danh sách tiện nghi
            List<LOAITIENNGHI> listLoaiTienNghi = context.LOAITIENNGHIs.ToList();//ds loại tiện nghi
            List<PHONG> listPhong = context.PHONGs.ToList();//ds phòng
            fillMaPhong(listPhong);
            fillTienNghi(listLoaiTienNghi);
            BindGrid(listTienNghi);
        }

        private void QuanLyVatTu_Load(object sender, EventArgs e)
        {
            load();
            SetGridViewStyle(dgvTienNghi);
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
        private void cmbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            Model1 context = new Model1();
            List<TIENNGHI> listTienNghi = context.TIENNGHIs.ToList();//lấy danh sách tiện nghi
            List<TIENNGHI> s = new List<TIENNGHI>();

            foreach (var item in listTienNghi)
            {
                if (item.MaPhong == cmbPhong.SelectedValue.ToString())
                {
                    s.Add(item);
                }

            }
            foreach (var item in s)
            {
                BindGrid(s);
            }
        }
        //Thêm vật tư
        private void InsertTienNghi()
        {
            using (var context = new Model1())
            {
                DateTime savenow = new DateTime();
                TIENNGHI s = new TIENNGHI()
                {
                    MaLoaiTienNghi = cmbTienNghi.SelectedValue.ToString(),
                    MaPhong = cmbPhong.SelectedValue.ToString(),                
                    NgayBatDauTrangBi = savenow.Date,

                };
                context.TIENNGHIs.Add(s);
                context.SaveChanges();
            }
        }
      
        private void btnAddVT_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<TIENNGHI> listTienNghi = context.TIENNGHIs.Where(p => p.MaPhong == cmbPhong.SelectedValue.ToString()).ToList();
            try {
                foreach(var item in listTienNghi)
                {
                    if(item.MaLoaiTienNghi == cmbTienNghi.SelectedValue.ToString())
                    {                              
                        MessageBox.Show("Thêm thành công!");
                    }
                    else
                    {
                       InsertTienNghi();
                       MessageBox.Show("Thêm thành công!");
                    }
                    context.SaveChanges();
                    load();
                }

            }
            catch
            {
               
            }
            
           
        }

        private void btnXoaVT_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            try
            {
                TIENNGHI s = context.TIENNGHIs.FirstOrDefault(p => p.MaLoaiTienNghi == cmbTienNghi.SelectedValue.ToString());
                if (s != null)
                {
                    context.TIENNGHIs.Remove(s);
                    context.SaveChanges();
                    load();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvTienNghi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbPhong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind.PerformClick();
            }
        }
    }
}
