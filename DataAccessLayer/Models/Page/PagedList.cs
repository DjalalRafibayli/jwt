using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Page
{
    public abstract class PagedResultBase
    {
        //public PagedList(IQueryable<T> query ,int count , int limit ,int activePage )
        //{
            
        //}
        public int count { get; set; }
        public int countPage { get; set; }
        public int limit { get; set; }
        public int activePage { get; set; }

    }
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}