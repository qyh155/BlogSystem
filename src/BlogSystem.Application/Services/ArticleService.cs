using BlogSystem.Application.DTOs;
using BlogSystem.Domain.Interfaces;

namespace BlogSystem.Application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRespository;
        public ArticleService(IArticleRepository articleRepository) => _articleRespository = articleRepository;

        public async Task<List<ArticleDto>> GetAllAsync()
        {
            var aritcles = await _articleRespository.GetAllAsync();
            return aritcles.Select(a => new ArticleDto
            {
                Id = a.Id,
                Title = a.Title,
                Summary = a.Summary,
                Content = a.Content,
                CreatedAt = a.CreatedAt,
                CategoryName = a.Category.Name,
                AuthorName = a.User.UserName,
                Tags = a.Tags.Select(t => t.Name).ToList()
            }).ToList();
        }

        public Task<ArticleDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
