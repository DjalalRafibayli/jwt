using DataAccessLayer.Models.ViewModels;

namespace EfCodeFirst.Models.ViewModels
{
    public class UserViewModel : PaginationModel
    {
        public int Id { get; set; }
        public string username { get; set; }
        public byte active { get; set; }
    }
}
