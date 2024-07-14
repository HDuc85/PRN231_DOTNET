using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternManagementData.Models
{
    public partial class JobboardProfile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public string YearOfBirth { get; set; }
        public string Position { get; set; }
    }
}
