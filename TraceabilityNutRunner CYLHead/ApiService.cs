using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TraceabilityNutRunner_CYLHead.Models;

namespace TraceabilityNutRunner_CYLHead
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Method to fetch data from the API
        public async Task<List<TighteningResult>> GetTighteningResultsAsync()
        {
            try
            {
                // Replace with your actual API endpoint
                var response = await _httpClient.GetAsync("https://your-api-endpoint.com/api/tighteningresults");

                if (response.IsSuccessStatusCode)
                {
                    // Parse the response content as a list of TighteningResult objects
                    return await response.Content.ReadFromJsonAsync<List<TighteningResult>>();
                }
                else
                {
                    // Handle error (you can log it or return an empty list)
                    Console.WriteLine("Error: Failed to fetch data");
                    return new List<TighteningResult>();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., network issues)
                Console.WriteLine($"Error: {ex.Message}");
                return new List<TighteningResult>();
            }
        }
    }
}
