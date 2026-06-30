using BlogSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Domain.Interfaces
{
    public interface IArticleRepository
    {
        public Task<List<Article>> GetAllAsync();
        public Task<Article?> GetByIdAsync(int id);
    }
}
