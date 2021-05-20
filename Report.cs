using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLyNhaNghi.Model;
using QuanLyNhaNghi.phieureport;
namespace QuanLyNhaNghi
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }   
        //phieu dich vu
        private void PhieuDichVu()
        {
            try
            {
                Model1 context = new Model1();
                List<PHIEUDICHVU> listThuePhong = context.PHIEUDICHVUs.ToList();
                List<PhieuDichVuReport> listRP = new List<PhieuDichVuReport>();
                foreach (PHIEUDICHVU i in listThuePhong)
                {

                    PhieuDichVuReport temp = new PhieuDichVuReport();
                    temp.SoPhieuDV = i.SoPhieuDV;
                    temp.SoPhieuTP = i.SoPhieuTP;
                    temp.MaPhong = i.MaPhong;
                    temp.NgayThucHien = i.NgayThucHienDV;
                    var x = i.TongTienDV.ToString();
                    temp.TongTienDV = float.Parse(x);
                    listRP.Add(temp);

                }
                this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                this.reportViewer1.LocalReport.ReportPath = "PhieuDichVuRP.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource(name: "DataDichVu", dataSourceValue: listRP));
                
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //chi tiet phieu dich vu
        private void ChiTietPhieuDichVu()
        {


            try
            {

                Model1 context = new Model1();
                List<CHITIETDICHVU> listCTDV = context.CHITIETDICHVUs.ToList();
                List<CTDV> listRP = new List<CTDV>();
                CHITIETDICHVU S = context.CHITIETDICHVUs.FirstOrDefault(p => p.SoPhieuDV == cmbPhieuDV.Text);
                List<CHITIETDICHVU> listDV = context.CHITIETDICHVUs.Where(p => p.SoPhieuDV == cmbPhieuDV.Text).ToList();
               
                foreach (CHITIETDICHVU item in listDV)
                {
                    CTDV temp = new CTDV();
                    temp.SoPhieuDV = item.SoPhieuDV;
                    temp.MaDV = item.MaDichVu;
                    temp.TenDV = item.DICHVU.TenDichVu;
                    temp.SoLuong = Convert.ToInt32(item.SoLuong);
                    var x = item.DICHVU.DonGiaDV.ToString();
                    temp.DonGia = float.Parse(x);
                    listRP.Add(temp);
                }
                this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                ReportParameter[] param = new ReportParameter[1];
                param[0] = new ReportParameter("SoPhieuDV",S.SoPhieuDV);
                this.reportViewer1.LocalReport.ReportPath = "CTDV.rdlc";
                this.reportViewer1.LocalReport.SetParameters(param);
                var reportDataSource = new ReportDataSource("DataCTDV", listRP);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }
            catch 
            {
                if (cmbPhieuDV.Text == "KSD")
                    MessageBox.Show("không sử dụng dịch vụ!");
            }
        }
        //Danh sách hóa đơn
        private void HoaDon()
        {
            try
            {
                Model1 context = new Model1();
                List<CHITIETHOADON> listhd = context.CHITIETHOADONs.ToList();
                List<hd> listRP = new List<hd>();
                foreach (CHITIETHOADON i in listhd)
                {
                    hd temp = new hd();
                    temp.MaHD = i.MaHD;
                    temp.SoPhieuDV = i.SoPhieuDV;
                    temp.SoPhieuTP = i.SoPhieuTP;
                    temp.MaPhong = i.MaPhong;
                    temp.NgayThanhToan = i.NgayThanhToan;
                    temp.TongTien = float.Parse(i.TongTien.ToString());
                    listRP.Add(temp);
                }
                this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                this.reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource(name: "DataSet1", dataSourceValue: listRP));

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //chitiethoadon
        private void ChiTietHoaDon()
        {


            try
            {

                Model1 context = new Model1();
                List<CHITIETHOADON> listCTHD = context.CHITIETHOADONs.ToList();
                List<PHIEUDICHVU> listdv = context.PHIEUDICHVUs.ToList();
                List<CHITIETTHUEPHONG> listtp = context.CHITIETTHUEPHONGs.ToList();
                List<ChiTietHD> listRP = new List<ChiTietHD>();
                List<CTDV> listR1 = new List<CTDV>();
                CHITIETHOADON S = context.CHITIETHOADONs.FirstOrDefault(p => p.MaHD == cmbCTHD.Text);
                List<CHITIETHOADON> listDV1 = context.CHITIETHOADONs.Where(p => p.MaHD == cmbCTHD.Text).ToList();
                foreach (CHITIETHOADON item in listDV1)
                {
                    if (S != null)
                    {
                        CHITIETTHUEPHONG s = context.CHITIETTHUEPHONGs.FirstOrDefault(p => p.SoPhieuTP == item.SoPhieuTP);
                        if (s != null)
                        {
                            ChiTietHD temp = new ChiTietHD();
                            temp.MaHD = item.MaHD;
                            temp.SoPhieuTP = item.SoPhieuTP;
                            temp.MaPhong = item.MaPhong;
                            temp.NgayThanhToan = item.NgayThanhToan;
                            temp.TongTienThuePhong = float.Parse(s.TienThuePhong.ToString());
                            temp.TongTien = float.Parse(item.TongTien.ToString());                        
                            listRP.Add(temp);
                            PHIEUDICHVU x = context.PHIEUDICHVUs.FirstOrDefault(p => p.SoPhieuTP == S.SoPhieuTP);                                              
                        }
                       
                    }
                }
                foreach (var item1 in listdv)
                {
                    if (item1.SoPhieuTP == S.SoPhieuTP)
                    {
                        List<CHITIETDICHVU> listDV = context.CHITIETDICHVUs.Where(p => p.SoPhieuDV == item1.SoPhieuDV).ToList();
                        foreach (CHITIETDICHVU item2 in listDV)
                        {
                            CTDV temp1 = new CTDV();
                            temp1.SoPhieuDV = item2.SoPhieuDV;
                            temp1.MaDV = item2.MaDichVu;
                            temp1.TenDV = item2.DICHVU.TenDichVu;
                            temp1.SoLuong = Convert.ToInt32(item2.SoLuong);
                            var z = item2.DICHVU.DonGiaDV.ToString();
                            temp1.DonGia = float.Parse(z);
                            listR1.Add(temp1);
                        }
                    }
                }

                this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                ReportParameter[] param = new ReportParameter[4];
                param[0] = new ReportParameter("MaHD",S.MaHD);
                DateTime ngaytt =S.NgayThanhToan.Value;
                string xx = ngaytt.ToString("dd/MM/yyyy");
                param[1] = new ReportParameter("NgayThanhToan", xx);
                param[2] = new ReportParameter("MaPhong", S.MaPhong);
                param[3] = new ReportParameter("SoPhieuTP", S.SoPhieuTP);
                //param[3] = new ReportParameter("TienThuePhong",);
                this.reportViewer1.LocalReport.ReportPath = "CTHD.rdlc";
                this.reportViewer1.LocalReport.SetParameters(param);
                var reportDataSource = new ReportDataSource("DataSet1", listRP);
                var reportDataSource1 = new ReportDataSource("DataCTDV", listR1);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //HoaDonTheoThang
        private void HoaDonThang()
        {
            try
            {
                Model1 context = new Model1();
                List<CHITIETHOADON> listhd = context.CHITIETHOADONs.ToList();
                List<hd> listRP = new List<hd>();
                CHITIETHOADON hd = context.CHITIETHOADONs.FirstOrDefault(p => p.NgayThanhToan.Value.Month.ToString() == dateTimePickerHDthang.Value.Month.ToString());
                List<CHITIETHOADON> s = context.CHITIETHOADONs.Where(p => p.NgayThanhToan.Value.Month.ToString() == dateTimePickerHDthang.Value.Month.ToString()).ToList();
                if (hd != null)
                {
                    foreach (CHITIETHOADON i in s)
                    {
                        hd temp = new hd();
                        temp.MaHD = i.MaHD;
                        temp.SoPhieuDV = i.SoPhieuDV;
                        temp.SoPhieuTP = i.SoPhieuTP;
                        temp.MaPhong = i.MaPhong;
                        temp.NgayThanhToan = i.NgayThanhToan;
                        temp.TongTien = float.Parse(i.TongTien.ToString());
                        listRP.Add(temp);
                    }
                }
                else
                {
                    MessageBox.Show("Không có hóa đơn trong Tháng"+" "+ dateTimePickerHDthang.Value.ToString("MM/yyyy"));
                }
                this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                ReportParameter[] param = new ReportParameter[1];
                string date = DateTime.Parse(hd.NgayThanhToan.ToString()).ToString("MM/yyyy");
                param[0] = new ReportParameter("Month",date);
                this.reportViewer1.LocalReport.ReportPath = "CTHDThang.rdlc";
                this.reportViewer1.LocalReport.SetParameters(param);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource(name: "DataSet1", dataSourceValue: listRP));

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void HoaDonNgay()
        {
            try
            {
                Model1 context = new Model1();
                List<CHITIETHOADON> listhd = context.CHITIETHOADONs.ToList();
                List<hd> listRP = new List<hd>();
                CHITIETHOADON hd = context.CHITIETHOADONs.FirstOrDefault(p => p.NgayThanhToan.Value >= dateTimePickerHD1.Value && p.NgayThanhToan <= dateTimePickerHD2.Value);
                List<CHITIETHOADON> s = context.CHITIETHOADONs.Where(p => p.NgayThanhToan.Value >= dateTimePickerHD1.Value && p.NgayThanhToan <= dateTimePickerHD2.Value).ToList();
                if(hd != null)
                {
                    
                    foreach (CHITIETHOADON i in s)
                    {
                        hd temp = new hd();
                        temp.MaHD = i.MaHD;
                        temp.SoPhieuDV = i.SoPhieuDV;
                        temp.SoPhieuTP = i.SoPhieuTP;
                        temp.MaPhong = i.MaPhong;
                        temp.NgayThanhToan = i.NgayThanhToan;
                        temp.TongTien = float.Parse(i.TongTien.ToString());
                        listRP.Add(temp);
                    }
                }
                else
                {
                    MessageBox.Show("Không có hóa đơn trong thời gian này!");
                }
                this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                ReportParameter[] param = new ReportParameter[2];
                string date1 = dateTimePickerHD1.Value.ToString("dd/MM/yyyy");
                string date2 = dateTimePickerHD2.Value.ToString("dd/MM/yyyy");

                param[0] = new ReportParameter("Date1", date1);
                param[1] = new ReportParameter("Date2", date2);

                this.reportViewer1.LocalReport.ReportPath = "CTHDDay.rdlc";
                this.reportViewer1.LocalReport.SetParameters(param);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource(name: "DataSet1", dataSourceValue: listRP));

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillPhieuDichVu(List<PHIEUDICHVU> lisdv)
        {
            cmbPhieuDV.DataSource = lisdv;
            cmbPhieuDV.DisplayMember = "SoPhieuDV";
            cmbPhieuDV.ValueMember = "SoPhieuDV";
        }
        private void FillHD(List<CHITIETHOADON> listhd)
        {
            cmbCTHD.DataSource = listhd;
            cmbCTHD.DisplayMember = "MaHD";
            cmbCTHD.ValueMember = "MaHD";
        }
        private void load()
        {
            Model1 context = new Model1();
            List<PHIEUDICHVU> listdv = context.PHIEUDICHVUs.ToList();
            List<CHITIETHOADON> listhd = context.CHITIETHOADONs.ToList();
            FillHD(listhd);
            FillPhieuDichVu(listdv);
            // this.reportViewer1.Visible = fals;
            ////PhieuThuePhong();
            PhieuDichVu();
            ChiTietPhieuDichVu();

            HoaDon();

        }
        private void Report_Load(object sender, EventArgs e)
        {
            load();
           
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (radioButton1.Checked == true)
            {
                this.reportViewer1.Visible = true;
                PhieuDichVu();
            }
            if (radioButton2.Checked == true)
            {
                this.reportViewer1.Visible = true;
                ChiTietPhieuDichVu();
            }
            if (radioHoaDon.Checked == true)
            {
                this.reportViewer1.Visible = true;
                HoaDon();
            }
            if(radioHDThang.Checked == true)
            {
                this.reportViewer1.Visible = true;
                HoaDonThang();
            }
            if(radioHDNgay.Checked == true)
            {
                this.reportViewer1.Visible = true;
                HoaDonNgay();
            }
            if(radioCTHD.Checked == true)
            {
                this.reportViewer1.Visible = true;
                ChiTietHoaDon();           
            }
        }

        private void radioThuePhong_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioPhieuDichVu_CheckedChanged(object sender, EventArgs e)
        {

            if (radioPhieuDichVu.Checked == true)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;

            }
            if (radioPhieuDichVu.Checked == false)
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
            if (radioButton2.Checked == true)
            {
                cmbPhieuDV.Enabled = true;
            }
        }

        private void radioHoaDon_CheckedChanged(object sender, EventArgs e)
        {
            if (radioHoaDon.Checked == true)
            {
                radioHDThang.Enabled = true;
                radioHDNgay.Enabled = true;
                radioCTHD.Enabled = true;
            }
            if (radioHoaDon.Checked == false)
            {
                radioHDThang.Enabled = false;
                radioHDNgay.Enabled = false;
                radioCTHD.Enabled = false;
            }
            if (radioHoaDon.Checked == true)
            {
                dateTimePickerHDthang.Enabled = true;

            }
            if (radioHoaDon.Checked == true)
            {
                dateTimePickerHD1.Enabled = true;
                dateTimePickerHD2.Enabled = true;
            }
            if(radioCTHD.Checked == true)
            {
                cmbCTHD.Enabled = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
