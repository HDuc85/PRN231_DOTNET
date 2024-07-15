using System.ComponentModel.DataAnnotations.Schema;

namespace InternManagementData.Models;

public partial class Task
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TaskId { get; set; }

    public string? TaskName { get; set; }

    public string? TaskDescription { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<ProgramTask> ProgramTasks { get; set; } = new List<ProgramTask>();

    public virtual Status? Status { get; set; }

    public virtual ICollection<TaskManage> TaskManages { get; set; } = new List<TaskManage>();
}
