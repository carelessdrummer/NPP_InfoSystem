namespace NPP_InfoSystem.Domain.Interfaces
{
    public interface IFacilityRepository
    {
        NppFacility? GetFacilityById(int id);
    }
}