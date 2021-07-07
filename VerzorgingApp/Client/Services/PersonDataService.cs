using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using ZorgApp.Shared;

//namespace ZorgApp.Services
//{
//    public class PersonDataService<T> : IPersonDataService<T>
//    {
//        private readonly HttpClient _httpClient;

//        public PersonDataService(HttpClient httpClient)
//        {
//            _httpClient = httpClient;
//        }

//        public async Task<T> AddPerson(T person)
//        {
//            var personJson =
//                new StringContent(JsonSerializer.Serialize(person), Encoding.UTF8, "application/json");

//            var response = await _httpClient.PostAsync("api/person", personJson);

//            if (response.IsSuccessStatusCode)
//            {
//                return await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync());
//            }

//            return null;
//        }

//        public async Task DeletePerson(int personId)
//        {
//            await _httpClient.DeleteAsync($"api/person/{personId}");
//        }

//        public async Task<IEnumerable<T>> GetAllPersons()
//        {
//            return await JsonSerializer.DeserializeAsync<IEnumerable<T>>
//                  (await _httpClient.GetStreamAsync($"api/person"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
//        }

//        public async Task<Person> GetPersonDetails(int personId)
//        {
//            return await JsonSerializer.DeserializeAsync<Person>
//                (await _httpClient.GetStreamAsync($"api/person/{personId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
//        }

//        public async Task UpdatePerson(Person person)
//        {
//            var personJson =
//                 new StringContent(JsonSerializer.Serialize(person), Encoding.UTF8, "application/json");

//            await _httpClient.PutAsync("api/person", personJson);
//        }

//        public Task UpdatePerson(T person)
//        {
//            throw new NotImplementedException();
//        }

//        Task<T> IPersonDataService<T>.GetPersonDetails(int personId)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

