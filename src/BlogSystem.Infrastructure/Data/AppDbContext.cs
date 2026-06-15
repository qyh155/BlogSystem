using Microsoft.EntityFrameworkCore;
using BlogSystem.src.Domain.Entities;

namespace BlogSystem.src.Infrastructure.Data
{
    public class AppDbContext:DbContext
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

            //-------------------Article------------------------
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasOne(a => a.User)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasQueryFilter(a => !a.IsDeleted);
            });

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

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasMany(c => c.Articles)
                    .WithOne(a => a.Category)
                    .HasForeignKey(a => a.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Tag>(entity => 
            {
                entity.HasMany(t => t.Articles)
                    .WithMany(a => a.Tags)
                    .UsingEntity(j => j.ToTable("ArticleTags"));
            });
        }
    }
}
