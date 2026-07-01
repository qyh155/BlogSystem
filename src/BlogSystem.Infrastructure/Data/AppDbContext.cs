using Microsoft.EntityFrameworkCore;
using BlogSystem.Domain.Entities;

namespace BlogSystem.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //-------------------User------------------------
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.AvatarUrl)
                    .HasDefaultValue("/Avatar/default.png");

                entity.Property(u => u.CreatedAt)
                    .HasDefaultValueSql("now() at time zone 'utc'");

                entity.HasIndex(u => u.UserName).IsUnique();
                entity.HasIndex(u => u.Email).IsUnique();
                //每个User的用户名和邮箱肯定是不同的
            });
            //-------------------Article------------------------
            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(a => a.CreatedAt)
                    .HasDefaultValueSql("now() at time zone 'utc'");
                // UpdatedAt 由业务代码赋值，不设数据库默认值

                entity.HasOne(a => a.User)
                    .WithMany(u => u.Articles)
                    .HasForeignKey(a => a.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasQueryFilter(a => !a.IsDeleted);
            });
            //-------------------Comment------------------------
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(c => c.Article)
                    .WithMany(a => a.Comments)
                    .HasForeignKey(c => c.ArticleId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(c => c.Parent)
                    .WithMany(c => c.Replies)
                    .HasForeignKey(c => c.ParentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            //-------------------Category------------------------
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasMany(c => c.Articles)
                    .WithOne(a => a.Category)
                    .HasForeignKey(a => a.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(c => c.Name).IsUnique();
            });
            //-------------------Tag------------------------
            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasMany(t => t.Articles)
                    .WithMany(a => a.Tags)
                    .UsingEntity(j => j.ToTable("ArticleTags"));

                entity.HasIndex(t => t.Name).IsUnique();
            });

            //==================== 新加的种子数据 ====================
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "admin",
                Email = "admin@Blog.com",
                PasswordHash = "留空",
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            });

            modelBuilder.Entity<Article>().HasData(new Article
            {
                Id = 1,
                Title = "欢迎来到我的博客",
                Content = "这是我的第一篇文章，欢迎大家阅读！",
                Summary = "开篇",
                IsPublished = true,
                UserId = 1,
                CategoryId = 1,
                CoverImageUrl = "https://picsum.photos/800/400",
                CreatedAt = new DateTime(2026, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2026, 1, 1, 12, 1, 1, 1, DateTimeKind.Utc),
                ViewCount = 50,
                LikeCount = 5
            });

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "技术" },
                new Category { Id = 2, Name = "生活" }
                );

            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "技术" },
                new Tag { Id = 2, Name = "生活" },
                new Tag { Id = 3, Name = "工作" }
                );

            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    ArticleId = 1,
                    Content = "文章写的很好",
                    AuthorName = "张三",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 1, 1, 12, 2, 2, DateTimeKind.Utc),
                },
                new Comment
                {
                    Id = 2,
                    ArticleId = 1,
                    Content = "期待下一篇分享",
                    AuthorName = "李四",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 1, 1, 13, 2, 2, DateTimeKind.Utc),
                },

                new Comment
                {
                    Id = 3,
                    ArticleId = 1,
                    ParentId = 1,
                    Content = "说的不错",
                    AuthorName = "李四",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 1, 1, 13, 3, 2, DateTimeKind.Utc),
                },

                new Comment
                {
                    Id = 4,
                    ArticleId = 1,
                    ParentId = 3,
                    Content = "谢谢",
                    AuthorName = "张三",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 1, 1, 13, 3, 2, DateTimeKind.Utc),
                });
        }
    }
}
