using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerzorgingApp.Shared;


namespace VerzorgingApp.Client.Services
{
    public interface ICaretakerDataService
    {
        Task<IEnumerable<Caretaker>> GetAllCaretakers();
        Task<Caretaker> GetCaretakerDetails(int elderId);
        Task<Caretaker> AddCaretaker(Caretaker elder);
        Task UpdateCaretaker(Caretaker elder);
        Task DeleteCaretaker(int elderId);
    }
}
