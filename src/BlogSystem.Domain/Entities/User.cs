using BlogSystem.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Domain.Entities
{
    public class User : AppEntity<int>
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } = default!;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = default!;
        [MaxLength(255)]
        public string? PasswordHash { get; set; }
        
        [MaxLength(500)]
        public string? AvatarUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }

        public ICollection<Article> Articles { get; set; } = new List<Article>(); //用户的文章
        public ICollection<Comment> Comments { get; set; } = new List<Comment>(); //用户的评论
    }
}
