using BlogSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ArticlesController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var articles = await _context.Articles
                .OrderByDescending(a => a.IsPublished)
                .Include(a => a.Category)
                .ToListAsync();
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var article = await _context.Articles
                .Include(a => a.Category)
                .Include(a => a.Tags)
                .FirstOrDefaultAsync(a => a.Id == id);
            return article == null ? NotFound() : Ok(article);
        }
    }
}
