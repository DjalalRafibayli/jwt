using System.Threading.Tasks;

namespace EfCodeFirst.Share.Api.Interfaces.Request
{
    public interface IRequest
    {
        public Task<string> GetTable(string apiUrl);
    }
}
