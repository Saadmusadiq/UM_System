using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UM_System.Models
{
    public class Page
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public DateTime? Created_at { get; set; } 
        public DateTime? Updated_at { get; set; } = DateTime.Now;

    }
}
