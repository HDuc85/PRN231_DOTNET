using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternManagementData.Models;

public partial class MentorIntern
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MentorInternId { get; set; }

    public int? InternId { get; set; }

    public int? MentorId { get; set; }

    public bool? IsActive { get; set; }

    public virtual InternProfile? Intern { get; set; }

    public virtual MentorProfile? Mentor { get; set; }
}
