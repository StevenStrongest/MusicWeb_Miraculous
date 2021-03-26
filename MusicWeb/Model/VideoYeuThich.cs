namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VideoYeuThich")]
    public partial class VideoYeuThich
    {
        [Key]
        public int IdVideoYeuThich { get; set; }

        public int? IdNguoiDung { get; set; }

        public int? IdVideo { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual Video Video { get; set; }
    }
}
