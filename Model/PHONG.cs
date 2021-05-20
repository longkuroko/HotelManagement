namespace QuanLyNhaNghi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHONG")]
    public partial class PHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHONG()
        {
            CHITIETHOADONs = new HashSet<CHITIETHOADON>();
            CHITIETTHUEPHONGs = new HashSet<CHITIETTHUEPHONG>();
            PHIEUDICHVUs = new HashSet<PHIEUDICHVU>();
            TIENNGHIs = new HashSet<TIENNGHI>();
        }

        [Key]
        [StringLength(10)]
        public string MaPhong { get; set; }

        public double? GiaTien { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [StringLength(6)]
        public string MaLoaiPhong { get; set; }

        [StringLength(6)]
        public string STTTang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETTHUEPHONG> CHITIETTHUEPHONGs { get; set; }

        public virtual LOAIPHONG LOAIPHONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDICHVU> PHIEUDICHVUs { get; set; }

        public virtual TANGLAU TANGLAU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIENNGHI> TIENNGHIs { get; set; }
    }
}
