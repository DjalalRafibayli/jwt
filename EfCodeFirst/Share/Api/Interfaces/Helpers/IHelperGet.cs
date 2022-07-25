using System.Threading.Tasks;

namespace EfCodeFirst.Share.Api.Interfaces.Helpers
{
    public interface IHelperGet
    {
        Task<string> GetRepoBool(string apiUrl, string username);
    }
}
