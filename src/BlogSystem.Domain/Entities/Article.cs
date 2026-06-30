using BlogSystem.Domain;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Domain.Entities
{
    public class Article : AppEntity<int>
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = default!;

        [Required]// 文章内容不应为空
        public string Content { get; set; } = default!; // Markdown 或 HTML
        [MaxLength(500)]
        public string? Summary { get; set; } // 摘要，自动生成或手动
        public string CoverImageUrl { get; set; } = default!;
        public int ViewCount { get; set; } = 0;
        public int LikeCount { get; set; } = 0;
        public bool IsPublished { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //外键
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        // 导航属性（外键关系在 Fluent API 中统一配置）
        public User User { get; set; } = default!;
        public Category Category { get; set; } = default!;

        public ICollection<Tag> Tags { get; set; } = new List<Tag>(); //文章的标签
        public ICollection<Comment> Comments { get; set; } = new List<Comment>(); //文章的评论

    }
}
