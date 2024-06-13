using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternManagementData.DTO
{
    public class InternProfileDTO
    {
        public int InternID { get; set; }
        public string? InternName { get; set; }

        public string? InternAddress { get; set; }

        public string? InternEmail { get; set; }

        public string? InternPhone { get; set; }

        public string? University { get; set; }

        public string? Major { get; set; }

       
    }
}
