using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UM_System.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required int ApplicationId { get; set; }

        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime? Created_at { get; set; } 
        public DateTime? Updated_at { get; set; } = DateTime.Now;

    }
}
