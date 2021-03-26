namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Video")]
    public partial class Video
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Video()
        {
            BinhLuans = new HashSet<BinhLuan>();
            VideoYeuThiches = new HashSet<VideoYeuThich>();
        }

        [Key]
        public int IdVideo { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Bạn cần phải nhập trường này")]
        public string TieuDe { get; set; }

        public int? IdNgheSi { get; set; }

        public int? IdKhuVuc { get; set; }

        [Required(ErrorMessage = "Bạn cần phải nhập trường này")]
        public string Poster { get; set; }

        [Required(ErrorMessage = "Bạn cần phải phải nhập trường này")]
        public string LinkVideoMp4 { get; set; }

        public int? LuotXem { get; set; }

        public int? LuotThich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        public virtual KhuVuc KhuVuc { get; set; }

        public virtual NgheSi NgheSi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VideoYeuThich> VideoYeuThiches { get; set; }
    }
}
