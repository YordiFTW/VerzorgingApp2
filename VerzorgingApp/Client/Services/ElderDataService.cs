using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VerzorgingApp.Shared;


namespace VerzorgingApp.Client.Services
{
    public class ElderDataService : IElderDataService
    {
        private readonly HttpClient _httpClient;

        public ElderDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Elder> AddElder(Elder elder)
        {
            var elderJson =
                new StringContent(JsonSerializer.Serialize(elder), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/elder", elderJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Elder>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteElder(int elderId)
        {
            await _httpClient.DeleteAsync($"api/elder/{elderId}");
        }

        public async Task<IEnumerable<Elder>> GetAllElders()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Elder>>
                  (await _httpClient.GetStreamAsync($"api/elder"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Elder> GetElderDetails(int elderId)
        {
            return await JsonSerializer.DeserializeAsync<Elder>
                (await _httpClient.GetStreamAsync($"api/elder/{elderId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateElder(Elder elder)
        {
            var elderJson =
                 new StringContent(JsonSerializer.Serialize(elder), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/elder", elderJson);
        }
    }
}
