using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.src.Domain.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
