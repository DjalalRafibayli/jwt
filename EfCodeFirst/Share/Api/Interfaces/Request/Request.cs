using System.Net.Http;
using System.Threading.Tasks;

namespace EfCodeFirst.Share.Api.Interfaces.Request
{
    public class Request : IRequest
    {
        private readonly HttpClient _client;

        public Request(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetTable(string apiUrl)
        {
            var apiResponse = await _client.GetAsync(apiUrl);
            return await apiResponse.Content.ReadAsStringAsync();
        }
    }
}
