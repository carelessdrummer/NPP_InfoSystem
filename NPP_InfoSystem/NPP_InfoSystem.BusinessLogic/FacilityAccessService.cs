using NPP_InfoSystem.Domain;
using NPP_InfoSystem.Domain.Interfaces;
using System;

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

            if (facility == null)
                return false;

            if (facility.IsUnderMaintenance)
                return false;

            return employeeClearance >= facility.RequiredClearanceLevel;
        }
    }
}