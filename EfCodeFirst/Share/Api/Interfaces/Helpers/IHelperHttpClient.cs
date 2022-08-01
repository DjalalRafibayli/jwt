using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCodeFirst.Share.Api.Interfaces.Helpers
{
    public interface IHelperHttpClient
    {
        Task<string> GetResponse(string apiUrl,string accessToken,string refreshToken);
    }
}
