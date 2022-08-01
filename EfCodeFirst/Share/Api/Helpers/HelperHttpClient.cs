using EfCodeFirst.Config.Encyript;
using EfCodeFirst.Models.ApiResponse;
using EfCodeFirst.Share.Api.Interfaces.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
                                apiResponse = null;
                            }
                        }
                        else if (!string.IsNullOrEmpty(refreshToken))
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
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
                throw;
            }
        }
    }
}
