using System;
using System.Collections.Generic;

namespace InternManagementData.Models;

public partial class MentorProfile
{
    public int MentorId { get; set; }

    public string? MentorName { get; set; }

    public string? MentorAddress { get; set; }

    public string? MentorPhone { get; set; }

    public string? MentorEmail { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<InternProfile> InternProfiles { get; set; } = new List<InternProfile>();

    public virtual ICollection<MentorIntern> MentorInterns { get; set; } = new List<MentorIntern>();

    public virtual ICollection<TaskManage> TaskManages { get; set; } = new List<TaskManage>();
}
