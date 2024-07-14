using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternManagementData.DTO
{
    public class TaskSearchRequest
    {
        public string? TaskName { get; set; }

        public string? TaskDecription { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? Priority { get; set; }
        public string? TaskCategory { get; set; }
        public string? Comments { get; set; }
      
    }
}
