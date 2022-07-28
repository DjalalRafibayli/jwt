using EfCodeFirst.Models.ApiResponse;
using EfCodeFirst.Share.Api.Interfaces.Helpers;
using EfCodeFirstAPI.JWT.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirst.Share.Api.Helpers
{
    public class HelperLogin : IHelperLogin
    {
        public async Task<ResponseTokens> LoginRepoAsync<T>(string apiUrl, T t)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(t, Formatting.Indented), Encoding.UTF8, "application/json");
                string apiResponse = null;
                var responseTokens = new ResponseTokens();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsync(apiUrl, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            apiResponse = await response.Content.ReadAsStringAsync();
                            responseTokens = JsonConvert.DeserializeObject<ResponseTokens>(apiResponse);
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
