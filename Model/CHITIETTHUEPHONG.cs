namespace QuanLyNhaNghi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETTHUEPHONG")]
    public partial class CHITIETTHUEPHONG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string SoPhieuTP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaPhong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTra { get; set; }

        public double? TienThuePhong { get; set; }

        public virtual PHONG PHONG { get; set; }

        public virtual THUEPHONG THUEPHONG { get; set; }
    }
}
