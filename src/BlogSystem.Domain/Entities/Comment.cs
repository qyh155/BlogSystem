using BlogSystem.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Domain.Entities
{
    public class Comment : AppEntity<int>
    {
        [Required]
        public string Content { get; set; } = default!;
        [MaxLength(50)]
        public string? AuthorName { get; set; } //游客名称
        public bool IsApproved { get; set; } = true; // 默认通过，被标记为垃圾时设为 false
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //外键
        public int ArticleId { get; set; }
        public Article? Article{ get; set; }

        public int? ParentId { get; set; }
        public Comment? Parent { get; set; }

        public ICollection<Comment> Replies { get; set; } = new List<Comment>();
        
    }
}
