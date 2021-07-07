using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Server.Models
{
    public interface IElderRepo
    {
        IEnumerable<Elder> GetAllElders();
        Elder GetElderById(int elderId);
        Elder AddElder(Elder elder);
        Elder UpdateElder(Elder elder);
        void DeleteElder(int elderId);
    }
}
