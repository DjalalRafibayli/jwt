using EfCodeFirst.Config.Encyript;
using EfCodeFirst.Models.ApiResponse;
using EfCodeFirst.Share.Api.Interfaces.Helpers;
using EfCodeFirst.Share.Logout;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirst.Share.Api.Helpers
{
    public class HelperHttpClient : IHelperHttpClient
    {
        private readonly IHelperRefreshToken _helperRefreshToken;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IConfiguration Configuration { get; }
        public HelperHttpClient(IHelperRefreshToken helperRefreshToken, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _helperRefreshToken = helperRefreshToken;
            _httpContextAccessor = httpContextAccessor;
            Configuration = configuration;
        }

        public async Task<string> GetResponse(string apiUrl, string accessToken, string refreshToken)
        {
            try
            {
                string apiResponse = null;

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
                                _httpContextAccessor.HttpContext.Response.Cookies.Delete("refreshToken");
                            }
                        }
                        else if (!string.IsNullOrEmpty(refreshToken))
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                var newTokens = await _helperRefreshToken.GetTokensOnlyRefresh(refreshToken);
                                if (newTokens.Token == null || newTokens.refreshToken == null)
                                {
                                    apiResponse = null;
                                }
                                using (var httpClientAgain = new HttpClient())
                                {
                                    httpClientAgain.BaseAddress = new Uri(Configuration["Api:ApiUrl"]);
                                    httpClientAgain.DefaultRequestHeaders.Accept.Add
                                        (new MediaTypeWithQualityHeaderValue("application/json"));
                                    httpClientAgain.DefaultRequestHeaders.Authorization =
                                        new AuthenticationHeaderValue("Bearer", newTokens.Token);
                                    using (var responseAgain = await httpClientAgain.GetAsync(apiUrl))
                                    {
                                        if (responseAgain.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                                        {
                                            _httpContextAccessor.HttpContext.Response.Cookies.Delete("refreshToken");
                                        }
                                        else
                                        {
                                            apiResponse = await responseAgain.Content.ReadAsStringAsync();
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {
                            _httpContextAccessor.HttpContext.Response.Cookies.Delete("refreshToken");
                            apiResponse = null;
                        }

                        return apiResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> GetResponse<T>(T t, string apiUrl, string accessToken, string refreshToken)
        {
            try
            {
                string apiResponse = null;
                var content = new StringContent(JsonConvert.SerializeObject(t, Formatting.Indented), Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(Configuration["Api:ApiUrl"]);
                    httpClient.DefaultRequestHeaders.Accept.Add
                        (new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", accessToken);
                    using (var response = await httpClient.PostAsync(apiUrl,content))
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
                                _httpContextAccessor.HttpContext.Response.Cookies.Delete("refreshToken");
                            }
                        }
                        else if (!string.IsNullOrEmpty(refreshToken))
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                var newTokens = await _helperRefreshToken.GetTokensOnlyRefresh(refreshToken);
                                if (newTokens.Token == null || newTokens.refreshToken == null)
                                {
                                    apiResponse = null;
                                }
                                using (var httpClientAgain = new HttpClient())
                                {
                                    httpClientAgain.BaseAddress = new Uri(Configuration["Api:ApiUrl"]);
                                    httpClientAgain.DefaultRequestHeaders.Accept.Add
                                        (new MediaTypeWithQualityHeaderValue("application/json"));
                                    httpClientAgain.DefaultRequestHeaders.Authorization =
                                        new AuthenticationHeaderValue("Bearer", newTokens.Token);
                                    using (var responseAgain = await httpClientAgain.PostAsync(apiUrl, content))
                                    {
                                        if (responseAgain.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                                        {
                                            _httpContextAccessor.HttpContext.Response.Cookies.Delete("refreshToken");
                                        }
                                        else
                                        {
                                            apiResponse = await responseAgain.Content.ReadAsStringAsync();
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {
                            _httpContextAccessor.HttpContext.Response.Cookies.Delete("refreshToken");
                            apiResponse = null;
                        }

                        return apiResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<string> DeleteResponse(string apiUrl, string accessToken, string refreshToken)
        {
            try
            {
                string apiResponse = null;

                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(Configuration["Api:ApiUrl"]);
                    httpClient.DefaultRequestHeaders.Accept.Add
                        (new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", accessToken);
                    using (var response = await httpClient.DeleteAsync(apiUrl))
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
                                _httpContextAccessor.HttpContext.Response.Cookies.Delete("refreshToken");
                            }
                        }
                        else if (!string.IsNullOrEmpty(refreshToken))
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                var newTokens = await _helperRefreshToken.GetTokensOnlyRefresh(refreshToken);
                                if (newTokens.Token == null || newTokens.refreshToken == null)
                                {
                                    apiResponse = null;
                                }
                                using (var httpClientAgain = new HttpClient())
                                {
                                    httpClientAgain.BaseAddress = new Uri(Configuration["Api:ApiUrl"]);
                                    httpClientAgain.DefaultRequestHeaders.Accept.Add
                                        (new MediaTypeWithQualityHeaderValue("application/json"));
                                    httpClientAgain.DefaultRequestHeaders.Authorization =
                                        new AuthenticationHeaderValue("Bearer", newTokens.Token);
                                    using (var responseAgain = await httpClientAgain.DeleteAsync(apiUrl))
                                    {
                                        if (responseAgain.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                                        {
                                            _httpContextAccessor.HttpContext.Response.Cookies.Delete("refreshToken");
                                        }
                                        else
                                        {
                                            apiResponse = await responseAgain.Content.ReadAsStringAsync();
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {
                            _httpContextAccessor.HttpContext.Response.Cookies.Delete("refreshToken");
                            apiResponse = null;
                        }

                        return apiResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
