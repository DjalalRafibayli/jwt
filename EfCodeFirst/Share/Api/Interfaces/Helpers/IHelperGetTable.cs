using EfCodeFirst.Models.ApiResponse;
using EfCodeFirst.Models.ViewModels;
using System.Threading.Tasks;

namespace EfCodeFirst.Share.Api.Interfaces.Helpers
{
    public interface IHelperGetTable
    {
        //Task<ResponseWithToken> GetDatas(string apiUrl,LoginViewModel m);
        Task<string> GetTable(string apiUrl);
        Task<string> GetTable<T>(string apiUrl, T t);
    }
}
