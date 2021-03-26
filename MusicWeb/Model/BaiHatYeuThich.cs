namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiHatYeuThich")]
    public partial class BaiHatYeuThich
    {
        [Key]
        public int IdBaiHatYeuThich { get; set; }

        public int? IdNguoiDung { get; set; }

        public int? IdBaiHat { get; set; }

        public string TrangThaiThich { get; set; }

        public virtual BaiHat BaiHat { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
