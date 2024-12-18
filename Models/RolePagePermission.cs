using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UM_System.Models
{
    public class RolePagePermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PageId { get; set; }
        public bool CanView { get; set; }
        public DateTime? Created_at { get; set; } 
        public DateTime? Updated_at { get; set; } = DateTime.Now;

    }
}
