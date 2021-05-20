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
    public partial class QuanLyDichVu : Form
    {
        public QuanLyDichVu()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            //QuanLyPhong fm = new QuanLyPhong();
            //fm.Show();
        }
        //bindgrid
        private void BindGrid(List<DICHVU> listDichVu)
        {
            Model1 context = new Model1();
            dgvDichVu.Rows.Clear();
            foreach(var item in listDichVu)
            {
                int index = dgvDichVu.Rows.Add();
                dgvDichVu.Rows[index].Cells[0].Value = item.MaDichVu;
                dgvDichVu.Rows[index].Cells[1].Value = item.TenDichVu;
                dgvDichVu.Rows[index].Cells[2].Value = item.DonGiaDV;
                dgvDichVu.Rows[index].Cells[3].Value = item.GhiChu;

            }
        }
        //load data
        private void load()
        {
            Model1 context = new Model1();
            List<DICHVU> listDichVu = context.DICHVUs.ToList();//lấy ds dịch vụ
            BindGrid(listDichVu);
        }
        //them dich vu
        private void InserdDichVu()
        {
            using (var context = new Model1())
            {
                DICHVU s = new DICHVU()
                {
                    MaDichVu = txtMaDV.Text,
                    TenDichVu = txtTenDV.Text,
                    DonGiaDV = float.Parse(txtGiaDV.Text),
                    GhiChu = txtGhiChu.Text
                };
                context.DICHVUs.Add(s);
                context.SaveChanges();
            }
        }
        private void QuanLyDichVu_Load(object sender, EventArgs e)
        {
            load();
            SetGridViewStyle(dgvDichVu);
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
        private void btnThemDV_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            DICHVU s = context.DICHVUs.FirstOrDefault(p => p.MaDichVu == txtMaDV.Text);
            try
            {
                if (txtMaDV.Text == "" || txtTenDV.Text == "" || txtGiaDV.Text == "")
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                if (s == null)
                {
                    InserdDichVu();
                    cleartextbox();
                    load();

                    MessageBox.Show("Thêm mới thành công!", "Message", MessageBoxButtons.OK);
                }
                else
                {
                    s.TenDichVu = txtTenDV.Text;
                    s.DonGiaDV = float.Parse(txtGiaDV.Text);
                    s.GhiChu = txtGhiChu.Text;

                    context.SaveChanges();
                    load();
                    MessageBox.Show("Mã dịch vụ đã tồn tại!, Update thành công", "Message", MessageBoxButtons.OK);
                }
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            DICHVU s = context.DICHVUs.FirstOrDefault(p => p.MaDichVu == txtMaDV.Text);
            if (txtMaDV.Text == "")
                MessageBox.Show("Vui lòng nhập Mã phòng cần xóa!");
            if (s != null)
            {
                DialogResult h = MessageBox.Show("Bạn có chắc muốn xóa không!", "thông báo", MessageBoxButtons.YesNo);
                if (h == DialogResult.Yes)
                {
                    context.DICHVUs.Remove(s);
                    context.SaveChanges();
                    load();
                    MessageBox.Show("Xóa Thành Công!", "thông báo", MessageBoxButtons.OK);
                }
            }
        }
        //clear txtboxx
        private void cleartextbox()
        {
            txtMaDV.Clear();
            txtTenDV.Clear();
            txtGiaDV.Clear();
            txtGhiChu.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<DICHVU> s = context.DICHVUs.ToList();
            DICHVU x = context.DICHVUs.FirstOrDefault(p => p.MaDichVu == txtMaDV.Text);
            if (x != null)
            {
                x.TenDichVu = txtTenDV.Text;
                x.DonGiaDV = float.Parse(txtGiaDV.Text);
                x.GhiChu = txtGhiChu.Text;
                context.SaveChanges();
                MessageBox.Show("Sửa thành công");
                cleartextbox();
                load();

            }
            else
                MessageBox.Show("Không tìm thấy mã dịch vụ");
           
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;

            
            txtMaDV.Text = dgvDichVu.Rows[numrow].Cells[0].Value.ToString();
            txtTenDV.Text = dgvDichVu.Rows[numrow].Cells[1].Value.ToString();
            var x = dgvDichVu.Rows[numrow].Cells[2].Value.ToString();
            txtGiaDV.Text = x;
            txtGhiChu.Text = dgvDichVu.Rows[numrow].Cells[3].Value.ToString();
        }
    }
}
