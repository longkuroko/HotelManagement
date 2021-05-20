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
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
           
           
        }
        //điền hóa đơn
        private void FillHD(List<CHITIETHOADON> listHD)
        {
            Model1 context = new Model1();
            CHITIETTHUEPHONG s = context.CHITIETTHUEPHONGs.FirstOrDefault(p => p.MaPhong == cbmPhong.SelectedValue.ToString());
            //List<CHITIETHOADON> x = context.CHITIETHOADONs.Where(p => p.MaPhong == cbmPhong.SelectedValue.ToString()).ToList();

            DateTime nn =DateTime.Parse(s.NgayNhan.ToString());
            string ngaynhan = nn.ToString("dd/MM/yyyy");
            DateTime nt = DateTime.Parse(s.NgayTra.ToString());
            string ngaytra = nt.ToString("dd/MM/yyyy");
            //Tinh tiền dịch vụ
                
            foreach (var item in listHD)
            {

                if (item.MaPhong == s.MaPhong)
                {
                    lbMaHD.Text = item.MaHD;
                    lbNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    lbSP.Text = item.SoPhieuTP;
                    lbTen.Text = item.THUEPHONG.KHACHHANG.TenKhach;
                    lbNgayNhanPhong.Text = ngaynhan;
                    lbNgayTra.Text = ngaytra;
                    lbTongTienThue.Text = (item.TongTien - item.PHIEUDICHVU.TongTienDV).ToString();
                    lbTongDV.Text = item.PHIEUDICHVU.TongTienDV.ToString();
                    var tong = item.TongTien;
                    lbTongtien.Text = tong.ToString();
                }
                context.SaveChanges();
            }
        }
        //bindgrid
       
        private void BindGrid(List<CHITIETDICHVU> listCTDV)
        {
             Model1 context = new Model1();
             dgvCTDV.Rows.Clear();
             foreach (var item in listCTDV)
             {
             

                int index = dgvCTDV.Rows.Add();
                dgvCTDV.Rows[index].Cells[0].Value = item.DICHVU.MaDichVu;
                dgvCTDV.Rows[index].Cells[1].Value = item.DICHVU.TenDichVu;
                dgvCTDV.Rows[index].Cells[2].Value = item.SoLuong;
                dgvCTDV.Rows[index].Cells[3].Value = (item.SoLuong * item.DICHVU.DonGiaDV);
            }
        }
        private void CTPhieuTheoPhong(List<CHITIETDICHVU> listDV)
        {
            try
            {
                Model1 context = new Model1();
                List<CHITIETDICHVU> dichvu = new List<CHITIETDICHVU>();
                List<PHIEUDICHVU> phieudichvu = context.PHIEUDICHVUs.ToList();
                List<PHIEUDICHVU> s = context.PHIEUDICHVUs.Where(p => p.MaPhong == cbmPhong.Text).ToList();
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
            catch
            {
                dgvCTDV.Visible = false;               
                MessageBox.Show("Không có dịch vụ");
            }

        }
        //tiền dư
        private void TienDu()
        {
            Model1 context = new Model1();
            List<CHITIETHOADON> listHD = context.CHITIETHOADONs.ToList();
            CHITIETHOADON s = context.CHITIETHOADONs.FirstOrDefault(p => p.MaPhong == cbmPhong.SelectedValue.ToString());
            foreach (var item in listHD)
            {
                if (item.MaPhong == s.MaPhong)
                {
                    txtTienDu.Text = (float.Parse(txtTienNhan.Text) - item.TongTien).ToString();
                    item.PHONG.TrangThai = "Empty";
                }
                context.SaveChanges();
                load();
            }
        }
        //điền phong
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
            cbmPhong.DataSource = s;
            cbmPhong.DisplayMember = "MaPhong";
            cbmPhong.ValueMember = "MaPhong";
        }
        //fill phòng đã đặt
        
        private void load()
        {
            Model1 context = new Model1();
            List<CHITIETHOADON> listHD = context.CHITIETHOADONs.ToList();
            List<PHONG> listPhong = context.PHONGs.ToList();
           
            FillPhong(listPhong);
            //FillHD(listHD);
            
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            load();

        
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 context = new Model1();
                List<CHITIETHOADON> listHD = context.CHITIETHOADONs.ToList();
                List<CHITIETHOADON> s = context.CHITIETHOADONs.Where(p => p.MaPhong == cbmPhong.SelectedValue.ToString()).ToList();
                List<CHITIETDICHVU> listCTDV = context.CHITIETDICHVUs.ToList();

                foreach (var item in listHD)
                {
                    var phantucuoi = s[s.Count - 1];
                    if (item.SoPhieuTP == phantucuoi.SoPhieuTP)
                    {
                        FillHD(listHD);
                        if(item.SoPhieuDV == phantucuoi.SoPhieuDV)
                        {
                            if (item.SoPhieuDV == "KSD")
                            {
                                dgvCTDV.Visible = false;
                                MessageBox.Show("Không có dịch vụ !");
                            }
                            else
                            {
                                dgvCTDV.Visible = true;
                                CTPhieuTheoPhong(listCTDV);
                            }
                                       
                        }
                        
                   
                    }               
                }

            }
            catch
            {
                //MessageBox.Show("Phòng này không có dịch vụ!");
            }


        }       
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<CHITIETHOADON> listHD = context.CHITIETHOADONs.ToList();
            if (txtTienNhan.Text == "")
                MessageBox.Show("Vui lòng nhập số tiền thực nhận");
            else
            {
                DialogResult h = MessageBox.Show("Bạn có đồng ý thanh toán không?", "Message", MessageBoxButtons.YesNo);
                if (h == DialogResult.Yes)
                {
                    TienDu(); context.SaveChanges(); load();
                    MessageBox.Show("Thanh toán thành công!");
                }
            }            
        }

        private void txtTienDu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTienNhan_TextChanged(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<CHITIETHOADON> listHD = context.CHITIETHOADONs.ToList();
            CHITIETHOADON s = context.CHITIETHOADONs.FirstOrDefault(p => p.MaPhong == cbmPhong.SelectedValue.ToString());
            if (txtTienNhan.Text == "")
                txtTienDu.Text = "";
            else
            {
                foreach (var item in listHD)
                {
                    if (item.MaPhong == s.MaPhong)
                    {
                        txtTienDu.Text = (float.Parse(txtTienNhan.Text) - float.Parse(lbTongtien.Text.ToString())).ToString();

                    }
                }
            }
            
        }
    }
}
