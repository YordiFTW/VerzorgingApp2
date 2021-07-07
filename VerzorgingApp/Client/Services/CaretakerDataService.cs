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
    public class CaretakerDataService : ICaretakerDataService
    {
        private readonly HttpClient _httpClient;

        public CaretakerDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Caretaker> AddCaretaker(Caretaker caretaker)
        {
            var caretakerJson =
                new StringContent(JsonSerializer.Serialize(caretaker), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/caretaker", caretakerJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Caretaker>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteCaretaker(int caretakerId)
        {
            await _httpClient.DeleteAsync($"api/caretaker/{caretakerId}");
        }

        public async Task<IEnumerable<Caretaker>> GetAllCaretakers()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Caretaker>>
                  (await _httpClient.GetStreamAsync($"api/caretaker"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Caretaker> GetCaretakerDetails(int caretakerId)
        {
            return await JsonSerializer.DeserializeAsync<Caretaker>
                (await _httpClient.GetStreamAsync($"api/caretaker/{caretakerId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateCaretaker(Caretaker caretaker)
        {
            var caretakerJson =
                 new StringContent(JsonSerializer.Serialize(caretaker), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/caretaker", caretakerJson);
        }
    }
}

