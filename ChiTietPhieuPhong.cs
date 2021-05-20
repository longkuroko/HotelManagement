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
    public partial class ChiTietPhieuDatPhong : Form
    {
        public ChiTietPhieuDatPhong()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home fm = new Home();
            fm.Show();
        }

        //Set Phòng còn trống cho ComboBox
        private void PhongTrongCMB(List<PHONG> listPhong)
        {

            List<PHONG> s = new List<PHONG>();
            foreach (var item in listPhong)
            {

                if (item.TrangThai == "Empty")
                {
                    s.Add(item);

                }

            }
            cmbMaPhong.DataSource = s;
            cmbMaPhong.DisplayMember = "MaPhong";
            cmbMaPhong.ValueMember = "MaPhong";
        }
        //set commboBox loai khách hàng
        private void FillCMBLoaiKH(List<LOAIKHACHHANG> listLKH)
        {
            cmbLoaiKH.DataSource = listLKH;
            cmbLoaiKH.DisplayMember = "TenLoaiKH";
            cmbLoaiKH.ValueMember = "MaLoaiKH";
        }
        //load details phiếu phòng theo mã phòng
        private void LoadDetail(List<PHONG> listPhong)
        {
            Model1 context = new Model1();
            foreach (var item in listPhong)
            {
                if (item.MaPhong == cmbMaPhong.SelectedValue.ToString())
                {
                    txtMaDatPhong.Text = txtMaDatPhong.Text;
                    txtLoaiPhong.Text = item.LOAIPHONG.TenLoaiPhong;
                    txtGiaPhong.Text = item.GiaTien.ToString();
                }
                context.SaveChanges();
            }
        }
        //thêm phiếu thuê phòng
        private void InsertPhieuThue()
        {
            using (var context = new Model1())
            {

                THUEPHONG s = new THUEPHONG()
                {
                    SoPhieuTP = txtMaDatPhong.Text,                 
                    MaKhach = txtMaKhach.Text,  
                    NgayDat = DateTime.Now
                };
                context.THUEPHONGs.Add(s);
                context.SaveChanges();
            }
        }
        //thêm phiếu chitietphieuPHONG
        private void InsertCTPTP()
        {
          using (var context = new Model1())
            {
                CHITIETTHUEPHONG s = new CHITIETTHUEPHONG()
                {
                    SoPhieuTP = txtMaDatPhong.Text,
                    MaPhong = cmbMaPhong.SelectedValue.ToString(),
                    NgayNhan = dtpNgayden.Value,
                    NgayTra = dtpNgaydi.Value,
                };
                context.CHITIETTHUEPHONGs.Add(s);
                context.SaveChanges();
            }
        }
        //them khach hangg
        private void InsertKhachHang()
        {
            using (var context = new Model1())
            {
                KHACHHANG s = new KHACHHANG()
                {
                    MaKhach = txtMaKhach.Text,
                    TenKhach = txtTenKH.Text,
                    SoCMND = txtCMND.Text,
                    DienThoai = txtSĐT.Text,
                    DiaChi = txtDiaChi.Text,
                    MaLoaiKH = cmbLoaiKH.SelectedValue.ToString(),

                };
                context.KHACHHANGs.Add(s);
                context.SaveChanges();
            }
        }
       
        //bindgird
        private void Bindgrid(List<CHITIETTHUEPHONG> listhuephong)
        {
            dgvCTPT.Rows.Clear();
            foreach(var item in listhuephong)
            {
                int index = dgvCTPT.Rows.Add();
                dgvCTPT.Rows[index].Cells[0].Value = item.SoPhieuTP;
                dgvCTPT.Rows[index].Cells[1].Value = item.PHONG.MaPhong;
                dgvCTPT.Rows[index].Cells[2].Value = item.NgayNhan;
                dgvCTPT.Rows[index].Cells[3].Value = item.NgayTra;
                dgvCTPT.Rows[index].Cells[4].Value = item.THUEPHONG.KHACHHANG.TenKhach;
                dgvCTPT.Rows[index].Cells[5].Value = item.THUEPHONG.KHACHHANG.DienThoai;


            }
        }
        //clear txtbox 
        private void ClearTextBx()
        {
            txtMaDatPhong.Clear();
            txtSoDem.Clear();
            txtMaKhach.Clear();
            txtTenKH.Clear();
            txtCMND.Clear();
            txtDiaChi.Clear();
            txtSĐT.Clear();
        }
        private void SetTrangThai()
        {

            Model1 context = new Model1();
            List<CHITIETTHUEPHONG> listhuephong = context.CHITIETTHUEPHONGs.ToList();
            foreach (var item in listhuephong)
            {
                List<CHITIETTHUEPHONG> s = context.CHITIETTHUEPHONGs.Where(p => p.PHONG.MaPhong == item.MaPhong).ToList();
                foreach(var item1 in s)
                {
                    item1.PHONG.TrangThai = "Confirmed";
                }
                context.SaveChanges();
                
            }
            context.SaveChanges();
        }
     
               
        private void load()
        {
            Model1 context = new Model1();
            List<PHONG> listPhong = context.PHONGs.ToList();
            List<LOAIKHACHHANG> listLKH = context.LOAIKHACHHANGs.ToList();
            List<THUEPHONG> listhuephong = context.THUEPHONGs.ToList();
            List<CHITIETTHUEPHONG> cttp = context.CHITIETTHUEPHONGs.ToList();
            Bindgrid(cttp);
           
            PhongTrongCMB(listPhong);
            LoadDetail(listPhong);
            FillCMBLoaiKH(listLKH);
            //TongTien(listhuephong);
        }
        private void dtpNgaydi_ValueChanged(object sender, EventArgs e)
        {
            if(dtpNgaydi.Value < dtpNgayden.Value)
            {
                MessageBox.Show("Ngày đi không được nhỏ hơn ngày đến!");
            }
            else
            {
                TimeSpan time = dtpNgaydi.Value - dtpNgayden.Value;
                int Sodem = time.Days;
                txtSoDem.Text = Sodem.ToString();
            }
        }

        private void txtQuocTich_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 context = new Model1();
                THUEPHONG phieuthue = context.THUEPHONGs.FirstOrDefault(p => p.SoPhieuTP == txtMaDatPhong.Text);
                CHITIETTHUEPHONG phieuthue1 = context.CHITIETTHUEPHONGs.FirstOrDefault(p => p.PHONG.MaPhong == cmbMaPhong.SelectedValue.ToString());
                KHACHHANG khachhang = context.KHACHHANGs.FirstOrDefault(p => p.MaKhach == txtMaKhach.Text);              
                List<CHITIETTHUEPHONG> phong = context.CHITIETTHUEPHONGs.ToList();
                if(khachhang != null)
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại!");
                   
                }
                else
                {
                    InsertKhachHang();
                    context.SaveChanges(); load();
                    MessageBox.Show("Thêm khách hàng thành công!");
                }
               
                if (dtpNgayden.Value >= DateTime.Now)
                {
                    TimeSpan time = dtpNgaydi.Value - dtpNgayden.Value;
                    int Sodem = time.Days;
                    if (Sodem >= 0)
                    {
                        if (phieuthue != null)
                        {
                            MessageBox.Show("Phiếu đặt phòng đã tồn tại");

                        }
                        else
                        {
                            InsertPhieuThue();
                            InsertCTPTP();                                                    
                            txtSoDem.Text = Sodem.ToString();                         
                            context.SaveChanges();
                            SetTrangThai();
                            MessageBox.Show("Thêm thành công!");
                            ClearTextBx();
                            load();                       
                        }
                                                                    
                    }                  
                    else
                    {
                        MessageBox.Show("Ngày rời đi không được nhỏ hơn ngày đến!");
                    }
                }
                else
                {
                    MessageBox.Show("Ngày đến không được nhỏ hơn ngày hiện hành!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //tự động tạo phiếu phòng
        

        private void ChiTietPhieuDatPhong_Load(object sender, EventArgs e)
        {
            load();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void txtSoDem_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<PHONG> listPhong = context.PHONGs.ToList();
            LoadDetail(listPhong);
        }

        private void btnXóa_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 context = new Model1();
                THUEPHONG phieuthue = context.THUEPHONGs.FirstOrDefault(p => p.SoPhieuTP == txtMaDatPhong.Text);
                CHITIETTHUEPHONG phieuthue1 = context.CHITIETTHUEPHONGs.FirstOrDefault(p => p.SoPhieuTP == txtMaDatPhong.Text);
                if (phieuthue != null)
                {
                
                    context.THUEPHONGs.Remove(phieuthue);
                    context.CHITIETTHUEPHONGs.Remove(phieuthue1);
                    phieuthue1.PHONG.TrangThai = "Empty";
                    context.SaveChanges();
                    load();
                }
            }
            catch
            {

            }
        }

        private void dgvCTPT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpNgayden_ValueChanged(object sender, EventArgs e)
        {
            if(dtpNgayden.Value < DateTime.Now)
            {
                MessageBox.Show("Ngày đến không được bé hơn ngày hiện hành!");
            }
        }

        private void cmbMaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<PHONG> phong = context.PHONGs.ToList();
            foreach(var item in phong)
            {
                if(item.MaPhong == cmbMaPhong.Text)
                {
                    txtLoaiPhong.Text = item.LOAIPHONG.TenLoaiPhong;
                    txtGiaPhong.Text = item.GiaTien.ToString();
                }
            }
        }
    }
}
