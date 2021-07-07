using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Server.Models
{
    public interface ISupervisorRepo
    {
        IEnumerable<Supervisor> GetAllSupervisors();
        Supervisor GetSupervisorById(int supervisorId);
        Supervisor AddSupervisor(Supervisor supervisor);
        Supervisor UpdateSupervisor(Supervisor supervisor);
        void DeleteSupervisor(int supervisorId);
    }
}
