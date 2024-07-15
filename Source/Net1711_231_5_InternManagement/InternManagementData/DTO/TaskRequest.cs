namespace InternManagementData.DTO
{
    public class TaskRequest
    {
        public string? TaskName { get; set; }

        public string? TaskDecription { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? StatusId { get; set; }
    }
}