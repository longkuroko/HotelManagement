namespace QuanLyNhaNghi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAITIENNGHI")]
    public partial class LOAITIENNGHI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAITIENNGHI()
        {
            TIENNGHIs = new HashSet<TIENNGHI>();
        }

        [Key]
        [StringLength(10)]
        public string MaLoaiTienNghi { get; set; }

        [StringLength(50)]
        public string TenLoaiTienNghi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayMua { get; set; }

        public double? GiaMua { get; set; }

        [StringLength(40)]
        public string TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIENNGHI> TIENNGHIs { get; set; }
    }
}
