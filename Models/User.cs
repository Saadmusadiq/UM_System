using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UM_System.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required int RoleId { get; set; }
        public int ApplicationId { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; } = DateTime.Now;
    }
}
