using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.src.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? AuthorName { get; set; } //游客名称
        public bool IsApproved { get; set; } = true; // 默认通过，被标记为垃圾时设为 false
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int ArticleId { get; set; }
        //外键
        [ForeignKey(nameof(ArticleId))]
        public Article? Article{ get; set; }

        public int? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public Comment? Parent { get; set; }

        public ICollection<Comment> Replies { get; set; } = new List<Comment>();
        
    }
}
