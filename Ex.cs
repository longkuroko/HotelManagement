using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

using QuanLyNhaNghi.Model;
namespace QuanLyNhaNghi
{
    public partial class Ex : Form
    {
        public Ex()
        {
            InitializeComponent();
        }

        private void Ex_Load(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<CHITIETHOADON> listHD = context.CHITIETHOADONs.ToList();
            List<CHITIETTHUEPHONG> listTP = context.CHITIETTHUEPHONGs.ToList();
            List<PHIEUDICHVU> listdv = context.PHIEUDICHVUs.ToList();
            BindGrid(listHD);
            BindGrid1(listTP);
          
        }
        private void check()
        {
            if (radiothuephong.Checked == true)
            {
                Title.Text = "DANH SÁCH PHIẾU THUÊ PHÒNG";
           
                dgv.Visible = false;
                dgvPhieuThue.Visible = true;
            }
          
            if (radiohoadon.Checked == true)
            {
                Title.Text = "DANH SÁCH HÓA ĐƠN";
                dgvPhieuThue.Visible = false;
               
                dgv.Visible = true;
            }

        }

        //bindgrid
        private void BindGrid(List<CHITIETHOADON> listHoadon)
        {

            dgv.Rows.Clear();
            foreach (var item in listHoadon)
            {
                int index = dgv.Rows.Add();
                dgv.Rows[index].Cells[0].Value = item.MaHD;
                dgv.Rows[index].Cells[1].Value = item.SoPhieuTP;
                dgv.Rows[index].Cells[2].Value = item.SoPhieuDV;
                dgv.Rows[index].Cells[3].Value = item.MaPhong;
                dgv.Rows[index].Cells[4].Value = item.THUEPHONG.MaKhach;
                dgv.Rows[index].Cells[5].Value = item.TongTien;
                dgv.Rows[index].Cells[6].Value = item.PHIEUDICHVU.TongTienDV;
                dgv.Rows[index].Cells[7].Value = item.TongTien;

            }
        }
        private void BindGrid1(List<CHITIETTHUEPHONG> listthuephong)
        {
            dgvPhieuThue.Rows.Clear();
            foreach (var item in listthuephong)
            {
                int index = dgvPhieuThue.Rows.Add();
                dgvPhieuThue.Rows[index].Cells[0].Value = item.SoPhieuTP;
                dgvPhieuThue.Rows[index].Cells[1].Value = item.MaPhong;
                dgvPhieuThue.Rows[index].Cells[3].Value = item.NgayNhan;
                dgvPhieuThue.Rows[index].Cells[4].Value = item.NgayTra;
                dgvPhieuThue.Rows[index].Cells[2].Value = item.THUEPHONG.MaKhach;
                dgvPhieuThue.Rows[index].Cells[5].Value = item.TienThuePhong;


            }
        }
     

        private void button2_Click(object sender, EventArgs e)
        {
            if (radiohoadon.Checked == true)
            {
                
                XuatHoaDon();
            }
            if (radiothuephong.Checked == true)
            {
                PhieuThue();
                
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

        private void button1_Click(object sender, EventArgs e)
        {
            check();
        }
        private void XuatHoaDon()
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
                //Xuất dòng Tiêu đề của File báo cáo: Lưu ý
                Range row1_TieuDe_ThongKeSanPham = ws.get_Range("A1", "G1");
                row1_TieuDe_ThongKeSanPham.Merge();
                row1_TieuDe_ThongKeSanPham.Font.Size = fontSizeTieuDe;
                row1_TieuDe_ThongKeSanPham.Font.Name = fontName;
                row1_TieuDe_ThongKeSanPham.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row1_TieuDe_ThongKeSanPham.Value2 = "DANH SÁCH HÓA ĐƠN";

                //Tạo Ô Số Thứ Tự (STT)
                Range row23_STT = ws.get_Range("A2", "A3");//Cột A dòng 2 và dòng 3
                row23_STT.Merge();
                row23_STT.Font.Size = fontSizeTenTruong;
                row23_STT.Font.Name = fontName;
                row23_STT.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_STT.Value2 = "STT";

                //Tạo Ô Mã Sản phẩm :
                Range row23_MaHD = ws.get_Range("B2", "B3");//Cột B dòng 2 và dòng 3
                row23_MaHD.Merge();
                row23_MaHD.Font.Size = fontSizeTenTruong;
                row23_MaHD.Font.Name = fontName;
                row23_MaHD.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_MaHD.Value2 = "Mã Hóa Đơn";
                row23_MaHD.ColumnWidth = 20;

                //Tạo Ô Tên Sản phẩm :
                Range row23_SPTP = ws.get_Range("C2", "C3");//Cột C dòng 2 và dòng 3
                row23_SPTP.Merge();
                row23_SPTP.Font.Size = fontSizeTenTruong;
                row23_SPTP.Font.Name = fontName;
                row23_SPTP.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_SPTP.ColumnWidth = 20;
                row23_SPTP.Value2 = "Số phiếu thuê phòng";

                //Tạo Ô Giá Sản phẩm :
                Range row2_SPDV = ws.get_Range("D2", "D3");//Cột D->E của dòng 2
                row2_SPDV.Merge();
                row2_SPDV.Font.Size = fontSizeTenTruong;
                row2_SPDV.Font.Name = fontName;
                row2_SPDV.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row2_SPDV.Value2 = "Số phiếu DV";

                //Tạo Ô Giá Nhập:
                Range row3_Maphong = ws.get_Range("E3", "E3");//Ô D3
                row3_Maphong.Font.Size = fontSizeTenTruong;
                row3_Maphong.Font.Name = fontName;
                row3_Maphong.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row3_Maphong.Value2 = "Mã Phòng";
                row3_Maphong.ColumnWidth = 20;

                //Tạo Ô Giá Xuất:
                Range row3_NgayTT = ws.get_Range("F3", "F3");//Ô E3
                row3_NgayTT.Font.Size = fontSizeTenTruong;
                row3_NgayTT.Font.Name = fontName;
                row3_NgayTT.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row3_NgayTT.Value2 = "Ngày thanh toán";
                row3_NgayTT.ColumnWidth = 20;

                Range row3_tt = ws.get_Range("G3", "G3");//Ô F3
                row3_tt.Font.Size = fontSizeTenTruong;
                row3_tt.Font.Name = fontName;
                row3_tt.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row3_tt.Value2 = "Tổng tiền";
                row3_tt.ColumnWidth = 20;

                //Tô nền vàng các cột tiêu đề:
                Range row23_CotTieuDe = ws.get_Range("A2", "G3");
                //nền vàng
                row23_CotTieuDe.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                //in đậm
                row23_CotTieuDe.Font.Bold = true;
                //chữ đen
                row23_CotTieuDe.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

                int stt = 0;
                row = 3;//dữ liệu xuất bắt đầu từ dòng số 4 trong file Excel (khai báo 3 để vào vòng lặp nó ++ thành 4)
                Model1 context = new Model1();
                foreach (CHITIETHOADON hd in context.CHITIETHOADONs)
                {
                    stt++;
                    row++;
                    dynamic[] arr = { stt, hd.MaHD, hd.SoPhieuTP, hd.SoPhieuDV, hd.MaPhong, hd.NgayThanhToan.ToString(), hd.TongTien };
                    Range rowData = ws.get_Range("A" + row, "G" + row);//Lấy dòng thứ row ra để đổ dữ liệu
                    rowData.Font.Size = fontSizeNoiDung;
                    rowData.Font.Name = fontName;
                    rowData.Value2 = arr;
                }
                //Kẻ khung toàn bộ
                //BorderAround(ws.get_Range("A2", "E2" ));

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
        //Xuất Phiếu Thuê Phòng
        private void PhieuThue()
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
                row1_TieuDe_ThongKeSanPham.Value2 = "DANH SÁCH PHIẾU THUÊ";

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
                row23_MaTP.Value2 = "Số Phiếu thuê";
                row23_MaTP.ColumnWidth = 20;

           
                Range row23_MaPhong = ws.get_Range("C2", "C3");//Cột C dòng 2 và dòng 3
                row23_MaPhong.Merge();
                row23_MaPhong.Font.Size = fontSizeTenTruong;
                row23_MaPhong.Font.Name = fontName;
                row23_MaPhong.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_MaPhong.ColumnWidth = 20;
                row23_MaPhong.Value2 = "Mã Phòng";

          
                Range row2_NĐ = ws.get_Range("D2", "D3");//Cột D->E của dòng 2
                row2_NĐ.Merge();
                row2_NĐ.Font.Size = fontSizeTenTruong;
                row2_NĐ.Font.Name = fontName;
                row2_NĐ.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                row2_NĐ.Value2 = "Ngày đến";

              
                Range row3_NĐ = ws.get_Range("E3", "E3");//Ô D3

                row3_NĐ.Merge();
                row3_NĐ.Font.Size = fontSizeTenTruong;
                row3_NĐ.Font.Name = fontName;
                row3_NĐ.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row3_NĐ.Value2 = "Ngày đi";
                row3_NĐ.ColumnWidth = 20;

             
                Range row3_NgayTT = ws.get_Range("F3", "F3");//Ô E3
                row3_NgayTT.Font.Size = fontSizeTenTruong;
                row3_NgayTT.Font.Name = fontName;
                row3_NgayTT.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row3_NgayTT.Value2 = "Tổng tiền";
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
                foreach (CHITIETTHUEPHONG hd in context.CHITIETTHUEPHONGs)
                {
                    stt++;
                    row++;
                    dynamic[] arr = { stt, hd.SoPhieuTP, hd.MaPhong, hd.NgayNhan.ToString(), hd.NgayTra.ToString(), hd.TienThuePhong};
                    Range rowData = ws.get_Range("A" + row, "F" + row);//Lấy dòng thứ row ra để đổ dữ liệu
                    rowData.Font.Size = fontSizeNoiDung;
                    rowData.Font.Name = fontName;
                    rowData.Value2 = arr;
                }
                //Kẻ khung toàn bộ
                //BorderAround(ws.get_Range("A2", "E" + row));

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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
