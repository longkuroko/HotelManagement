namespace QuanLyNhaNghi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETHOADON")]
    public partial class CHITIETHOADON
    {
        [Key]
        [StringLength(10)]
        public string MaHD { get; set; }

        [StringLength(10)]
        public string SoPhieuTP { get; set; }

        [StringLength(10)]
        public string SoPhieuDV { get; set; }

        [StringLength(10)]
        public string MaPhong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThanhToan { get; set; }

        public double? TongTien { get; set; }

        public virtual THUEPHONG THUEPHONG { get; set; }

        public virtual PHIEUDICHVU PHIEUDICHVU { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}
