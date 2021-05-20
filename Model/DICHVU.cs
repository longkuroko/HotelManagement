namespace QuanLyNhaNghi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DICHVU")]
    public partial class DICHVU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DICHVU()
        {
            CHITIETDICHVUs = new HashSet<CHITIETDICHVU>();
        }

        [Key]
        [StringLength(10)]
        public string MaDichVu { get; set; }

        [StringLength(50)]
        public string TenDichVu { get; set; }

        public double? DonGiaDV { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDICHVU> CHITIETDICHVUs { get; set; }
    }
}
