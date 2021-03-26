namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tintuc")]
    public partial class Tintuc
    {
        [Key]
        public int IdTinTuc { get; set; }

        [StringLength(255)]
        public string TieuDeTinTuc { get; set; }

        public string AnhTieuDe { get; set; }

        public string NoiDung { get; set; }

        public DateTime? ThoiGian { get; set; }

        public int? IdTaiKhoan { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
