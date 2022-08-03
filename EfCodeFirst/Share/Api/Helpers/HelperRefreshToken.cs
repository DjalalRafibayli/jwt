using EfCodeFirst.Config.Encyript;
using EfCodeFirst.Models.ApiResponse;
using EfCodeFirst.Share.Api.Interfaces.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirst.Share.Api.Helpers
{
    public class HelperRefreshToken : IHelperRefreshToken
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEncyript _encyript;
        public IConfiguration Configuration { get; }

        public HelperRefreshToken(IHttpContextAccessor httpContextAccessor, IEncyript encyript, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _encyript = encyript;
            Configuration = configuration;
        }

        public async Task<ResponseTokens> GetTokens(RequestTokens p)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(p, Formatting.Indented), Encoding.UTF8, "application/json");
                //var content = new StringContent(username);

                string apiResponse = null;
                var responseTokens = new ResponseTokens();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsync("https://localhost:5001/api/Login/Refresh", content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            apiResponse = await response.Content.ReadAsStringAsync();
                            responseTokens = JsonConvert.DeserializeObject<ResponseTokens>(apiResponse);


                            CookieOptions cookieOptions = new CookieOptions();
                            cookieOptions.Expires = DateTime.Now.AddHours(0.5);
                            var encyriptToken = _encyript.Encrypt(responseTokens.Token, Configuration["Keys:JwtEnckey"]);
                            var encyriptrefreshToken = _encyript.Encrypt(responseTokens.refreshToken, Configuration["Keys:JwtEnckey"]);
                            _httpContextAccessor.HttpContext.Response.Cookies.Append("accessToken", encyriptToken, cookieOptions);
                            _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", encyriptrefreshToken, cookieOptions);

                        }
                        return responseTokens;
                    }
                }
            }
            catch (Exception ex)
            {
                //return string.Format("alinmadi {0}", ex.Message);
                return null;
            }
        }

        public async Task<ResponseTokens> GetTokensOnlyRefresh(string refreshToken)
        {
            try
            {
                //var content = new StringContent(JsonConvert.SerializeObject(refreshToken, Formatting.Indented), Encoding.UTF8, "application/json");
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("refreshToken", refreshToken),
                });
                string apiResponse = null;
                var responseTokens = new ResponseTokens();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsync("https://localhost:5001/api/Login/RefreshToken", content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            apiResponse = await response.Content.ReadAsStringAsync();
                            responseTokens = JsonConvert.DeserializeObject<ResponseTokens>(apiResponse);


                            CookieOptions cookieOptions = new CookieOptions();
                            cookieOptions.Expires = DateTime.Now.AddHours(0.5);
                            var encyriptToken = _encyript.Encrypt(responseTokens.Token, Configuration["Keys:JwtEnckey"]);
                            var encyriptrefreshToken = _encyript.Encrypt(responseTokens.refreshToken, Configuration["Keys:JwtEnckey"]);
                            _httpContextAccessor.HttpContext.Response.Cookies.Append("accessToken", encyriptToken, cookieOptions);
                            _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", encyriptrefreshToken, cookieOptions);

                        }
                        else
                        {
                            apiResponse = null;
                        }
                        return responseTokens;
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
