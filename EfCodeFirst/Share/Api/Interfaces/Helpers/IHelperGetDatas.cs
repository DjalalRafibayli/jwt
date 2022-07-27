using EfCodeFirst.Models.ApiResponse;
using EfCodeFirst.Models.ViewModels;
using System.Threading.Tasks;

namespace EfCodeFirst.Share.Api.Interfaces.Helpers
{
    public interface IHelperGetDatas
    {
        Task<ResponseWithToken> GetDatas(string apiUrl,LoginViewModel m);
    }
}
