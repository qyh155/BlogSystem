using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.src.Domain.Entities
{
    [Index(nameof(UserName), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;
        [MaxLength(255)]
        public string PasswordHash { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }

        public ICollection<Article> Articles { get; set; } = new List<Article>(); //用户的文章
        public ICollection<Comment> Comments { get; set; } = new List<Comment>(); //用户的评论
    }
}
