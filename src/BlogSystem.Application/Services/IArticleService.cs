using BlogSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Application.Services
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetAllAsync();
        Task<ArticleDto?> GetByIdAsync(int id);
    }
}
