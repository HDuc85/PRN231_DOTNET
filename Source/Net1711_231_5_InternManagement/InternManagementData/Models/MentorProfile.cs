using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternManagementData.Models;

public partial class MentorProfile
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MentorId { get; set; }

    public string? MentorName { get; set; }

    public string? MentorAddress { get; set; }

    public string? MentorPhone { get; set; }

    public string? MentorEmail { get; set; }
<<<<<<< HEAD
    public string? Password { get; set; }

    public virtual ICollection<InternProfile>? InternProfiles { get; set; } = new List<InternProfile>();

    public virtual ICollection<MentorIntern>? MentorInterns { get; set; } = new List<MentorIntern>();

    public virtual ICollection<TaskManage>? TaskManages { get; set; } = new List<TaskManage>();
=======

    public string? Password { get; set; }

    public virtual ICollection<InternProfile> InternProfiles { get; set; } = new List<InternProfile>();

    public virtual ICollection<MentorIntern> MentorInterns { get; set; } = new List<MentorIntern>();

    public virtual ICollection<TaskManage> TaskManages { get; set; } = new List<TaskManage>();
>>>>>>> 0f76685bb13278b4ca612a3b2abd16e6aca92ffa
}
