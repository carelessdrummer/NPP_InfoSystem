namespace NPP_InfoSystem.Domain
{
    public class NppFacility
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int RequiredClearanceLevel { get; set; }
        public bool IsUnderMaintenance { get; set; }

        public NppFacility(int id, string name, int clearanceLevel)
        {
            Id = id;
            Name = name;
            RequiredClearanceLevel = clearanceLevel;
            IsUnderMaintenance = false;
        }
    }
}