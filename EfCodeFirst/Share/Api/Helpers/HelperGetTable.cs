using EfCodeFirst.Config.Encyript;
using EfCodeFirst.Models.ApiResponse;
using EfCodeFirst.Share.Api.Interfaces.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EfCodeFirst.Share.Api.Helpers
{
    public class HelperGetTable : IHelperGetTable
    {
        private readonly IHelperRefreshToken _helperRefreshToken;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEncyript _encyript;
        public IConfiguration Configuration { get; }

        public HelperGetTable(IHelperRefreshToken helperRefreshToken, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IEncyript encyript)
        {
            _helperRefreshToken = helperRefreshToken;
            _httpContextAccessor = httpContextAccessor;
            Configuration = configuration;
            _encyript = encyript;
        }

        public async Task<string> GetTable(string apiUrl)
        {
            try
            {
                //var content = new StringContent(JsonConvert.SerializeObject(username, Formatting.Indented), Encoding.UTF8, "application/json");
                //var content = new StringContent(username);
                string apiResponse = null;
                string newToken = null;
                var accessToken = _httpContextAccessor.HttpContext.Request.Cookies["accessToken"];
                accessToken = _encyript.Decrypt(accessToken, Configuration["Keys:JwtEnckey"]);

                var refreshToken = _encyript.Decrypt(_httpContextAccessor.HttpContext.Request.Cookies["refreshToken"], Configuration["Keys:JwtEnckey"]);

                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(Configuration["Api:ApiUrl"]);
                    httpClient.DefaultRequestHeaders.Accept.Add
                        (new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", accessToken);
                    using (var response = await httpClient.GetAsync(apiUrl))
                    {

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {

                            apiResponse = await response.Content.ReadAsStringAsync();

                            if (accessToken == null || refreshToken == null)
                                return null;
                            RequestTokens requestTokens = new RequestTokens()
                            {
                                refreshToken = refreshToken,
                                Token = accessToken
                            };
                            var newTokens = await _helperRefreshToken.GetTokens(requestTokens);
                            if (newTokens.Token == null || newTokens.refreshToken == null)
                            {
                                apiResponse = null;
                            }
                        }
                        else if (!string.IsNullOrEmpty(refreshToken))
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                refreshToken = _encyript.Decrypt(_httpContextAccessor.HttpContext.Request.Cookies["refreshToken"], Configuration["Keys:JwtEnckey"]);
                                if (accessToken == null || refreshToken == null)
                                    return null;
                                RequestTokens requestTokens = new RequestTokens()
                                {
                                    refreshToken = refreshToken,
                                    Token = accessToken
                                };
                                var newTokens = await _helperRefreshToken.GetTokens(requestTokens);
                                if (newTokens.Token == null || newTokens.refreshToken == null)
                                {
                                    apiResponse = null;
                                }
                            }
                        }
                        else
                        {
                            apiResponse = null;
                        }

                        return apiResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                //return string.Format("alinmadi {0}", ex.Message);
                return null;
            }
        }
    }
}
