using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaNghi.Model;
namespace QuanLyNhaNghi
{
    public partial class ThanhToan_TraPhong : Form
    {
        public ThanhToan_TraPhong()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {          
                HoaDon fm = new HoaDon();
                fm.Show();                  
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home fm = new Home();
            fm.Show();
        }
        //điền phiếu dịch vụ vào hóa đơn theo số thuê phòng
        private void Fill()
        {
            try
            {
                Model1 context = new Model1();
                List<PHIEUDICHVU> phieutp = context.PHIEUDICHVUs.ToList();
                List<CHITIETTHUEPHONG> cttp = context.CHITIETTHUEPHONGs.ToList();
                List<CHITIETHOADON> hoadon = context.CHITIETHOADONs.ToList();              
                foreach (var item in hoadon)
                {
                    PHIEUDICHVU s = context.PHIEUDICHVUs.FirstOrDefault(p => p.SoPhieuTP == item.SoPhieuTP);
                    if (s != null)
                    {
                        item.SoPhieuDV = s.SoPhieuDV;
                    }
                    else
                    {
                        item.SoPhieuDV = "";
                    }
                    //foreach (var item1 in phieutp)
                    //{

                    //    if (item.SoPhieuTP == item1.SoPhieuTP)
                    //    {
                    //        item.SoPhieuDV = item1.SoPhieuDV;
                    //    }
                    //    else
                    //    {
                    //        item.SoPhieuDV = "";
                    //    }
                    context.SaveChanges();
                    //}

                }
              

            }
            catch
            {
               
            }
        }
        //bindgrid
        private void Bindgrid(List<CHITIETHOADON> hoadon)
        {
            try
            {
                Model1 context = new Model1();
                List<PHIEUDICHVU> phieutp = context.PHIEUDICHVUs.ToList();
                List<CHITIETTHUEPHONG> cttp = context.CHITIETTHUEPHONGs.ToList();
                List<CHITIETHOADON> s = new List<CHITIETHOADON>();
                dgvTT.Rows.Clear();
                foreach (var item in hoadon)
                {
                    int index = dgvTT.Rows.Add();
                    dgvTT.Rows[index].Cells[0].Value = item.MaHD;
                    dgvTT.Rows[index].Cells[1].Value = item.SoPhieuTP;
                    //dgvTT.Rows[index].Cells[2].Value = item.SoPhieuDV;
                    dgvTT.Rows[index].Cells[3].Value = item.NgayThanhToan;
                    //dgvTT.Rows[index].Cells[4].Value = item.TongTien;
                    //dgvTT.Rows[index].Cells[5].Value = item.PHIEUDICHVU.TongTienDV;
                    dgvTT.Rows[index].Cells[6].Value = item.TongTien;
                   foreach (var item1 in phieutp)
                   {
                        if(item.SoPhieuTP == item1.SoPhieuTP)
                        {
                            dgvTT.Rows[index].Cells[2].Value = item1.SoPhieuDV;
                            dgvTT.Rows[index].Cells[5].Value = item.PHIEUDICHVU.TongTienDV;
                        }
                    }
                   foreach(var item2 in cttp)
                    {
                        if(item.SoPhieuTP == item2.SoPhieuTP)
                        {
                            dgvTT.Rows[index].Cells[4].Value = item2.TienThuePhong;
                        }
                    }
        
                }
                           
            }
            catch(Exception EX)
            {
                MessageBox.Show(EX.Message);
            }                            
         }
        
        private void FillHOADON(List<PHIEUDICHVU> lishd)
        {
            Model1 context = new Model1();
            List<PHIEUDICHVU> phieudichvu = context.PHIEUDICHVUs.ToList();
            List<CHITIETHOADON> phieudv = context.CHITIETHOADONs.ToList();
            foreach (var item in lishd)
            {
                foreach (var item1 in phieudv)
                {
                   if(item.SoPhieuTP == item1.SoPhieuTP)
                   {
                        if(item1.PHONG.MaPhong == item.MaPhong)
                            item1.SoPhieuDV = item.SoPhieuDV;
                      
                   }
                   
                }             
            }
      
            context.SaveChanges();
        }
        //tổng tiền = (tiền phòng * số ngày ở) + sử dụng dịch vụ
        private void TongtienThuePhong(List<CHITIETHOADON> listThuePhong)
        {

            Model1 context = new Model1();
            List<CHITIETTHUEPHONG> listCTTP = context.CHITIETTHUEPHONGs.ToList();                  
            foreach (var item in listThuePhong)
            {
                foreach (var item1 in listCTTP)
                {
                    TimeSpan time = item1.NgayTra.Value - item1.NgayNhan.Value;
                    int Sodem = time.Days;
                    item1.TienThuePhong  = Sodem * item1.PHONG.GiaTien;

                  
                }

            }  
            
            context.SaveChanges();           
        }
        private void tongtienhoadon()
        {
            Model1 context = new Model1();
            List<CHITIETHOADON> listHD = context.CHITIETHOADONs.ToList();
            List<CHITIETTHUEPHONG> listCTTP = context.CHITIETTHUEPHONGs.ToList();
            List<PHIEUDICHVU> listdv = context.PHIEUDICHVUs.ToList();
            foreach (var item in listHD)
            {
                foreach (var item1 in listCTTP)
                {
                    if(item.SoPhieuTP == item1.SoPhieuTP)
                    {
                        foreach(var item2 in listdv)
                        {
                            if(item1.SoPhieuTP == item2.SoPhieuTP)
                            {
                                item.TongTien = item.PHIEUDICHVU.TongTienDV + item1.TienThuePhong;
                            }
                        }
                       
                    }
                }
               context.SaveChanges();
        }
             
        }

        //tông tiền hóa đơn
        private void TongTienHoaDon()
        {
            Model1 context = new Model1();
            List < CHITIETHOADON > listHD = context.CHITIETHOADONs.ToList();
            List<CHITIETTHUEPHONG> listhuephong = context.CHITIETTHUEPHONGs.ToList();
            foreach( var item in listHD)
            {
                item.TongTien = 0;
                foreach(var item1 in listhuephong)
                {
                    if(item1.SoPhieuTP == item.SoPhieuTP)
                    {
                        item.TongTien = item1.TienThuePhong+item.PHIEUDICHVU.TongTienDV;
                    }
                }
               
            }
            context.SaveChanges();
        }
        private void tiendichvu()
        {
            Model1 context = new Model1();
            List<PHIEUDICHVU> phieudv = context.PHIEUDICHVUs.ToList();
            List<CHITIETDICHVU> listDV = context.CHITIETDICHVUs.ToList();
            List<CHITIETDICHVU> listctdv = new List<CHITIETDICHVU>();
            List<CHITIETDICHVU> phieudichvu = new List<CHITIETDICHVU>();
            foreach (var item in phieudv)
            {
                List<CHITIETDICHVU> s = context.CHITIETDICHVUs.Where(p => p.SoPhieuDV == item.SoPhieuDV).ToList();
                item.TongTienDV = 0;
                foreach (var item1 in s)
                {
                    var tong = item1.SoLuong * item1.DICHVU.DonGiaDV;
                    item.TongTienDV += float.Parse(tong.ToString());
                
                }
                context.SaveChanges();



            }
        }
            //draw datagridview
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
        //load data
        private void load()
        {
            Model1 context = new Model1();
            
            List<CHITIETHOADON> listHD = context.CHITIETHOADONs.ToList();
            List<CHITIETTHUEPHONG> listThuePhong = context.CHITIETTHUEPHONGs.ToList();
            List<CHITIETDICHVU> listDichvu = context.CHITIETDICHVUs.ToList();
            List<PHIEUDICHVU> listDichvu1 = context.PHIEUDICHVUs.ToList();
            SetGridViewStyle(dgvTT);
            FillHOADON(listDichvu1);
            Fill();
            tongtienhoadon();
            Bindgrid(listHD);         
            TongTienHoaDon();
            TongtienThuePhong(listHD);
            FillPhieuThuePhong(listThuePhong);
            tiendichvu();
            txtMaHD.Text = "HD" + "-" + cmbPhieuThue.Text;


        }            
        private void ThanhToan_TraPhong_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtPhong.Text == "")
                load();
            else
            {
                try
                {
                    Model1 context = new Model1();
                    List<CHITIETHOADON> listhd = context.CHITIETHOADONs.ToList();
                    CHITIETHOADON s = context.CHITIETHOADONs.FirstOrDefault(p => p.MaPhong == txtPhong.Text);
                    List<CHITIETHOADON> hoadon = context.CHITIETHOADONs.Where(p => p.MaPhong == txtPhong.Text).ToList();
                    List<CHITIETHOADON> listHD = new List<CHITIETHOADON>();
                    foreach(var item in listhd)
                    {
                        var hoadoncuoi = hoadon[hoadon.Count - 1];
                        if (item.SoPhieuTP == hoadoncuoi.SoPhieuTP)
                        {
                            listHD.Add(item);

                        }
                        //foreach(var item1 in hoadon)
                        //{
                        //    if (item.SoPhieuTP == item1.SoPhieuTP)
                        //    {
                        //        listHD.Add(item);

                        //    }
                        //}

                    }
                    Bindgrid(listHD);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //thêm hóa đơn
        private void InsertHD()
        {
            using (var context = new Model1())
            {
                CHITIETHOADON s = new CHITIETHOADON()
                {
                    MaHD = "HD"+"-" + cmbPhieuThue.Text,//txtMaHD.Text,
                    SoPhieuTP = cmbPhieuThue.Text,
                    SoPhieuDV = txtSoPhieuDV.Text,
                    MaPhong = cmbMaPhong.Text,
                    NgayThanhToan = DateTime.Now,
                    TongTien = 0
                };
                context.CHITIETHOADONs.Add(s);
                context.SaveChanges();
            }
        }
        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 context = new Model1();
                List < CHITIETHOADON > listhd= context.CHITIETHOADONs.ToList();
                CHITIETHOADON s = context.CHITIETHOADONs.FirstOrDefault(p => p.MaHD == txtMaHD.Text);
                if (txtMaHD.Text == "" || cmbPhieuThue.Text == "")
                    MessageBox.Show("Tạo hóa đơn thất bại!");
                else
                {
                    if (s == null)
                    {
                        InsertHD();
                        MessageBox.Show("Thêm hóa đơn thành công!");
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Mã hóa đơn đã tồn tại!");
                    }
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimKiem_KeyDown(object sender, KeyEventArgs e)
        {           
        }

        private void txtPhong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem.PerformClick();
            }
        }

        private void dgvTT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtPhong_TextChanged(object sender, EventArgs e)
        {
            if (txtPhong.Text == "")
                load();
        }
        private void FillPhieuThuePhong(List<CHITIETTHUEPHONG> listThuePhong)
        {
            Model1 context = new Model1();
            List<CHITIETTHUEPHONG> thuephong = new List<CHITIETTHUEPHONG>();
            List<PHIEUDICHVU> phieudv = context.PHIEUDICHVUs.ToList();
            foreach (var item in listThuePhong)
            {
                CHITIETHOADON phieudichvu = context.CHITIETHOADONs.FirstOrDefault(p => p.SoPhieuTP == item.SoPhieuTP);
                if (phieudichvu == null)
                {
                    thuephong.Add(item);

                }
            }
            cmbMaPhong.DataSource = thuephong;
            cmbMaPhong.DisplayMember = "MaPhong";
            cmbMaPhong.ValueMember = "MaPhong";

            cmbPhieuThue.DataSource = thuephong;
            cmbPhieuThue.DisplayMember = "SoPhieuTP";
            cmbPhieuThue.DisplayMember = "SoPhieuTP";
            foreach (var item in thuephong)
            {
                foreach (var item1 in phieudv)
                {
                    if (item1.SoPhieuTP == item.SoPhieuTP)
                    {
                        txtSoPhieuDV.Text = item1.SoPhieuDV;
                    }
                    else
                    {
                        txtSoPhieuDV.Text ="KSD";
                    }
                }

            }

        }

        private void cmbPhieuThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaHD.Text = "HD" + "-" + cmbPhieuThue.Text;

        }
    }
}
