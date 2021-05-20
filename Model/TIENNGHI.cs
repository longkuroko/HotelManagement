namespace QuanLyNhaNghi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TIENNGHI")]
    public partial class TIENNGHI
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaLoaiTienNghi { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaPhong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBatDauTrangBi { get; set; }

        public virtual LOAITIENNGHI LOAITIENNGHI { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}
