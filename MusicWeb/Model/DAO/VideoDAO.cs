using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
   public class VideoDAO
    {
        MusicDBContext context;

        public VideoDAO()
        {
            context = new MusicDBContext();
        }

        public List<Video> ListOf()
        {
            List<Video> video = context.Videos.ToList();
            return video;
        }

        public Video GetVideoById(int id)
        {
            var v = context.Videos.SingleOrDefault(x => x.IdVideo == id);
            return v;
        }

        public int AddNew(Video obj)
        {
            var result = context.Videos.Add(obj);
            if (result != null)
            {
                context.SaveChanges();
                return result.IdVideo;
            }
            return -1;
        }
        public bool Update(Video obj)
        {
            var ab = context.Videos.SingleOrDefault(x => x.IdVideo == obj.IdVideo);
            if (ab != null)
            {
                ab.TieuDe = obj.TieuDe;
                ab.IdNgheSi = obj.IdNgheSi;
                ab.IdKhuVuc = obj.IdKhuVuc;
                ab.Poster = obj.Poster;
                ab.LinkVideoMp4 = obj.LinkVideoMp4;


                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Delete(int id)
        {
            var ab = context.Videos.SingleOrDefault(x => x.IdVideo == id);
            if (ab != null)
            {
                context.Videos.Remove(ab);
                context.SaveChanges();
            }
        }

        public bool Upload(int id, string Name)
        {
            var ab = context.Videos.SingleOrDefault(x => x.IdVideo == id);
            if (ab != null)
            {
                ab.LinkVideoMp4 = Name;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
