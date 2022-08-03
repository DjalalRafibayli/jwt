using DataAccessLayer.Models.ViewModels;
using System.Collections.Generic;

namespace EfCodeFirst.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string username { get; set; }
        public byte active { get; set; }

        //public IList<PaginationModel> PaginationModels { get; set; }
        //public UserViewModel()
        //{
        //    PaginationModels = new List<PaginationModel>();
        //}


    }
}
