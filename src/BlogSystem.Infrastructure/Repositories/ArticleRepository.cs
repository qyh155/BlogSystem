using BlogSystem.Domain.Interfaces;
using BlogSystem.Domain.Entities;
using BlogSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDbContext _context;
        public ArticleRepository(AppDbContext context) => _context = context;

        public async Task<List<Article>> GetAllAsync()
        {
            return await _context.Articles
                .Include(a => a.Category)
                .Include(a => a.User)
                .Include(a => a.Tags)
                .ToListAsync();
        }

        public async Task<Article?> GetByIdAsync(int id)
        {
            return await _context.Articles
                .Include(a => a.Category)
                .Include(a => a.User)
                .Include(a => a.Tags)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
