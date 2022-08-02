using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCodeFirst.Models.ViewModels
{
    public class PaginationModel
    {
        public int pageCount { get; set; }
        public int limit { get; set; }
        public int activePage { get; set; }
    }
}
