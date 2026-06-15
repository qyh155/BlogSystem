
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace BlogSystem.src.Domain.Entities
{
    public class Article
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty; // Markdown 或 HTML
        [MaxLength(500)]
        public string? Summary { get; set; } // 摘要，自动生成或手动
        public string CoverImageUrl { get; set; } = string.Empty;
        public int ViewCount { get; set; } = 0;
        public int LikeCount { get; set; } = 0;
        public bool Ispublished { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int UserId { get; set; }
        //外键
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        //导航
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public ICollection<Tag> Tags { get; set; } = new List<Tag>(); //文章的标签
        public ICollection<Comment> Comments { get; set; } = new List<Comment>(); //文章的评论

    }
}
