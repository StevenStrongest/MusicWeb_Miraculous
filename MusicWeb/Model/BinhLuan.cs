namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [Key]
        public int IdBinhLuan { get; set; }

        public int? IdNguoiDung { get; set; }

        public int? Idchung { get; set; }

        public string NoiDungBinhLuan { get; set; }

        [StringLength(255)]
        public string ThuocTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGian { get; set; }

        public virtual BaiHat BaiHat { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual Video Video { get; set; }
    }
}
