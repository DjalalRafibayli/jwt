using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirst.Share.Api.Interfaces.Helpers
{
    public interface IHelperLogin
    {
        Task<string> LoginRepoAsync<T>(string apiUrl, T t);
    }
}
