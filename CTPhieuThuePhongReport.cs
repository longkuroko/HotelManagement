using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaNghi.Model;

namespace QuanLyNhaNghi
{
    class CTPhieuThuePhongReport
    {
        public string SoPhieuTP { get; set; }

        public string MaPhong { get; set; }

        public DateTime? NgayNhan { get; set; }

        public DateTime? NgayTra { get; set; }

        public float TienThuePhong { get; set; }

    }
}
