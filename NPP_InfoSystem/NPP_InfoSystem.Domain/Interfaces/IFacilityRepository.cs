namespace NPP_InfoSystem.Domain.Interfaces
{
    public interface IFacilityRepository
    {
        NppFacility? GetFacilityById(int id);
        void Create(NppFacility facility); // Додали метод створення
        void Delete(int id);               // Додали метод видалення
    }
}