using System;
using System.Collections.Generic;

namespace InternManagementData.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string? TaskName { get; set; }

    public string? TaskDecription { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? Priority { get; set; }
    public string? TaskCategory { get; set; }
    public string? Comments { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? LastUpdated { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<ProgramTask> ProgramTasks { get; set; } = new List<ProgramTask>();

    public virtual Status? Status { get; set; }

    public virtual ICollection<TaskManage> TaskManages { get; set; } = new List<TaskManage>();
}
