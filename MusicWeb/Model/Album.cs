namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Album")]
    public partial class Album
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Album()
        {
            AlbumYeuThiches = new HashSet<AlbumYeuThich>();
            BaiHats = new HashSet<BaiHat>();
        }

        [Key]
        public int IdAlbum { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Bạn cần phải phải nhập trường này")]
        public string TenAlbum { get; set; }

        [Required(ErrorMessage = "Bạn cần phải phải nhập trường này")]

        public string AnhAlbum { get; set; }

        public int? IdKhuVuc { get; set; }

        public int? IdNgheSi { get; set; }

        public bool? Hot { get; set; }

        public virtual KhuVuc KhuVuc { get; set; }

        public virtual NgheSi NgheSi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlbumYeuThich> AlbumYeuThiches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiHat> BaiHats { get; set; }
    }
}
