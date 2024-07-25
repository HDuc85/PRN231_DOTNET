using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternManagementData.DTO
{
    public class FileDTO
    {
        public string Name { get; set; }
        public string MediaLink { get; set; }
        public string SelfLink { get; set; }
        public string PublicLink { get; set; }
        public ulong Size { get; set; }
        public IDictionary<string, string> Metadata { get; set; }
        public string ContentType { get; set; }
        public MemoryStream memoryStream { get; set; }
    }
}
