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
    public partial class PhieuSuDungDichVu : Form
    {
        public PhieuSuDungDichVu()
        {
            InitializeComponent();
        }
        //Fill combobox dich vụ
        private void FillCMBDichVu(List<DICHVU> listDichVu)
        {
            cmbDichVu.DataSource = listDichVu;
            cmbDichVu.DisplayMember = "TenDichVu";
            cmbDichVu.ValueMember = "MaDichVu";
        }

        private void FillPhong(List<PHONG> listPhong)
        {
            List<PHONG> s = new List<PHONG>();
            foreach (var item in listPhong)
            {

                if (item.TrangThai == "Confirmed")
                {
                    s.Add(item);

                }

            }
            cmbMaPhong.DataSource = s;
            cmbMaPhong.DisplayMember = "MaPhong";
            cmbMaPhong.ValueMember = "MaPhong";
        }
     
        private void load()
        {
            Model1 context = new Model1();
            List<DICHVU> listDichVu = context.DICHVUs.ToList();//lấy ds dịch vụ
          
            List<CHITIETDICHVU> listCTDV = context.CHITIETDICHVUs.ToList();
            List<PHONG> listphong = context.PHONGs.ToList();
            List<CHITIETHOADON> lishd = context.CHITIETHOADONs.ToList();
            List<DICHVU> dv = context.DICHVUs.ToList();
            addlistview(dv);
            FillCMBDichVu(listDichVu);
            FillPhong(listphong);
            BindGrid(listCTDV);
            //FillHOADON(lishd); context.SaveChanges();
            //CTPhieuTheoPhong(listCTDV);

        }
       //thêm dịch vụ vào listview
        private void addlistview(List<DICHVU> listdv)
        {
        
        }
        private void PhieuSuDungDichVu_Load(object sender, EventArgs e)
        {
            load();
            SetGridViewStyle(dgvSuDungDV);
            
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
        private void BindGrid(List<CHITIETDICHVU> listCTDV)
        {
            Model1 context = new Model1();
            dgvSuDungDV.Rows.Clear();
        
            foreach (var item in listCTDV)
            {
               
                    int index = dgvSuDungDV.Rows.Add();              
                    dgvSuDungDV.Rows[index].Cells[0].Value = item.SoPhieuDV;
                    dgvSuDungDV.Rows[index].Cells[1].Value = item.DICHVU.TenDichVu;
                    dgvSuDungDV.Rows[index].Cells[2].Value = item.SoLuong;
                    dgvSuDungDV.Rows[index].Cells[3].Value = item.PHIEUDICHVU.NgayThucHienDV;
                    dgvSuDungDV.Rows[index].Cells[4].Value = (item.SoLuong * item.DICHVU.DonGiaDV);
            }
            
        }
        //Lọc phiếu sử dụng dịch vụ theo phòng
        private void CTPhieuTheoPhong(List<CHITIETDICHVU> listDV)
        {
            Model1 context = new Model1();
            List<CHITIETDICHVU> dichvu = new List<CHITIETDICHVU>();
            List<PHIEUDICHVU> phieudichvu = context.PHIEUDICHVUs.ToList();
            List<PHIEUDICHVU> s = context.PHIEUDICHVUs.Where(p => p.MaPhong == cmbMaPhong.SelectedValue.ToString()).ToList();
            foreach (var item in listDV)
            {
                var phantucuoi = s[s.Count - 1]; // lấy phần tử cuối trong danh sách
                if (phantucuoi.SoPhieuDV == item.SoPhieuDV)
                {


                    dichvu.Add(item);

                }
                BindGrid(dichvu);
            }        
           
        }
     
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Home fm = new Home();
            //fm.Show();
        }
        //Insert Dịch vụ
        private void InsertPhieuDichVu()
        {
            try
            {
               using(var context = new Model1())
               {
                    List<PHIEUDICHVU> phieudv = context.PHIEUDICHVUs.ToList();
                    List<PHIEUDICHVU> x = context.PHIEUDICHVUs.Where(p => p.MaPhong == cmbMaPhong.SelectedValue.ToString()).ToList();
                    foreach (var item in phieudv)
                    {
                        var phantucuoi = x[x.Count - 1];
                        if (item.PHONG.MaPhong == cmbMaPhong.SelectedValue.ToString())
                        {
                            if(item.SoPhieuDV == phantucuoi.SoPhieuDV)
                            {
                                CHITIETDICHVU s = new CHITIETDICHVU()
                                {
                                    SoPhieuDV = item.SoPhieuDV,
                                    MaDichVu = cmbDichVu.SelectedValue.ToString(),
                                    SoLuong = Convert.ToInt32(txtSLSD.Text),

                                };
                                context.CHITIETDICHVUs.Add(s);
                                context.SaveChanges();
                            }
                           
                        }
                    }
                   
               }

            }
            catch
            {
                MessageBox.Show("Phòng này chưa sử dụng dịch vụ!");
            }
        }
        private void dgvSuDungDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 context = new Model1();
                List<CHITIETDICHVU> listCTDV = context.CHITIETDICHVUs.ToList();
                CTPhieuTheoPhong(listCTDV);
            }
            catch 
            {
                MessageBox.Show("Phòng này chưa sử dụng dịch vụ!");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            DateTime now = new DateTime();
            List<PHIEUDICHVU> listdv = context.PHIEUDICHVUs.ToList();           
            PHIEUDICHVU phong = context.PHIEUDICHVUs.FirstOrDefault(p => p.MaPhong == cmbMaPhong.SelectedValue.ToString());
          
            List<CHITIETDICHVU> listCTDV = context.CHITIETDICHVUs.Where(p => p.PHIEUDICHVU.MaPhong == cmbMaPhong.SelectedValue.ToString()).ToList();
            CHITIETDICHVU ctdv = context.CHITIETDICHVUs.FirstOrDefault(p => p.MaDichVu == cmbDichVu.SelectedValue.ToString());
            List<PHIEUDICHVU> s = context.PHIEUDICHVUs.Where(p => p.MaPhong == cmbMaPhong.SelectedValue.ToString()).ToList();
            if (txtSLSD.Text == "")
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");           
            else
            {
                if (phong != null)
                {
                    foreach (var item in listCTDV)
                    {
                        var phantucuoi = s[s.Count - 1];
                        if (item.SoPhieuDV == phantucuoi.SoPhieuDV)
                        {
                            if (item.MaDichVu == cmbDichVu.SelectedValue.ToString())
                            {
                                item.SoLuong += Convert.ToInt32(txtSLSD.Text);
                                MessageBox.Show("Thêm thành công!");
                                txtSLSD.Clear();
                                break;
                            }
                            else if (ctdv != null)
                            {
                                InsertPhieuDichVu();
                                MessageBox.Show("Thêm mới thành công!");
                                break;

                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Hãy thêm phiếu dịch vụ cho phòng này!");
                }

            }
                context.SaveChanges();
                load();
            }


        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            DateTime now = new DateTime();
            List<PHIEUDICHVU> listdv = context.PHIEUDICHVUs.ToList();
            PHIEUDICHVU phong = context.PHIEUDICHVUs.FirstOrDefault(p => p.MaPhong == cmbMaPhong.SelectedValue.ToString());
            List<CHITIETDICHVU> listCTDV = context.CHITIETDICHVUs.Where(p => p.PHIEUDICHVU.MaPhong == cmbMaPhong.SelectedValue.ToString()).ToList();
            CHITIETDICHVU ctdv = context.CHITIETDICHVUs.FirstOrDefault(p => p.MaDichVu == cmbDichVu.SelectedValue.ToString());
            if (txtSLSD.Text == "")
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            else
            {
                if (phong != null)
                {
                    foreach (var item in listCTDV)
                    {
                        if (item.MaDichVu == cmbDichVu.SelectedValue.ToString())
                        {
                            item.SoLuong = Convert.ToInt32(txtSLSD.Text);
                            MessageBox.Show("Sửa thành công!");
                            txtSLSD.Clear();


                            break;
                        }

                    }
                }
                else
                {

                    MessageBox.Show("Hãy thêm phiếu dịch vụ!");
                }
                context.SaveChanges();
                load();
            }

        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            DateTime now = new DateTime();
            List<PHIEUDICHVU> listdv = context.PHIEUDICHVUs.ToList();
            PHIEUDICHVU phong = context.PHIEUDICHVUs.FirstOrDefault(p => p.MaPhong == cmbMaPhong.SelectedValue.ToString());
            List<CHITIETDICHVU> listCTDV = context.CHITIETDICHVUs.Where(p => p.PHIEUDICHVU.MaPhong == cmbMaPhong.SelectedValue.ToString()).ToList();
            CHITIETDICHVU ctdv = context.CHITIETDICHVUs.FirstOrDefault(p => p.MaDichVu == cmbDichVu.SelectedValue.ToString());
            if (txtSLSD.Text == "")
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            else
            {
                if (phong != null)
                {
                    foreach (var item in listCTDV)
                    {
                        if (item.MaDichVu == cmbDichVu.SelectedValue.ToString())
                        {
                            item.SoLuong -= Convert.ToInt32(txtSLSD.Text);
                            txtSLSD.Clear();
                            MessageBox.Show("Xóa thành công!");
                            if (item.SoLuong <= 0)
                            {
                                context.CHITIETDICHVUs.Remove(item);

                            }
                            context.SaveChanges();
                            load();

                        }

                    }
                    context.SaveChanges();
                    load();
                }
                else
                {

                    MessageBox.Show("Hãy thêm phiếu dịch vụ!");
                } 
            }
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnADDPHIEUDV_Click(object sender, EventArgs e)
        {
            ThemPhieuDichVu fm = new ThemPhieuDichVu();
            fm.Show();
        }

        private void cmbMaPhong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind.PerformClick();
            }
        }
    }
}
