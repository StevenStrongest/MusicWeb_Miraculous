namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhacCaNhan")]
    public partial class NhacCaNhan
    {
        [Key]
        public int IdNhacCaNhan { get; set; }

        public int? IdNguoiDung { get; set; }

        [StringLength(500)]
        public string TenBaiHat { get; set; }

        [StringLength(500)]
        public string NgheSiThucHien { get; set; }

        public string LinkNhac { get; set; }

        public string AnhBaiHat { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
