using System;
using System.Collections.Generic;

namespace InternManagementData.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string? StatusName { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TaskManage> TaskManages { get; set; } = new List<TaskManage>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
