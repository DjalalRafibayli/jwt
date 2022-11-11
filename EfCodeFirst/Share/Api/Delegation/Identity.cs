using EfCodeFirst.Share.Api.Interfaces.Identity;
using EfCodeFirstAPI.JWT.Model;
using System.Threading.Tasks;

namespace EfCodeFirst.Share.Api.Delegation
{
    public class Identity : IIdentityService
    {
        public Task<Tokens> GetAccessTokenByRefreshToken()
        {
            throw new System.NotImplementedException();
        }
    }
}
