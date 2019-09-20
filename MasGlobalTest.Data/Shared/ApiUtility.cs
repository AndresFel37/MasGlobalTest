using System.Net.Http;
using System.Threading.Tasks;

namespace MasGlobalTest.Data.Shared
{
    public static class ApiUtility
    {
        public static async Task<string> GetApiResponse(string apiUrl)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
