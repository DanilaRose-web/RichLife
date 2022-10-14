using System.Collections.Generic;
using System.Threading.Tasks;

namespace RIchLife.Utilites.Page
{
    public class PageResponse<T>
    {
        public List<T> Data { get; set; }
        public int Count { get; set; }
        public int Size { get; set; }
        public int Current { get; set; }
    }
}
