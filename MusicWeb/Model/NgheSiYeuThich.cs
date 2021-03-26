namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NgheSiYeuThich")]
    public partial class NgheSiYeuThich
    {
        [Key]
        public int IdNgheSiYeuThich { get; set; }

        public int? IdNguoiDung { get; set; }

        public int? IdNgheSi { get; set; }

        public virtual NgheSi NgheSi { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
