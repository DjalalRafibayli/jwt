using EfCodeFirst.Config.Encyript;
using EfCodeFirst.Models.ApiResponse;
using EfCodeFirst.Share.Api.Interfaces.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirst.Share.Api.Helpers
{
    public class HelperGetTable : IHelperGetTable
    {
        private readonly IHelperRefreshToken _helperRefreshToken;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEncyript _encyript;
        private readonly IHelperHttpClient _helperHttpClient;
        public IConfiguration Configuration { get; }

        public HelperGetTable(IHelperRefreshToken helperRefreshToken, IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration, IEncyript encyript, IHelperHttpClient helperHttpClient)
        {
            _helperRefreshToken = helperRefreshToken;
            _httpContextAccessor = httpContextAccessor;
            Configuration = configuration;
            _encyript = encyript;
            _helperHttpClient = helperHttpClient;
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


                return apiResponse = await _helperHttpClient.GetResponse(apiUrl, accessToken, refreshToken);

                #region comment
                //using (var httpClient = new HttpClient())
                //{
                //    httpClient.BaseAddress = new Uri(Configuration["Api:ApiUrl"]);
                //    httpClient.DefaultRequestHeaders.Accept.Add
                //        (new MediaTypeWithQualityHeaderValue("application/json"));
                //    httpClient.DefaultRequestHeaders.Authorization =
                //        new AuthenticationHeaderValue("Bearer", accessToken);
                //    using (var response = await httpClient.GetAsync(apiUrl))
                //    {

                //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                //        {

                //            apiResponse = await response.Content.ReadAsStringAsync();

                //            if (accessToken == null || refreshToken == null)
                //                return null;
                //            RequestTokens requestTokens = new RequestTokens()
                //            {
                //                refreshToken = refreshToken,
                //                Token = accessToken
                //            };
                //            var newTokens = await _helperRefreshToken.GetTokens(requestTokens);
                //            if (newTokens.Token == null || newTokens.refreshToken == null)
                //            {
                //                apiResponse = null;
                //            }
                //        }
                //        else if (!string.IsNullOrEmpty(refreshToken))
                //        {
                //            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                //            {
                //                refreshToken = _encyript.Decrypt(_httpContextAccessor.HttpContext.Request.Cookies["refreshToken"], Configuration["Keys:JwtEnckey"]);
                //                if (accessToken == null || refreshToken == null)
                //                    return null;
                //                RequestTokens requestTokens = new RequestTokens()
                //                {
                //                    refreshToken = refreshToken,
                //                    Token = accessToken
                //                };
                //                var newTokens = await _helperRefreshToken.GetTokens(requestTokens);
                //                if (newTokens.Token == null || newTokens.refreshToken == null)
                //                {
                //                    apiResponse = null;
                //                }
                //            }
                //        }
                //        else
                //        {
                //            apiResponse = null;
                //        }

                //        return apiResponse;
                //    }
                //}
                #endregion
            }
            catch (Exception ex)
            {
                //return string.Format("alinmadi {0}", ex.Message);
                return null;
            }
        }
        public async Task<string> GetTable<T>(string apiUrl,T t)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(t, Formatting.Indented), Encoding.UTF8, "application/json");
                //var content = new StringContent(username);
                string apiResponse = null;
                string newToken = null;
                var accessToken = _httpContextAccessor.HttpContext.Request.Cookies["accessToken"];
                accessToken = _encyript.Decrypt(accessToken, Configuration["Keys:JwtEnckey"]);

                var refreshToken = _encyript.Decrypt(_httpContextAccessor.HttpContext.Request.Cookies["refreshToken"], Configuration["Keys:JwtEnckey"]);


                return apiResponse = await _helperHttpClient.GetResponse(apiUrl, accessToken, refreshToken);

                #region comment
                //using (var httpClient = new HttpClient())
                //{
                //    httpClient.BaseAddress = new Uri(Configuration["Api:ApiUrl"]);
                //    httpClient.DefaultRequestHeaders.Accept.Add
                //        (new MediaTypeWithQualityHeaderValue("application/json"));
                //    httpClient.DefaultRequestHeaders.Authorization =
                //        new AuthenticationHeaderValue("Bearer", accessToken);
                //    using (var response = await httpClient.GetAsync(apiUrl))
                //    {

                //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                //        {

                //            apiResponse = await response.Content.ReadAsStringAsync();

                //            if (accessToken == null || refreshToken == null)
                //                return null;
                //            RequestTokens requestTokens = new RequestTokens()
                //            {
                //                refreshToken = refreshToken,
                //                Token = accessToken
                //            };
                //            var newTokens = await _helperRefreshToken.GetTokens(requestTokens);
                //            if (newTokens.Token == null || newTokens.refreshToken == null)
                //            {
                //                apiResponse = null;
                //            }
                //        }
                //        else if (!string.IsNullOrEmpty(refreshToken))
                //        {
                //            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                //            {
                //                refreshToken = _encyript.Decrypt(_httpContextAccessor.HttpContext.Request.Cookies["refreshToken"], Configuration["Keys:JwtEnckey"]);
                //                if (accessToken == null || refreshToken == null)
                //                    return null;
                //                RequestTokens requestTokens = new RequestTokens()
                //                {
                //                    refreshToken = refreshToken,
                //                    Token = accessToken
                //                };
                //                var newTokens = await _helperRefreshToken.GetTokens(requestTokens);
                //                if (newTokens.Token == null || newTokens.refreshToken == null)
                //                {
                //                    apiResponse = null;
                //                }
                //            }
                //        }
                //        else
                //        {
                //            apiResponse = null;
                //        }

                //        return apiResponse;
                //    }
                //}
                #endregion
            }
            catch (Exception ex)
            {
                //return string.Format("alinmadi {0}", ex.Message);
                return null;
            }
        }
    }
}
