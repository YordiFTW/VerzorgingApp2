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
    public class SupervisorDataService : ISupervisorDataService
    {
        private readonly HttpClient _httpClient;

        public SupervisorDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Supervisor> AddSupervisor(Supervisor supervisor)
        {
            var supervisorJson =
                new StringContent(JsonSerializer.Serialize(supervisor), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/supervisor", supervisorJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Supervisor>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteSupervisor(int supervisorId)
        {
            await _httpClient.DeleteAsync($"api/supervisor/{supervisorId}");
        }

        public async Task<IEnumerable<Supervisor>> GetAllSupervisors()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Supervisor>>
                  (await _httpClient.GetStreamAsync($"api/supervisor"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Supervisor> GetSupervisorDetails(int supervisorId)
        {
            return await JsonSerializer.DeserializeAsync<Supervisor>
                (await _httpClient.GetStreamAsync($"api/supervisor/{supervisorId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateSupervisor(Supervisor supervisor)
        {
            var supervisorJson =
                 new StringContent(JsonSerializer.Serialize(supervisor), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/supervisor", supervisorJson);
        }
    }
}

