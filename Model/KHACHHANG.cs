namespace QuanLyNhaNghi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            THUEPHONGs = new HashSet<THUEPHONG>();
        }

        [Key]
        [StringLength(10)]
        public string MaKhach { get; set; }

        [StringLength(50)]
        public string TenKhach { get; set; }

        [StringLength(9)]
        public string SoCMND { get; set; }

        [StringLength(10)]
        public string DienThoai { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [StringLength(6)]
        public string MaLoaiKH { get; set; }

        public virtual LOAIKHACHHANG LOAIKHACHHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THUEPHONG> THUEPHONGs { get; set; }
    }
}
