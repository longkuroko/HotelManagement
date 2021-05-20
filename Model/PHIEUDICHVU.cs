namespace QuanLyNhaNghi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUDICHVU")]
    public partial class PHIEUDICHVU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUDICHVU()
        {
            CHITIETDICHVUs = new HashSet<CHITIETDICHVU>();
            CHITIETHOADONs = new HashSet<CHITIETHOADON>();
        }

        [Key]
        [StringLength(10)]
        public string SoPhieuDV { get; set; }

        [StringLength(10)]
        public string SoPhieuTP { get; set; }

        [StringLength(10)]
        public string MaPhong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThucHienDV { get; set; }

        public double? TongTienDV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDICHVU> CHITIETDICHVUs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }

        public virtual THUEPHONG THUEPHONG { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}
