using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class VideoYeuThichDAO
    {
        MusicDBContext context;

        public VideoYeuThichDAO()
        {
            context = new MusicDBContext();
        }

        public void Add(VideoYeuThich bh)
        {
            context.VideoYeuThiches.Add(bh);
            context.SaveChanges();
        }

        public bool KiemTra(int idVideo,int idNguoiDung)
        {
            var x = context.VideoYeuThiches.SingleOrDefault(v => v.IdVideo == idVideo && v.IdNguoiDung == idNguoiDung);
            if (x != null)
                return false;
            return true;
        }


        public void Delete(int idVideo, int idNguoiDung)
        {
            var x = context.VideoYeuThiches.SingleOrDefault(v => v.IdVideo == idVideo && v.IdNguoiDung == idNguoiDung);
            context.VideoYeuThiches.Remove(x);
            context.SaveChanges();
        }

        public object LitVideoYeuThich(int id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var bl = from x in context.VideoYeuThiches
                     join
                    b in context.Videos on
                    x.IdVideo equals b.IdVideo
                     where x.IdVideo == b.IdVideo && x.IdNguoiDung == id
                     select new
                     {
                         IdVideo = x.IdVideo,
                         TieuDe = b.TieuDe,
                         Poster = b.Poster
                     };
            return bl;
        }
    }
}
