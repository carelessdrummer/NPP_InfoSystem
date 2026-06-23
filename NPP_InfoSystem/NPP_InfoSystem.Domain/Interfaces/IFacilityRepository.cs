using System.Collections.Generic;

namespace NPP_InfoSystem.Domain.Interfaces
{
    public interface IFacilityRepository
    {
        NppFacility? GetFacilityById(int id);
        void Create(NppFacility facility);
        void Delete(int id);
        IEnumerable<NppFacility> GetAllFacilities(); // НОВИЙ РЯДОК
    }
}