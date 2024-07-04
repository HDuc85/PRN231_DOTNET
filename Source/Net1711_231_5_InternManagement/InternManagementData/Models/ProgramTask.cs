using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternManagementData.Models;

public partial class ProgramTask
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProgramTaskId { get; set; }

    public int? TaskId { get; set; }

    public int? ProgramId { get; set; }

    public bool? IsActive { get; set; }

    public virtual TrainingProgram? Program { get; set; }

    public virtual Task? Task { get; set; }
}
