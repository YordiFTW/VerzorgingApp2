using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Client.Services
{
    public interface ISupervisorDataService
    {
        Task<IEnumerable<Supervisor>> GetAllSupervisors();
        Task<Supervisor> GetSupervisorDetails(int supervisorId);
        Task<Supervisor> AddSupervisor(Supervisor supervisor);
        Task UpdateSupervisor(Supervisor supervisor);
        Task DeleteSupervisor(int supervisorId);
    }
}
