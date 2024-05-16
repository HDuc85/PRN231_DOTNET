using System;
using System.Collections.Generic;

namespace InternManagementData.Models;

public partial class ProgramTask
{
    public int ProgramTaskId { get; set; }

    public int? TaskId { get; set; }

    public int? ProgramId { get; set; }

    public bool? IsActive { get; set; }

    public virtual TrainingProgram? Program { get; set; }

    public virtual Task? Task { get; set; }
}
