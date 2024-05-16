using System;
using System.Collections.Generic;

namespace InternManagementData.Models;

public partial class TaskManage
{
    public int TaskManageId { get; set; }

    public int? TaskId { get; set; }

    public int? InternId { get; set; }

    public int? MentorId { get; set; }

    public int? StatusId { get; set; }

    public virtual InternProfile? Intern { get; set; }

    public virtual MentorProfile? Mentor { get; set; }

    public virtual Status? Status { get; set; }

    public virtual Task? Task { get; set; }
}
