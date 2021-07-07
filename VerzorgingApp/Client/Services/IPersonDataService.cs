using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace VerzorgingApp.Client.Services
{
   public interface IPersonDataService<T>
    {
        Task<IEnumerable<T>> GetAllPersons();
        Task<T> GetPersonDetails(int personId);
        Task<T> AddPerson(T person);
        Task UpdatePerson(T person);
        Task DeletePerson(int personId);
    }
}
