using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class AlbumDAO
    {
        MusicDBContext context;
        public AlbumDAO()
        {
            context = new MusicDBContext();
        }
        public List<Album> Listof()
        {
            List<Album> listalbum = new List<Album>();
            listalbum = context.Albums.ToList();
            return listalbum;
        }

        public int Addalbum(Album obj)
        {
            obj.Hot = true;
            var result = context.Albums.Add(obj);
            if (result != null)
            {
                context.SaveChanges();
                return result.IdAlbum;
            }
            return -1;
        }
        public bool UpdateAlbum(Album obj)
        {
            var ab = context.Albums.SingleOrDefault(x => x.IdAlbum == obj.IdAlbum);
            if (ab != null)
            {
                ab.TenAlbum = obj.TenAlbum;
                ab.AnhAlbum = obj.AnhAlbum;
                ab.KhuVuc = obj.KhuVuc;
                ab.IdNgheSi = obj.IdNgheSi;
                ab.Hot = true;


                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteAlbum(int id)
        {
            var ab = context.Albums.SingleOrDefault(x => x.IdAlbum == id);
            if (ab != null)
            {
                context.Albums.Remove(ab);
                context.SaveChanges();
            }
        }

        public bool Upload(int id, string imgName)
        {
            var ab = context.Albums.SingleOrDefault(x => x.IdAlbum == id);
            if (ab != null)
            {
                ab.AnhAlbum = imgName;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Album Detail(int id)
        {
            var result = context.Albums.SingleOrDefault(x => x.IdAlbum == id);
            return result;
        }

        //Album Hot
        public List<Album> AlbumHot()
        {
            var al = context.Albums.Where(x => x.Hot == true).ToList();
            return al;
        }
        //Danh Sách Bài Hát Theo Album
        public List<BaiHat> BaiHatByAlbum()
        {
            var bh = context.BaiHats.SqlQuery("select * from BaiHat as bh, Album as ab where bh.IdAlbum = ab.IdAlbum").ToList();
            return bh;
        }
    }
}
