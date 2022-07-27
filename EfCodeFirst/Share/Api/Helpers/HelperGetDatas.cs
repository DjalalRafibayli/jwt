using EfCodeFirst.Models.ApiResponse;
using EfCodeFirst.Models.ViewModels;
using EfCodeFirst.Share.Api.Interfaces.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EfCodeFirst.Share.Api.Helpers
{
    public class HelperGetDatas : IHelperGetDatas
    {
        private readonly IHelperLogin _helperLogin;

        public HelperGetDatas(IHelperLogin helperLogin)
        {
            _helperLogin = helperLogin;
        }

        public async Task<ResponseWithToken> GetDatas(string apiUrl, LoginViewModel m)
        {
            try
            {
                //var content = new StringContent(JsonConvert.SerializeObject(username, Formatting.Indented), Encoding.UTF8, "application/json");
                //var content = new StringContent(username);

                var uri = new Uri(apiUrl);
                string apiResponse = null;
                string newToken = null;
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(uri))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            newToken = await _helperLogin.LoginRepoAsync("https://localhost:5001/api/Login/authenticate", m);
                            if (string.IsNullOrEmpty(newToken))
                            {
                                apiResponse = null;
                            }
                            else
                            {
                                apiResponse = await response.Content.ReadAsStringAsync();
                            }
                        }
                        else
                        {
                            apiResponse = null;
                        }
                        ResponseWithToken responseWithToken = new ResponseWithToken() {
                            apiResponse = apiResponse,
                            newToken = newToken
                        };
                        return responseWithToken;
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
