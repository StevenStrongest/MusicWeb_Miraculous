namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AlbumYeuThich")]
    public partial class AlbumYeuThich
    {
        [Key]
        public int IdAlbumYeuThich { get; set; }

        public int? IdNguoiDung { get; set; }

        public int? IdAlbum { get; set; }

        public virtual Album Album { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
