using InternManagementData.Models;

namespace InternManagementData.DTO
{
    public class TaskDTO
    {
        public int TaskId { get; set; }

        public string? TaskName { get; set; }

        public string? TaskDescription { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? StatusId { get; set; }

        public ICollection<ProgramTask>? ProgramTasks;

        public Status? Status;

        public ICollection<TaskManage>? TaskManages;
    }
}