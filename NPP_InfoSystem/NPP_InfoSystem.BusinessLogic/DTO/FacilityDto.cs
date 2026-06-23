namespace NPP_InfoSystem.BusinessLogic.DTO
{
    public class FacilityDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public string StatusMessage { get; set; } = string.Empty; // Наприклад: "Працює" або "На ремонті"
    }
}