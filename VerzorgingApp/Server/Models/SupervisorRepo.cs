using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerzorgingApp.Server.Data;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Server.Models
{
    public class SupervisorRepo : ISupervisorRepo
    {
        private readonly ApplicationDbContext _mBDbContext;

        public SupervisorRepo(ApplicationDbContext mBDbContext)
        {
            _mBDbContext = mBDbContext;
        }

        public Supervisor AddSupervisor(Supervisor elder)
        {
            var addSupervisor = _mBDbContext.Supervisors.Add(elder);
            _mBDbContext.SaveChanges();
            return addSupervisor.Entity;
        }

        public void DeleteSupervisor(int elderId)
        {
            var Supervisor = _mBDbContext.Supervisors.FirstOrDefault(e => e.Id == elderId);
            if (Supervisor == null) return;

            _mBDbContext.Supervisors.Remove(Supervisor);
            _mBDbContext.SaveChanges();
        }

        public IEnumerable<Supervisor> GetAllSupervisors()
        {
            return _mBDbContext.Supervisors;
        }

        public Supervisor GetSupervisorById(int elderId)
        {
            return _mBDbContext.Supervisors.FirstOrDefault(c => c.Id == elderId);
        }

        public Supervisor UpdateSupervisor(Supervisor elder)
        {
            var updateSupervisor = _mBDbContext.Supervisors.FirstOrDefault(e => e.Id == elder.Id);

            if (updateSupervisor != null)
            {
                updateSupervisor.FirstName = elder.FirstName;
                updateSupervisor.LastName = elder.LastName;
                updateSupervisor.DateofBirth = elder.DateofBirth;
                //updateSupervisor.CaretakerId = elder.CaretakerId;
                //updateSupervisor.Caretaker = elder.Caretaker;

                _mBDbContext.SaveChanges();

                return updateSupervisor;
            }
            return null;
        }
    }
}
