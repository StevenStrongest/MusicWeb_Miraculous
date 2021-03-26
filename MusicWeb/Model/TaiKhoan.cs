namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            Tintucs = new HashSet<Tintuc>();
        }

        [Key]
        public int IdTaiKhoan { get; set; }

        [Column("TaiKhoan")]
        [StringLength(100)]
        [Required(ErrorMessage = "Bạn cần phải phải nhập trường này")]
        public string TaiKhoan1 { get; set; }

        [StringLength(100)]

        [Required(ErrorMessage = "Bạn cần phải phải nhập trường này")]
        public string MatKhau { get; set; }

        public int? IdLoaiTaiKhoan { get; set; }

        public virtual LoaiTaiKhoan LoaiTaiKhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tintuc> Tintucs { get; set; }
    }
}
