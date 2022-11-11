using EfCodeFirstAPI.JWT.Model;
using System.Threading.Tasks;

namespace EfCodeFirst.Share.Api.Interfaces.Identity
{
    public interface IIdentityService
    {
        public Task<Tokens> GetAccessTokenByRefreshToken();
    }
}
