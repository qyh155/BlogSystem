using BlogSystem.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Domain.Entities
{
    public class Tag : AppEntity<int>
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = default!;

        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
