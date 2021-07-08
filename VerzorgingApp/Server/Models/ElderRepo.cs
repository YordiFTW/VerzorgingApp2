using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerzorgingApp.Server.Data;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Server.Models
{
    public class ElderRepo : IElderRepo
    {
        private readonly ApplicationDbContext _mBDbContext;

        public ElderRepo(ApplicationDbContext mBDbContext)
        {
            _mBDbContext = mBDbContext;
        }

        public Elder AddElder(Elder elder)
        {
            var addElder = _mBDbContext.Elders.Add(elder);
            _mBDbContext.SaveChanges();
            return addElder.Entity;
        }

        public void DeleteElder(int elderId)
        {
            var Elder = _mBDbContext.Elders.FirstOrDefault(e => e.Id == elderId);
            if (Elder == null) return;

            _mBDbContext.Elders.Remove(Elder);
            _mBDbContext.SaveChanges();
        }

        public IEnumerable<Elder> GetAllElders()
        {
            return _mBDbContext.Elders;
        }

        public Elder GetElderById(int elderId)
        {
            return _mBDbContext.Elders.FirstOrDefault(c => c.Id == elderId);
        }

        public Elder UpdateElder(Elder elder)
        {
            var updateElder = _mBDbContext.Elders.FirstOrDefault(e => e.Id == elder.Id);

            if (updateElder != null)
            {
                updateElder.FirstName = elder.FirstName;
                updateElder.LastName = elder.LastName;
                updateElder.DateofBirth = elder.DateofBirth;
                updateElder.CaretakerId = elder.CaretakerId;
                updateElder.Caretaker = elder.Caretaker;

                _mBDbContext.SaveChanges();

                return updateElder;
            }
            return null;
        }
    }
}

