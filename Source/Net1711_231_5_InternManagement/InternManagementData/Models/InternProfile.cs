using System;
using System.Collections.Generic;

namespace InternManagementData.Models;

public partial class InternProfile
{
    public int InternId { get; set; }

    public string? InternName { get; set; }

    public string? InternAddress { get; set; }

    public string? InternEmail { get; set; }

    public string? InternPhone { get; set; }

    public string? University { get; set; }

    public string? Major { get; set; }

    public int? MentorId { get; set; }

    public virtual MentorProfile? Mentor { get; set; }

    public virtual ICollection<MentorIntern> MentorInterns { get; set; } = new List<MentorIntern>();

    public virtual ICollection<ProgramIntern> ProgramInterns { get; set; } = new List<ProgramIntern>();

    public virtual ICollection<TaskManage> TaskManages { get; set; } = new List<TaskManage>();
}
