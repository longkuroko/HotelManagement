namespace QuanLyNhaNghi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETDICHVU")]
    public partial class CHITIETDICHVU
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string SoPhieuDV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaDichVu { get; set; }

        public int? SoLuong { get; set; }

        public virtual DICHVU DICHVU { get; set; }

        public virtual PHIEUDICHVU PHIEUDICHVU { get; set; }
    }
}
