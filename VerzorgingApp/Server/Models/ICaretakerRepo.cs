using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Server.Models
{
    public interface ICaretakerRepo
    {
        IEnumerable<Caretaker> GetAllCaretakers();
        Caretaker GetCaretakerById(int elderId);
        Caretaker AddCaretaker(Caretaker elder);
        Caretaker UpdateCaretaker(Caretaker elder);
        void DeleteCaretaker(int elderId);
    }
}
