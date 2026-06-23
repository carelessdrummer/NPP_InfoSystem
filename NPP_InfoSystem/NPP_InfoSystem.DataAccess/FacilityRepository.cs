using NPP_InfoSystem.Domain;
using NPP_InfoSystem.Domain.Interfaces;
using System.Linq;

namespace NPP_InfoSystem.DataAccess
{
    public class FacilityRepository : IFacilityRepository
    {
        private readonly AppDbContext _context;

        public FacilityRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(NppFacility facility)
        {
            _context.Facilities.Add(facility);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var facility = _context.Facilities.Find(id);
            if (facility != null)
            {
                _context.Facilities.Remove(facility);
                _context.SaveChanges();
            }
        }

        public NppFacility? GetFacilityById(int id)
        {
            return _context.Facilities.Find(id);
        }

        public System.Collections.Generic.IEnumerable<NppFacility> GetAllFacilities()
        {
            return _context.Facilities.ToList();
        }
    }
}