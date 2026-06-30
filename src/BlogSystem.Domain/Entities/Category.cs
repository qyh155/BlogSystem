using System.ComponentModel.DataAnnotations;
using BlogSystem.Domain;

namespace BlogSystem.Domain.Entities
{
    public class Category : AppEntity<int>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = default!;
        [MaxLength(500)]
        public string? Description { get; set; }
        public int DisplayOrder { get; set; }

        //种类下的文章
        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
