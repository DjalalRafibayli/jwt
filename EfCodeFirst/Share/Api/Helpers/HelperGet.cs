using EfCodeFirst.Share.Api.Interfaces.Helpers;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirst.Share.Api.Helpers
{
    public class HelperGet : IHelperGet
    {
        public async Task<string> GetRepoBool(string apiUrl,string username)
        {
            try
            {
                //var content = new StringContent(JsonConvert.SerializeObject(username, Formatting.Indented), Encoding.UTF8, "application/json");
                var content = new StringContent(username);
                var uri = new Uri(apiUrl + "/" + username);
                string apiResponse = null;
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsync(uri, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            apiResponse = await response.Content.ReadAsStringAsync();
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
