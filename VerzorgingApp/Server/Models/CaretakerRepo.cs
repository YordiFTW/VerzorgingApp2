using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerzorgingApp.Server.Data;
using VerzorgingApp.Shared;


namespace VerzorgingApp.Server.Models
{
    public class CaretakerRepo : ICaretakerRepo
    {
        private readonly ApplicationDbContext _mBDbContext;

        public CaretakerRepo(ApplicationDbContext mBDbContext)
        {
            _mBDbContext = mBDbContext;
        }

        public Caretaker AddCaretaker(Caretaker elder)
        {
            var addCaretaker = _mBDbContext.Caretakers.Add(elder);
            _mBDbContext.SaveChanges();
            return addCaretaker.Entity;
        }

        public void DeleteCaretaker(int elderId)
        {
            var Caretaker = _mBDbContext.Caretakers.FirstOrDefault(e => e.Id == elderId);
            if (Caretaker == null) return;

            _mBDbContext.Caretakers.Remove(Caretaker);
            _mBDbContext.SaveChanges();
        }

        public IEnumerable<Caretaker> GetAllCaretakers()
        {
            return _mBDbContext.Caretakers;
        }

        public Caretaker GetCaretakerById(int elderId)
        {
            return _mBDbContext.Caretakers.FirstOrDefault(c => c.Id == elderId);
        }

        public Caretaker UpdateCaretaker(Caretaker elder)
        {
            var updateCaretaker = _mBDbContext.Caretakers.FirstOrDefault(e => e.Id == elder.Id);

            if (updateCaretaker != null)
            {
                updateCaretaker.FirstName = elder.FirstName;
                updateCaretaker.LastName = elder.LastName;
                updateCaretaker.DateofBirth = elder.DateofBirth;
                updateCaretaker.Elders = elder.Elders;


                _mBDbContext.SaveChanges();

                return updateCaretaker;
            }
            return null;
        }
    }
}
