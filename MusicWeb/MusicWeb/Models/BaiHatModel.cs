using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicWeb.Models
{
    public class BaiHatModel
    {
        public int Id { get; set; }

        public string Link { set; get; }

        public string Anh { set; get; }

        public string Ten { set; get; }

        public string TenCaSi { set; get; }

        public BaiHatModel(string src, int id, string anh, string ten, string tencasi)
        {
            Id = id;
            Link = src;
            Anh = anh;
            Ten = ten;
            TenCaSi = tencasi;
        }
    }
}