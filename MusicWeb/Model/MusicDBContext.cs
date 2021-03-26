namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MusicDBContext : DbContext
    {
        public MusicDBContext()
            : base("name=MusicDBContext")
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<AlbumYeuThich> AlbumYeuThiches { get; set; }
        public virtual DbSet<BaiHat> BaiHats { get; set; }
        public virtual DbSet<BaiHatYeuThich> BaiHatYeuThiches { get; set; }
        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<KhuVuc> KhuVucs { get; set; }
        public virtual DbSet<LoaiTaiKhoan> LoaiTaiKhoans { get; set; }
        public virtual DbSet<NgheSi> NgheSis { get; set; }
        public virtual DbSet<NgheSiYeuThich> NgheSiYeuThiches { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NhacCaNhan> NhacCaNhans { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<Tintuc> Tintucs { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<VideoYeuThich> VideoYeuThiches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiHat>()
                .HasMany(e => e.BinhLuans)
                .WithOptional(e => e.BaiHat)
                .HasForeignKey(e => e.Idchung);

            modelBuilder.Entity<Video>()
                .HasMany(e => e.BinhLuans)
                .WithOptional(e => e.Video)
                .HasForeignKey(e => e.Idchung);
        }
    }
}
