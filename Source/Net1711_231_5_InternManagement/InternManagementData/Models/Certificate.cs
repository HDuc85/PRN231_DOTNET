using System.ComponentModel.DataAnnotations.Schema;

namespace InternManagementData.Models
{
    public partial class Certificate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime CompletedDate { get; set; }
    }
}
