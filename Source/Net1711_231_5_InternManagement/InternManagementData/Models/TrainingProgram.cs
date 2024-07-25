using System;
using System.Collections.Generic;

namespace InternManagementData.Models;

public partial class TrainingProgram
{
    public int ProgramId { get; set; }

    public string? ProgramName { get; set; }

    public string? ProgramDecription { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual ICollection<ProgramIntern> ProgramInterns { get; set; } = new List<ProgramIntern>();

    public virtual ICollection<ProgramTask> ProgramTasks { get; set; } = new List<ProgramTask>();
}
