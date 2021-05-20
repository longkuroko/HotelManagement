namespace QuanLyNhaNghi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHANCONG")]
    public partial class PHANCONG
    {
        [Key]
        [StringLength(6)]
        public string MaNV { get; set; }

        [StringLength(6)]
        public string Ca { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
