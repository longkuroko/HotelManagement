using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaNghi.Model;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyNhaNghi
{
    public partial class QuanLyKhachHang : Form
    {
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Home fm = new Home();
            //fm.Show();
        }
        //bindgird
        private void BindGrid(List<KHACHHANG> listKhachHang)
        {
            try
            {
                Model1 context = new Model1();
                dgvKhachHang.Rows.Clear();
                foreach(var item in listKhachHang)
                {
                    int index = dgvKhachHang.Rows.Add();
                    dgvKhachHang.Rows[index].Cells[0].Value = item.MaKhach;
                    dgvKhachHang.Rows[index].Cells[1].Value = item.TenKhach;
                    dgvKhachHang.Rows[index].Cells[2].Value = item.SoCMND;
                    dgvKhachHang.Rows[index].Cells[3].Value = item.DienThoai.ToString();
                    dgvKhachHang.Rows[index].Cells[4].Value = item.DiaChi;
                    dgvKhachHang.Rows[index].Cells[5].Value = item.MaLoaiKH;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //load
        private void load()
        {
            Model1 context = new Model1();
            List<KHACHHANG> listKhachHang = context.KHACHHANGs.ToList();//lấy danh sách khách hàng
            BindGrid(listKhachHang);
        }
        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            
                load();
            SetGridViewStyle(dgvKhachHang);
        }
        //lọc khách hàng theo ngày
        
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
        //xuất excel

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
                load();
            else {

                Model1 context = new Model1();
                KHACHHANG s = context.KHACHHANGs.FirstOrDefault(p => p.TenKhach.ToLower() == txtTimKiem.Text.ToLower());
                KHACHHANG x = context.KHACHHANGs.FirstOrDefault(p => p.SoCMND == txtTimKiem.Text);
                KHACHHANG z = context.KHACHHANGs.FirstOrDefault(p => p.DienThoai == txtTimKiem.Text);
                List<KHACHHANG> listKH1 = new List<KHACHHANG>();
                List<KHACHHANG> listKH2 = new List<KHACHHANG>();
                List<KHACHHANG> listKH3 = new List<KHACHHANG>();
                listKH1.Add(s);
                listKH2.Add(x); listKH3.Add(z);
                if (x != null)
                {
                    dgvKhachHang.Rows.Clear();
                    BindGrid(listKH2);
                }
                else if (s != null)
                {
                    dgvKhachHang.Rows.Clear();
                    BindGrid(listKH1);
                }
                else if (z != null)
                {
                    dgvKhachHang.Rows.Clear();
                    BindGrid(listKH3);
                }
                else
                {
                    MessageBox.Show("không tìm thấy");
                }

            }
             
            
         
        }
        //nhấn enter để tìm kiếm

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               btnFind.PerformClick();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            try
            {
                KHACHHANG s = context.KHACHHANGs.FirstOrDefault(p => p.TenKhach.ToLower() == txtTimKiem.Text.ToLower());
                if (s != null)
                {
                    context.KHACHHANGs.Remove(s);
                    context.SaveChanges();
                    load();
                }

            }
            catch
            {

            }
          
            
        }

        private void btnEx_Click(object sender, EventArgs e)
        {

            try
            {
                string saveExcelFile = @"L:\report.xlsx";

                Excel.Application xlApp = new Excel.Application();

                if (xlApp == null)
                {
                    MessageBox.Show("Lỗi không thể sử dụng được thư viện EXCEL");
                    return;
                }
                xlApp.Visible = false;

                object misValue = System.Reflection.Missing.Value;

                Workbook wb = xlApp.Workbooks.Add(misValue);

                Worksheet ws = (Worksheet)wb.Worksheets[1];

                if (ws == null)
                {
                    MessageBox.Show("Không thể tạo được WorkSheet");
                    return;
                }
                int row = 1;
                string fontName = "Times New Roman";
                int fontSizeTieuDe = 18;
                int fontSizeTenTruong = 14;
                int fontSizeNoiDung = 12;

                Range row1_TieuDe_ThongKeSanPham = ws.get_Range("A1", "F1");
                row1_TieuDe_ThongKeSanPham.Merge();
                row1_TieuDe_ThongKeSanPham.Font.Size = fontSizeTieuDe;
                row1_TieuDe_ThongKeSanPham.Font.Name = fontName;
                row1_TieuDe_ThongKeSanPham.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row1_TieuDe_ThongKeSanPham.Value2 = "DANH SÁCH KHÁCH HÀNG";

                Range row23_STT = ws.get_Range("A2", "A3");//Cột A dòng 2 và dòng 3
                row23_STT.Merge();
                row23_STT.Font.Size = fontSizeTenTruong;
                row23_STT.Font.Name = fontName;
                row23_STT.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_STT.Value2 = "STT";

                Range row23_MaTP = ws.get_Range("B2", "B3");//Cột B dòng 2 và dòng 3
                row23_MaTP.Merge();
                row23_MaTP.Font.Size = fontSizeTenTruong;
                row23_MaTP.Font.Name = fontName;
                row23_MaTP.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_MaTP.Value2 = "Mã KH";
                row23_MaTP.ColumnWidth = 20;


                Range row23_MaPhong = ws.get_Range("C2", "C3");//Cột C dòng 2 và dòng 3
                row23_MaPhong.Merge();
                row23_MaPhong.Font.Size = fontSizeTenTruong;
                row23_MaPhong.Font.Name = fontName;
                row23_MaPhong.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_MaPhong.ColumnWidth = 20;
                row23_MaPhong.Value2 = "Tên KH";


                Range row2_NĐ = ws.get_Range("D2", "D3");//Cột D->E của dòng 2
                row2_NĐ.Merge();
                row2_NĐ.Font.Size = fontSizeTenTruong;
                row2_NĐ.Font.Name = fontName;
                row2_NĐ.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                row2_NĐ.Value2 = "CMND";


                Range row3_NĐ = ws.get_Range("E3", "E3");//Ô D3

                row3_NĐ.Merge();
                row3_NĐ.Font.Size = fontSizeTenTruong;
                row3_NĐ.Font.Name = fontName;
                row3_NĐ.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row3_NĐ.Value2 = "SĐT";
                row3_NĐ.ColumnWidth = 20;


                Range row3_NgayTT = ws.get_Range("F3", "F3");//Ô E3
                row3_NgayTT.Font.Size = fontSizeTenTruong;
                row3_NgayTT.Font.Name = fontName;
                row3_NgayTT.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row3_NgayTT.Value2 = "Địa chỉ";
                row3_NgayTT.ColumnWidth = 20;

              


                Range row23_CotTieuDe = ws.get_Range("A2", "F3");
                //nền vàng
                row23_CotTieuDe.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                //in đậm
                row23_CotTieuDe.Font.Bold = true;
                //chữ đen
                row23_CotTieuDe.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

                int stt = 0;
                row = 3;//dữ liệu xuất bắt đầu từ dòng số 4 trong file Excel (khai báo 3 để vào vòng lặp nó ++ thành 4)
                Model1 context = new Model1();
                foreach (KHACHHANG hd in context.KHACHHANGs)
                {
                    stt++;
                    row++;
                    dynamic[] arr = { stt, hd.MaKhach, hd.TenKhach, hd.SoCMND, hd.DienThoai.ToString(), hd.DiaChi };
                    Range rowData = ws.get_Range("A" + row, "F" + row);//Lấy dòng thứ row ra để đổ dữ liệu
                    rowData.Font.Size = fontSizeNoiDung;
                    rowData.Font.Name = fontName;
                    rowData.Value2 = arr;
                }
                //Kẻ khung toàn bộ
                //BorderAround(ws.get_Range("A2", "E2"+row));

                //Lưu file excel xuống Ổ cứng
                wb.SaveAs(saveExcelFile);

                //đóng file để hoàn tất quá trình lưu trữ
                wb.Close(true, misValue, misValue);
                //thoát và thu hồi bộ nhớ cho COM
                xlApp.Quit();
                releaseObject(ws);
                releaseObject(wb);
                releaseObject(xlApp);

                //Mở File excel sau khi Xuất thành công
                System.Diagnostics.Process.Start(saveExcelFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj = null;
            }
            finally
            { GC.Collect(); }
        }

        private void BorderAround(Range range)
        {
            Borders borders = range.Borders;
            borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            borders.Color = Color.Black;
            borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlDiagonalUp].LineStyle = XlLineStyle.xlLineStyleNone;
            borders[XlBordersIndex.xlDiagonalDown].LineStyle = XlLineStyle.xlLineStyleNone;
        }

    
        private void copyAlltoClipboard()
        {
            dgvKhachHang.SelectAll();
            DataObject dataObj = dgvKhachHang.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

   
        //lọc khách hàng theo ngày
        private void lockhachang(List<CHITIETTHUEPHONG> listthue)
        {
            Model1 context = new Model1();
            List<KHACHHANG> khachhang = new List<KHACHHANG>();
            List<THUEPHONG> thuephong = context.THUEPHONGs.ToList();
            List<KHACHHANG> s = context.KHACHHANGs.ToList();
            foreach(var  item in listthue)
            {
                foreach(var item1 in thuephong)
                {
                    if(item1.SoPhieuTP == item.SoPhieuTP)
                    {
                        foreach(var item2 in s)
                        {
                            if(item2.MaKhach == item1.MaKhach)
                            {
                                if(item.NgayNhan>=dateTimePicker1.Value && item.NgayTra <= dateTimePicker2.Value)
                                {
                                    khachhang.Add(item2);
                                }
                            }
                        }
                    }
                   
                }
              
            }
            if (khachhang != null)
            {
                dgvKhachHang.Rows.Clear();
                BindGrid(khachhang);
            }
        }
        private void btnLoc_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<CHITIETTHUEPHONG> s = context.CHITIETTHUEPHONGs.ToList();
            lockhachang(s);

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
                load();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    }


