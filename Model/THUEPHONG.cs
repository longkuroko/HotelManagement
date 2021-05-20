namespace QuanLyNhaNghi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("THUEPHONG")]
    public partial class THUEPHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THUEPHONG()
        {
            CHITIETHOADONs = new HashSet<CHITIETHOADON>();
            CHITIETTHUEPHONGs = new HashSet<CHITIETTHUEPHONG>();
            PHIEUDICHVUs = new HashSet<PHIEUDICHVU>();
        }

        [Key]
        [StringLength(10)]
        public string SoPhieuTP { get; set; }

        [StringLength(10)]
        public string MaKhach { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETTHUEPHONG> CHITIETTHUEPHONGs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDICHVU> PHIEUDICHVUs { get; set; }

        internal static DataTable GetAllData()
        {
            throw new NotImplementedException();
        }
    }
}
