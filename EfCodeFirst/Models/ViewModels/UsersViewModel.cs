namespace EfCodeFirst.Models.ViewModels
{
    public class UsersViewModel : PaginationModel
    {
        public int Id { get; set; }
        public string username { get; set; }
        public byte active { get; set; }
    }
}
