using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class TimKiemDAO
    {
        MusicDBContext context;
        public TimKiemDAO()
        {
            context = new MusicDBContext();
        }

        public List<BaiHat> TimKiem(string ten)
        {
            var x = context.BaiHats.Where(t => t.TenBaiHat.Contains(ten)).ToList();
            return x;
        }

        public List<string> AutoSearch(string ten)
        {
            var x = context.BaiHats.Where(t => t.TenBaiHat.Contains(ten)).Select(t => t.TenBaiHat).ToList();
            return x;
        }
    }
}
