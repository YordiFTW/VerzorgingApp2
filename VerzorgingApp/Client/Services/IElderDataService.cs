using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerzorgingApp.Shared;


namespace VerzorgingApp.Client.Services
{
    public interface IElderDataService
    {
        Task<IEnumerable<Elder>> GetAllElders();
        Task<Elder> GetElderDetails(int elderId);
        Task<Elder> AddElder(Elder elder);
        Task UpdateElder(Elder elder);
        Task DeleteElder(int elderId);

    }
}