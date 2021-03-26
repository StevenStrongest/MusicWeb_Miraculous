namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NgheSi")]
    public partial class NgheSi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NgheSi()
        {
            Albums = new HashSet<Album>();
            BaiHats = new HashSet<BaiHat>();
            NgheSiYeuThiches = new HashSet<NgheSiYeuThich>();
            Videos = new HashSet<Video>();
        }

        [Key]
        public int IdNgheSi { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Bạn cần phải phải nhập trường này")]
        public string TenNgheSi { get; set; }

        [Required(ErrorMessage = "Bạn cần phải phải nhập trường này")]
        public string AnhNgheSi { get; set; }

        public int? IdKhuVuc { get; set; }

        public string MoTa { get; set; }

        public int? LuotQuanTam { get; set; }

        public bool? Hot { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Album> Albums { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiHat> BaiHats { get; set; }

        public virtual KhuVuc KhuVuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NgheSiYeuThich> NgheSiYeuThiches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Video> Videos { get; set; }
    }
}
