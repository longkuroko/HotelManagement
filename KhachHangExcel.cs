using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaNghi
{
    class KhachHangExcel
    {
        public void Export(DataTable dt, string sheetName, string title)
        {
            //--------------------Tao doi tuong Excel---------------------------
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            //--------------------Tao moi 1 Excel WorkBook----------------------
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = "Khách hàng";
            //-------------------Tao phan dau-----------------------------------
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "C1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "20";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //------------------Tao tieu de cot---------------------------------
            Microsoft.Office.Interop.Excel.Range clID = oSheet.get_Range("A3", "A3");
            clID.Value2 = "Mã Khách hàng";
            clID.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range clName = oSheet.get_Range("B3", "B3");
            clName.Value2 = "Tên Khách  Hàng";
            clName.ColumnWidth = 25.0;
            Microsoft.Office.Interop.Excel.Range clDVT = oSheet.get_Range("C3", "C3");
            clDVT.Value2 = "ID";
            clDVT.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range clGiaBan = oSheet.get_Range("D3", "D3");
            clGiaBan.Value2 = "Điện thoại";
            clGiaBan.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range clSLT = oSheet.get_Range("E3", "E3");
            clSLT.Value2 = "Địa chỉ";
            clSLT.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "E3");
            rowHead.Font.Bold = true;
            //--------------------Ke vien---------------------------------------
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            //--------------------Thiet lap mau nen-----------------------------
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //--------------------Tao mang luu du lieu vao DataTable------------
            object[,] arr;
            arr = new object[dt.Rows.Count, dt.Columns.Count];
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                DataRow dr = dt.Rows[r];
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    arr[r, c] = dr[c];
                }
            }
            //-------------------Thiet lap vung dien du lieu---------------------
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = dt.Columns.Count;
            //------------------O bat dau dien du lieu---------------------------
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            //------------------O ket thuc dien du lieu--------------------------
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            //------------------Lay ve vung dien du lieu-------------------------
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            //-----------------Dien vao vung da thiet lap------------------------
            range.Value2 = arr;
            //-----------------Ke vien-------------------------------------------
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

        }
    }
}
