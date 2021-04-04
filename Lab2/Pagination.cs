using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Pagination
    {
        public int PageIndex { get; set; }
        public int RecordsPerPage { get; set; }
        public List<CyberDanger> CyberDangers { get; set; } = new List<CyberDanger>();

        public List<CyberDanger> Next()
        {
            PageIndex++;
            if (PageIndex >= CyberDangers.Count / RecordsPerPage)
            {
                PageIndex = CyberDangers.Count / RecordsPerPage;
            }
            return SetPaging();
        }
        public List<CyberDanger> Previous()
        {
            PageIndex--;
            if (PageIndex <= 0)
            {
                PageIndex = 0;
            }
            return SetPaging();
        }
        public List<CyberDanger> First()
        {
            PageIndex = 0;
            return SetPaging();
        }

        public List<CyberDanger> Last()
        {
            PageIndex = CyberDangers.Count / RecordsPerPage; 
            return SetPaging();
        }
        public List<CyberDanger> SetPaging()
        {
            int pageGroup = PageIndex * RecordsPerPage;
            return CyberDangers.Skip(pageGroup).Take(RecordsPerPage).ToList();
        }
    }

}
