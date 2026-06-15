using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.src.Domain.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        public int DispalyOrder { get; set; }

        //种类下的文章
        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
