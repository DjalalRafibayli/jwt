using EfCodeFirst.Models.ApiResponse;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirst.Share.Api.Interfaces.Helpers
{
    public interface IHelperRefreshToken
    {
        Task<ResponseTokens> GetTokens(string apiUrl,RequestTokens p);
    }
}
