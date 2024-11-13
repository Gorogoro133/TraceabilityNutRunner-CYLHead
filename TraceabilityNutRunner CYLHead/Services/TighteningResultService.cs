// File: Services/TighteningResultService.cs
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TraceabilityNutRunner_CYLHead.Models;

namespace TraceabilityNutRunner_CYLHead.Services
{
    public class TighteningResultService
    {
        private readonly HttpClient _httpClient;
        private readonly string apiUrl = "http://localhost:5032/api/tighteningresult"; // Replace with your API URL

        public TighteningResultService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> SendTighteningResultAsync(TighteningResult tighteningResult)
        {
            try
            {
                string jsonContent = JsonSerializer.Serialize(tighteningResult);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending data: {ex.Message}");
                return false;
            }
        }
    }
}
