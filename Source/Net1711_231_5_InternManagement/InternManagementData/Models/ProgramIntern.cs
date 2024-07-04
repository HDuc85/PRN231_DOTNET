using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternManagementData.Models;

public partial class ProgramIntern
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProgramInternId { get; set; }

    public int? InternId { get; set; }

    public int? ProgramId { get; set; }

    public bool? IsActive { get; set; }

    public virtual InternProfile? Intern { get; set; }

    public virtual TrainingProgram? Program { get; set; }
}
