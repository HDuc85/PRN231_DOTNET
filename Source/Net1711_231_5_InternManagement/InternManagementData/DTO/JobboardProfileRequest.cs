namespace InternManagementData.DTO
{
    public class JobboardProfileRequest
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public string YearOfBirth { get; set; }
        public string Position { get; set; }
    }
}
