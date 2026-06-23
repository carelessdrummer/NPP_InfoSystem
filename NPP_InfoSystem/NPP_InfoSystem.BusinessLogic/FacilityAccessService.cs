using NPP_InfoSystem.BusinessLogic.DTO;
using NPP_InfoSystem.CCL.Security;
using NPP_InfoSystem.Domain;
using NPP_InfoSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NPP_InfoSystem.BusinessLogic
{
    public class FacilityAccessService
    {
        private readonly IFacilityRepository _facilityRepository;

        public FacilityAccessService(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository ?? throw new ArgumentNullException(nameof(facilityRepository));
        }

        public bool InspectAccessPermission(int facilityId, int employeeClearance)
        {
            var facility = _facilityRepository.GetFacilityById(facilityId);
            if (facility == null) return false;
            if (facility.IsUnderMaintenance) return false;
            return employeeClearance >= facility.RequiredClearanceLevel;
        }

        // НОВИЙ МЕТОД ДЛЯ ПРАКТИКУМУ №9
        public IEnumerable<FacilityDto> GetFacilitiesCatalog()
        {
            // Перевірка наскрізної функціональності (чи це Адмін)
            var user = SecurityContext.GetUser();
            if (user == null || user.UserType != "Admin")
            {
                throw new UnauthorizedAccessException("Тільки адміністратор може переглядати повний каталог.");
            }

            var facilities = _facilityRepository.GetAllFacilities();

            // Перетворення (Mapping) сутностей предметної області у DTO
            return facilities.Select(f => new FacilityDto
            {
                Id = f.Id,
                DisplayName = f.Name,
                StatusMessage = f.IsUnderMaintenance ? "На ремонті" : "Працює"
            }).ToList();
        }
    }
}