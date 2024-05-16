using System;
using System.Collections.Generic;

namespace InternManagementData.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? EmployeeAddress { get; set; }

    public string? EmployeePhone { get; set; }

    public string? EmployeeEmail { get; set; }

    public int? CompanyId { get; set; }

    public virtual Company? Company { get; set; }
}
